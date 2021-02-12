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
    /// Interaction logic for DataForm.xaml
    /// </summary>
    public partial class DataForm : UserControl
    {
        public string RequestButtonText { get; set; } = "Request";
        public string SaveButtonText { get; set; } = "Save";

        public string FileNameLabel { get; set; } = "FileName";
        public string FileContentLabel { get; set; } = "FileContent";
        public delegate void RequestEventHandler(object sender, RequestEventArgs e);
        public event RequestEventHandler RequestEvent;
        public delegate void SaveEventHandler(object sender, SaveEventArgs e);
        public event SaveEventHandler SaveEvent;

        public DataForm()
        {
            InitializeComponent();
        }

        private void Request_Click(object sender, RoutedEventArgs e)
        {
            RequestEvent?.Invoke(this, new RequestEventArgs {FileName = fileName.Text });
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(content.Document.ContentStart, content.Document.ContentEnd).Text;
            SaveEvent?.Invoke(this, new SaveEventArgs { FileName = fileName.Text, Content = richText});
        }
    }
}
