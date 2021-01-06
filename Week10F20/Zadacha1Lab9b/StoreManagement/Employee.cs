using System;
using System.Collections.Generic;

namespace StoreManagement
{
    public  class Employee:EventArgs
    {
        private string name;
        private Store storeAt;
        private List<Product> list;//??
        public Employee(string name, Store store)
        {
            Name = name;
            storeAt = store;
            storeAt.Appoint += GetAppointed;
        }

        protected virtual void GetAppointed(object sender, EventArgs args)
        {
            
            if (args  is Manager) return;
            Employee e = args as Employee;
            Store store = (Store)sender;
            list = store.listOfProducts;
            Console.WriteLine("Employee: {0} appointed", e.Name); 
        }
        public Store WorksAt
        {
            get { return storeAt; }
            set { storeAt = value; }
        }
 
        public void ManageQty(Product p, int qty)
        {
            WorksAt.OnUpdateQty(WorksAt.listOfProducts.IndexOf(p), qty);
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
