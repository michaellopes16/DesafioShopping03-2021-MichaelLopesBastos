using Desafio_Shopping.Controller;
using Desafio_Shopping.Model;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desafio_Shopping
{
    /// <summary>
    /// Interação lógica para ProductsDiscount.xam
    /// </summary>
    public partial class ProductsDiscount : Page
    {
        private DiscountController discountController;
        public static string patch_product_discount = "";
        private static ProductsDiscount _instance;
        private ProductsDiscount()
        {
            InitializeComponent();
            this.discountController = new DiscountController();
        }
        public static ProductsDiscount GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductsDiscount();
            }
            return _instance;
        }
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    patch_product_discount = @"" + System.IO.Path.GetFullPath(openFileDialog.FileName);
                    MessageBox.Show("Products imported!" + patch_product_discount, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    List<Discount> po_list = this.discountController.getListProductsDiscount(patch_product_discount);
                    foreach (Discount p in po_list)
                    {
                        TableProductsDiscaunt.Items.Add(p);
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error to import products:" + er, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
