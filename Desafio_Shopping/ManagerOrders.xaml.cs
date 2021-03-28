using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desafio_Shopping
{
    /// <summary>
    /// Lógica interna para ManagerOrders.xaml
    /// </summary>
    public partial class ManagerOrders : Window
    {
        public ManagerOrders()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                base.OnMouseLeftButtonDown(e);

                // Begin dragging the window
                this.DragMove();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {
            ViewProducts.Content =  ProductsDiscount.GetInstance();
        }
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            ViewProducts.Content = ProductList.GetInstance();
        }
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            ViewProducts.Content = ProductOrder.GetInstance();
        }
        private void btnInvoices_Click(object sender, RoutedEventArgs e)
        {
            ViewProducts.Content = ProductInvoices.GetInstance();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
