using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>() {
                new Product(){Description = "Product", Qty = 1 }
            };

            Store store = new Store(list);
            Employee e = new Employee("Worker", store);
            Manager m = new Manager("Manager", store);
            store.OnAppointment(e);
            store.OnAppointment(m);
            store.OnUpdateQty(0, 10);
            e.ManageQty(list[0], 10);
        }
    }
}
