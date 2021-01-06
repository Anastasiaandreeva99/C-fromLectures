using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    public   class Product: EventArgs
    {
        private int qty;
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Qty 
        {
            get { return qty; }
            set { qty = value; }
        }

    }
}
