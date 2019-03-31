using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    public class CustomerManager
    {
        public void AddCustomer(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.AddCustomer(customer);
        }
    }
}
