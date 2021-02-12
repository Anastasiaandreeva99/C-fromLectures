using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServerTest.WPF.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataForm.RequestEvent += DataForm_RequestEvent;
            dataForm.SaveEvent += DataForm_SaveEvent;
        }

        private async void DataForm_RequestEvent(object sender, RequestEventArgs e)
        {
            string req = await Task.Run(() => RequestClient.SendRequest(e.FileName));
            if (req == "There is no such file!")
            {
                log.Text += req + "\n";
            }
            else
            {
                dataForm.content.AppendText(req);
                log.Text += "Successful request\n";
            }
        }

        private async void DataForm_SaveEvent(object sender, SaveEventArgs e)
        {
            string rec = await Task.Run(() => SaveClient.SendSave(e.FileName, e.Content));
            log.Text += rec + "\n";
        }
    }
}
