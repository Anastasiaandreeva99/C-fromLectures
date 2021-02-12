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

namespace Problem1
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public event EventHandler Login;
        public string UserName
        {
            get
            {
                return TxtUserName.Text;

            }
            set
            {
                TxtUserName.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return TxtPassword.Password;

            }
            set
            {
                TxtPassword.Password = value;
            }
        }
        public LoginUserControl()
        {
            InitializeComponent();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TxtPassword.Password = string.Empty;
            TxtUserName.Text = string.Empty;
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login?.Invoke(this, 
                          new LoginEventArgs(TxtUserName.Text, TxtPassword.Password));

        }
    }
}
