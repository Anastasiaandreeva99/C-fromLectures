using Problem1;
using System;
using System.Windows;

namespace Problem1Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginUserControl_Login(object sender, EventArgs e)
        {
            LoginEventArgs eventObject = e as LoginEventArgs;
            if(eventObject != null)
            {
                string usr = eventObject.UserName;
                string pwd = eventObject.Password;
                MessageBox.Show($"Login activated for {usr} with {pwd}");
            }
           
        }
    }
}
