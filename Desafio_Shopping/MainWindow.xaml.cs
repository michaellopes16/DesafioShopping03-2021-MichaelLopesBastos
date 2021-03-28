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
using Desafio_Shopping.View;

namespace Desafio_Shopping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string userName = "michael.bastos";
        private string password = "novoFuncionario";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try {
                //Permite movimentar a janela
                base.OnMouseLeftButtonDown(e);
                this.DragMove();
            }
            catch (Exception)
            {}
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Equals(userName) && txtUserPassWord.Password.Equals(password))
            {
                this.Hide();
                ManagerOrders managerOrders = new ManagerOrders();
                managerOrders.Show();
            }
            else {
                MessageBox.Show("Invalid username or password", "Pay attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
