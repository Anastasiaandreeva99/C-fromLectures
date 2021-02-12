using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Xml.Linq;

namespace MwRESTTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            
             
        }

        private async void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            string result = await client
                 .GetStringAsync(new Uri("http://localhost:17476/ProductRESTService.svc/GetProductList/"));

            XDocument xmlResponse = XDocument.Parse(result);
            XNamespace ns = xmlResponse.Root.GetDefaultNamespace();

            var elements = from element in xmlResponse.Descendants(ns + "Product")
                           let Category = element.Element(ns + "CategoryName").Value
                           let Name = element.Element(ns + "Name").Value
                           let Price = element.Element(ns + "Price").Value
                           let ProductId = element.Element(ns + "ProductId").Value
                           select new { Category, Name, Price, ProductId };
            if (elements.Any())
            {
                foreach (var item in elements)
                {
                    LstProductList.Items.Add(item);
                }
            }
            else
            {
                LstProductList.Items.Add("No matches");
            }


        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            LstProductList.Items.Clear();

        }
    }
}
