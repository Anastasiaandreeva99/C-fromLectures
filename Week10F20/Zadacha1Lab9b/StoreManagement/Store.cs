using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    public class Store:INotifyPropertyChanged
    {
        public event EventHandler Appoint;
        public event PropertyChangedEventHandler PropertyChanged;

        private Employee worker;
        private Manager manager;
        public List<Product> listOfProducts;
        public Store(List<Product> list)
        {
            listOfProducts = new List<Product>(list);
        }
        public Employee Worker
        {
            get { return worker; }
            set { worker = value; }
        }
        public void OnUpdateQty(int index, int newQty)
        {
            if(index < listOfProducts.Count)
            {
                listOfProducts[index].Qty = newQty;
                PropertyChanged?.Invoke(this,
                                       new PropertyChangedEventArgs("Qty"));
            }
        }
        public void OnAppointment(Employee employee)
        {
            if (employee is Manager)
            {
                // appoint manager
                manager = employee as Manager;
                Appoint?.Invoke(this, employee);
            }
            else

            {
                worker = employee;
                Appoint?.Invoke(this, employee);
            }
        }

    }
}
