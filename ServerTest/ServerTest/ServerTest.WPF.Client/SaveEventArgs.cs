using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest.WPF.Client
{
    public class SaveEventArgs : RequestEventArgs
    {
        public string Content { get; set; }
    }
}
