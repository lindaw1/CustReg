using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB
{
    /// <summary>
    /// This the generic read and update method I created to use in WorkShop4,
    /// This can take care any object from any DB
    /// Sql command is just string, so the key idea is to use stringbuilder to build the
    /// required sql command during the run time.
    /// 
    /// ***** the Classes mush have a constructor that takes 0 argument.
    /// </summary>
    public static class GenericDB
    {
        /// <summary>
        /// Generic Reading method for get instants of certain Class from corresponding DB Tables
        /// </summary>
        /// <typeparam name="T"> Generic Type, could be Products, packages etc. 
        /// ***** the Classes mush have a constructor that takes 0 argument.
        /// </typeparam>
        /// <param name="tableName">Corresponding Table Name in DB</param>
        /// <param name="orderByIndex">how you want to order your results, 1 is default</param>
        /// <returns>A list of requried entity classes for the corresponding DB </returns>
        public static List<T> GenericRead<T>(string tableName,int orderByIndex=1) //need inherit from ParentClass so that I can call the extra method
        {
            List<T> classData = new List<T>();//List to hold result
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();//get field of given class

            //prepare the Sql Syntax for the query
            StringBuilder FieldToSqlSyntax = new StringBuilder();
            
            foreach (PropertyInfo property in properties)
            {
                FieldToSqlSyntax.Append(property.Name).Append(",");
            }
            FieldToSqlSyntax.Length--;//remove the last ","

            using (SqlConnection connection = TravelExpertDB.GetConnection())//using method could auto close resources, so the connection got closed automatically
            {
                //The select Sql Syntax
                string selectStatement = "SELECT " + FieldToSqlSyntax + " " +
                                         "FROM " + tableName + " " + "ORDER BY "+orderByIndex;
                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))//auto close Sqlcommand
                {
                    connection.Open();
                    using (SqlDataReader dr = selectCommand.ExecuteReader())//auto close reader
                    {

                        while (dr.Read())
                        {
                            T tempObj = Activator.CreateInstance<T>();//temp entity class
                            PropertyInfo[] tempProperties = tempObj.GetType().GetProperties();//get all the field of this entity class
                                                                                              //if T is Products Class,
                                                                                              //properties will looks like {ProductID, prodName}
                            foreach (PropertyInfo property in tempProperties)
                            {
                                if (dr[property.Name] != DBNull.Value)
                                {
                                    //if the property is nullable, etc "datatime?"(this is a nullable type with datatime type underlying it)
                                    //to get the actual type (datatime) out of "datatime?" by calling Nullable.GetUnderlyingType
                                    //if the property is not nullable, etc int, then the "??" will return right-side property.propertyType which is "int" since left side is "null". 
                                    Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                    //cast the reader result (Object type) to correct type and then assign the value.
                                    //if T is Products Class, It's just like tempObj.ProductID=Convert.toInt32(dr["ProductID"])
                                    property.SetValue(tempObj, Convert.ChangeType(dr[property.Name], t));
                                }
                                else
                                {
                                    //DBNull.Value in DB table, so set the property to null
                                    property.SetValue(tempObj, null);
                                }
                            }
                            classData.Add(tempObj);//add temp entity class to the result List
                        }


                        //----------------------------------------------------------------------------
                        //below is another way that required a constructor with parameters, this does not support default constructor
                        //------------------------------------------------------------------------------
                        //while (dr.Read())
                        //{
                        //    List<Object> args = new List<Object>();//an list to hold the required args for certain entityClass
                        //    foreach (PropertyInfo property in properties)
                        //    {
                        //        if (dr[property.Name] != DBNull.Value)
                        //        {
                        //            //if the property is nullable, etc "datatime?"(this is a nullable type with datatime type underlying it)
                        //            //to get the actual type (datatime) out of "datatime?" by calling Nullable.GetUnderlyingType
                        //            //if the property is not nullable, etc int, then the "??" will return right-side property.propertyType which is "int" since left side is "null". 
                        //            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        //            //cast the reader result (Object type) to correct type and then assign the value.
                        //            //if T is Products Class, It's just like tempObj.ProductID=Convert.toInt32(dr["ProductID"])

                        //            args.Add(Convert.ChangeType(dr[property.Name], t));//add to the args list
                        //            //args.Add(dr[property.Name]);
                        //        }
                        //        else
                        //        {
                        //            //DBNull.Value in DB table, so set the property to null
                        //            args.Add(null);
                        //        }
                        //    }

                        //    T tempObj = (T)Activator.CreateInstance(typeof(T),args.ToArray());//create an instant of entityClass with args

                        //    classData.Add(tempObj);//add temp entity class to the result List
                        //}
                    }
                }

            }
            return classData;//returen results
        }

        /// <summary>
        /// Generic update a record in DB
        /// </summary>
        /// <typeparam name="T">Generic class
        /// ***** the Classes mush have a constructor that takes 0 argument.
        /// </typeparam>
        /// <param name="tableName">Name of the DB Table</param>
        /// <param name="oldObj">the unchanged object for checking concurrency issue</param>
        /// <param name="newObj">the changed object</param>
        /// <param name="sqlCon">Optional argument:to receive outside connection so that enable transcation </param>
        /// <param name="sqlTran">Optional argument:to receive outside transcation so that enable commit or rollback </param>
        /// <param name="FieldIndexToCheck">Optional,the index of property names that needed when checking concurrency caused duplicated info againest the existing records in DB </param>
        /// <returns>the number of affect record, should be 1 if succeed</returns>
        public static int GenericUpdate<T>(string tableName, T oldObj, T newObj,SqlConnection sqlCon=null, SqlTransaction sqlTran=null,int[] FieldIndexToCheck=null)
        {
            int count = 0;
            bool useOutsideConnection=true;//indatictor of outside connection received
            PropertyInfo[] propToCheckDup;//hold the property names that needed when checking duplicated info againest the existing records in DB 
            Type type = typeof(T);

            PropertyInfo[] PropertiesWithPK = type.GetProperties();//get all the field of this entity class
                                                                     //if T is Products Class,
                                                                     //properties will looks like {ProductID, prodName}
            PropertyInfo[] PropertiesExceptPK = PropertiesWithPK.Skip(1).ToArray();//skip the primary key, as we don't need to update

            //set checking list according to argument, for example. For packages, we only check name, startDate, endDate. if these 3 property value are the same
            //then we concern those 2 packages are the same and this duplicate insert should be prevented.
            if (FieldIndexToCheck != null)
            {
                //if passed in, then only check passed in property
                propToCheckDup = new PropertyInfo[FieldIndexToCheck.Length];
                int i = 0;
                foreach (int id in FieldIndexToCheck)
                {
                    propToCheckDup[i] = PropertiesWithPK[id];
                    i++;
                }
            }
            else
            {
                //default, check all property except PK
                propToCheckDup = PropertiesExceptPK;
            }

            //build the where satement used in check concurrey
            StringBuilder FieldToSqlCheckWhere = new StringBuilder();
            foreach (PropertyInfo property in propToCheckDup)
            {
                FieldToSqlCheckWhere.Append(property.Name + "=@New" + property.Name)
               .Append(" AND ");
            }
            FieldToSqlCheckWhere.Length = FieldToSqlCheckWhere.Length - 5;//remove the last " AND "

            bool needToCheckConcurrencyDup = false;

            //For the concurrenty duplication checking list, if at least one required property's value has been changed then need perform a concurrency dup check.
                foreach (PropertyInfo property in propToCheckDup)
                {
                    if (property.GetValue(oldObj) != property.GetValue(newObj))
                    {
                        needToCheckConcurrencyDup = true;
                    break;
                    }
                }
  

            //if no outside connection received, set indatictor to false, then start the connection.
            if (sqlCon == null)
            {
                useOutsideConnection = false;
                sqlCon = TravelExpertDB.GetConnection();
            }

            //prepare the sql syntax for concurrency check
            StringBuilder FieldToSqlWhere = new StringBuilder();
            foreach (PropertyInfo property in PropertiesWithPK)
            {
                FieldToSqlWhere.Append("(" + property.Name + "=@Old" + property.Name + " OR ")
               .Append(property.Name + " IS NULL AND @Old" + property.Name + " IS NULL)")
               .Append(" AND ");
            }
            FieldToSqlWhere.Length = FieldToSqlWhere.Length - 5;//remove the last " AND "


            //Prepare the Update Sql Syntax
            StringBuilder FieldToSqlSet = new StringBuilder();
            foreach (PropertyInfo property in PropertiesExceptPK)
            {
                FieldToSqlSet.Append(property.Name).Append("=@New").Append(property.Name).Append(",");
            }
            FieldToSqlSet.Length--;//remove the last ","

            SqlCommand cmd;
            if (needToCheckConcurrencyDup == false)
            {
                //no value change for requried property in concurrency checking list
                string updateStatement = "UPDATE " + tableName + " SET " + FieldToSqlSet +
                     " WHERE " + FieldToSqlWhere;

                cmd = new SqlCommand(updateStatement, sqlCon);
            }
            else
            {
                //there are changes amont the value of required property, so perfromed a concurrency check
                string updateStatement = "IF NOT EXISTS (SELECT 1 FROM " + tableName + " WHERE " + FieldToSqlCheckWhere + ") " +
                    "UPDATE " + tableName + " SET " + FieldToSqlSet +
                     " WHERE " + FieldToSqlWhere;
                cmd = new SqlCommand(updateStatement, sqlCon);
            }


            //if outside transcation passed in, bound the sql command with the transcation 
            if (sqlTran != null)
            {
                cmd.Transaction = sqlTran;
            }



            //bound @new 
            foreach (PropertyInfo property in PropertiesExceptPK)
            {
                if (property.GetValue(newObj) == null)
                {
                    cmd.Parameters.AddWithValue("@New" + property.Name, DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@New" + property.Name, property.GetValue(newObj, null));
                }
            }

            //Bound @old
            foreach (PropertyInfo property in PropertiesWithPK)
            {
                if (property.GetValue(oldObj) == null)
                {
                    cmd.Parameters.AddWithValue("@Old" + property.Name, DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Old" + property.Name, property.GetValue(oldObj, null));
                }
            }

            //if no outsideConnection passed in, open the connection
            if (!useOutsideConnection)
            {
                sqlCon.Open();
                //execute the query
                count = cmd.ExecuteNonQuery();
                sqlCon.Close();
            } else
            {   //OutsideConnection received, just execute the query,let the outside handle connection open and close
                count = cmd.ExecuteNonQuery();
            }

            // should return 1 if succeed
            return count;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Generic class
        /// ***** the Classes mush have a constructor that takes 0 argument.
        /// </typeparam>
        /// <param name="tableName">Name of the DB Table</param>
        /// <param name="newObj"> the new record you want to insert</param>
        /// <param name="sqlCon">Optional Connection</param>
        /// <param name="sqlTran">Optional Transcation</param>
        /// <param name="FieldIndexToCheck">Optional,the index of property names that needed when checking concurrency caused duplicated info againest the existing records in DB </param>
        /// <returns> the Primary Key value of the new inserted record.</returns>
        public static int GenericInsert<T>(string tableName, T newObj, SqlConnection sqlCon = null, SqlTransaction sqlTran = null, int[] FieldIndexToCheck = null)
        {
            int PKinserted = -1; //PK for new inserted value
            bool useOutsideConnection = true;//indatictor of outside connection received
            string PKcolumnName;//hold primary key column name 
            Type type = typeof(T);
            PropertyInfo[] propertiesWithPK = type.GetProperties();//get properties from newObj
            PKcolumnName = propertiesWithPK[0].Name;
            PropertyInfo[] propToCheckDup;//hold the property names that needed when checking duplicated info againest the existing records in DB 
            //-------------------------------------------------------------
            PropertyInfo[] propertiesExceptPK = propertiesWithPK.Skip(1).ToArray();//skip the primary key, as we don't need to insert PK
                                                                                   //-------------------------------------------------------------

            //set checking list according to argument, for example. For packages, we only check name, startDate, endDate. if these 3 property value are the same
            //then we concern those 2 packages are the same and this duplicate insert should be prevented.
            if(FieldIndexToCheck!=null)
            {
                //if passed in, then only check passed in property
                propToCheckDup = new PropertyInfo[FieldIndexToCheck.Length];
                int i = 0;
                foreach (int id in FieldIndexToCheck)
                {
                    propToCheckDup[i] = propertiesWithPK[id];
                    i++;
                }
            }
            else
            {
                //default, check all property except PK
                propToCheckDup = propertiesExceptPK;
            }

            

            //if no outside connection received, set indatictor to false, then start the connection.
            if (sqlCon == null)
            {
                useOutsideConnection = false;
                sqlCon = TravelExpertDB.GetConnection();
            }

            //prepare the sql syntax for Where for concurrency check
            StringBuilder FieldToSqlWhere = new StringBuilder();
            foreach (PropertyInfo property in propToCheckDup)
            {
                FieldToSqlWhere.Append(property.Name + "=@" + property.Name)
               .Append(" AND ");
            }
            FieldToSqlWhere.Length = FieldToSqlWhere.Length - 5;//remove the last " AND "

            //Prepare the Insert Sql Syntax
            StringBuilder FieldToSqlInsert = new StringBuilder();
            FieldToSqlInsert.Append("(");
            foreach (PropertyInfo property in propertiesExceptPK)
            {
                FieldToSqlInsert.Append(property.Name).Append(",");
            }
            FieldToSqlInsert.Length--;//remove the last ","
            FieldToSqlInsert.Append(")");

            //prepare the sql syntax for VALUES
            StringBuilder FieldToSqlValues = new StringBuilder();
            FieldToSqlValues.Append("(");
            foreach (PropertyInfo property in propertiesExceptPK)
            {
                FieldToSqlValues.Append("@").Append(property.Name).Append(",");
            }
            FieldToSqlValues.Length = FieldToSqlValues.Length - 1;//remove the last ","
            FieldToSqlValues.Append(")");

            //Insert Statement
            string insertStatement = "IF NOT EXISTS (SELECT 1 FROM " + tableName+" WHERE "+FieldToSqlWhere+")"+
                                 "INSERT INTO " + tableName + FieldToSqlInsert +
                                 " OUTPUT INSERTED."+PKcolumnName+
                                 " VALUES " + FieldToSqlValues;

            SqlCommand cmd = new SqlCommand(insertStatement, sqlCon);

            //if outside transcation passed in, bound the sql command with the transcation 
            if (sqlTran != null)
            {
                cmd.Transaction = sqlTran;
            }

            //bound VALUES
            foreach (PropertyInfo property in propertiesExceptPK)
            {
                if (property.GetValue(newObj) == null)
                {
                    cmd.Parameters.AddWithValue("@" + property.Name, DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(newObj, null));
                }
            }

            //if no outsideConnection passed in, open the connection
            if (!useOutsideConnection)
            {
                sqlCon.Open();
                //execute the query
                PKinserted = Convert.ToInt32(cmd.ExecuteScalar());
                // = (int)
                sqlCon.Close();
            }
            else
            {   //OutsideConnection received, just execute the query,let the outside handle connection open and close
                PKinserted = (int)cmd.ExecuteScalar();
            }

            // should return the PK of new inserted record if succeed
            return PKinserted;
        }


        public static int GenericDelete<T>(string tableName, T Obj, SqlConnection sqlCon = null, SqlTransaction sqlTran = null)
        {
            int result;
            bool useOutsideConnection = true;//indatictor of outside connection received
            string PKcolumnName;//hold primary key column name 
            Type type = typeof(T);
            PropertyInfo[] propertiesWithPK = type.GetProperties();//get properties from newObj
            PKcolumnName = propertiesWithPK[0].Name;
            //-------------------------------------------------------------
            PropertyInfo[] propertiesExceptPK = propertiesWithPK.Skip(1).ToArray();//skip the primary key, as we don't need to insert PK
            //-------------------------------------------------------------

            //if no outside connection received, set indatictor to false, then start the connection.
            if (sqlCon == null)
            {
                useOutsideConnection = false;
                sqlCon = TravelExpertDB.GetConnection();
            }

            //prepare the sql syntax for Where for concurrency check
            StringBuilder FieldToSqlWhere = new StringBuilder();
            foreach (PropertyInfo property in propertiesExceptPK)
            {
                FieldToSqlWhere.Append(property.Name + "=@" + property.Name)
               .Append(" AND ");
            }
            FieldToSqlWhere.Length = FieldToSqlWhere.Length - 5;//remove the last " AND "



            //Insert Statement
            string deleteStatement =
                                 "DELETE FROM " + tableName +
                                 " WHERE " + FieldToSqlWhere;

            SqlCommand cmd = new SqlCommand(deleteStatement, sqlCon);

            //if outside transcation passed in, bound the sql command with the transcation 
            if (sqlTran != null)
            {
                cmd.Transaction = sqlTran;
            }

            //bound VALUES
            foreach (PropertyInfo property in propertiesExceptPK)
            {
                if (property.GetValue(Obj) == null)
                {
                    cmd.Parameters.AddWithValue("@" + property.Name, DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(Obj, null));
                }
            }

            //if no outsideConnection passed in, open the connection
            if (!useOutsideConnection)
            {
                sqlCon.Open();
                //execute the query
                result = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            else
            {   //OutsideConnection received, just execute the query,let the outside handle connection open and close
                result = cmd.ExecuteNonQuery();
            }

            // should return the PK of new inserted record if succeed
            return result;
        }
    }
}
