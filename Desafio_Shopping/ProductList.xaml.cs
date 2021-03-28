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
    /// Interação lógica para ProductList.xam
    /// </summary>
    public partial class ProductList : Page
    {
        private ProductController productController;
        public static string patch_product = "";
        private static ProductList _instance;
        private ProductList()
        {
            InitializeComponent();
            this.productController = new ProductController();
        }

        public static ProductList GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductList();
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
                    patch_product = @"" + System.IO.Path.GetFullPath(openFileDialog.FileName);
                    MessageBox.Show("Products imported!" + patch_product, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    List<Product> po_list = this.productController.getListProducts(patch_product);
                    foreach (Product p in po_list)
                    {
                        TableProducts.Items.Add(p);
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
