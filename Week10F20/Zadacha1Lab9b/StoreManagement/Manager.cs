using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    public class Manager : Employee
    {

        public Manager(string name, Store store) : base(name, store)
        {
            store.PropertyChanged += ManageQty;

        }
        private void ManageQty(object sender, PropertyChangedEventArgs args)
        {
            Console.WriteLine("Product {0} quantity changed", args.PropertyName);

        }
        protected override void GetAppointed(object sender, EventArgs args)
        {
            
            if (args is Manager)
            {
                Manager m = args as Manager;
                Store store = (Store)sender;
                Console.WriteLine("Manager: {0} appointed to store.", m.Name);
            }
        }
    }
}
