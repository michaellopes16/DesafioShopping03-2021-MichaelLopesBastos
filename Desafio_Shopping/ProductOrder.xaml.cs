using Desafio_Shopping.Controller;
using Desafio_Shopping.Model;
using Desafio_Shopping.Model.DAO.TXT_File;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interação lógica para ProductOrder.xam
    /// </summary>
    public partial class ProductOrder : Page
    {
        public static string patch_order = "";
        private P_Order_Controller p_Order_Controller;
        private static ProductOrder _instance;
        private ProductOrder()
        {
            InitializeComponent();
            this.p_Order_Controller = new P_Order_Controller();
        }
        public static ProductOrder GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductOrder();
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
                    patch_order = @""+System.IO.Path.GetFullPath(openFileDialog.FileName);
                    MessageBox.Show("Order imported!"+ patch_order, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    List<PurchaseOrder> po_list = this.p_Order_Controller.getListProductOrders(patch_order);
                    foreach (PurchaseOrder po in po_list)
                    {
                        TableOrders.Items.Add(po);
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error to import order:" + er, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
