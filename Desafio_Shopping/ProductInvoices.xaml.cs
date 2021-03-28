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
    /// Interação lógica para Invoices.xam
    /// </summary>
    public partial class ProductInvoices : Page
    {
        //public static string PACTCH_PRODUCT_LIST = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Product_list.txt";
       // public static string PACTCH_PRODUCT_DISCOUNT = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Discount_list.txt";
       // public static string PACTCH_PRODUCT_ORDERS = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Purchase_order_list.txt";
       // public static string PACTCH_INVOICES = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\invoices.txt";

        ProductController productController;
        DiscountController discountController;
        P_Order_Controller p_Order_Controller;
        InvoicesController invoicesController;
        List<Product> p_list;
        List<Discount> d_list;
        List<PurchaseOrder> po_list;
        private static ProductInvoices _instance;
        private ProductInvoices()
        {
            InitializeComponent();

            productController = new ProductController();
            discountController = new DiscountController();
            p_Order_Controller = new P_Order_Controller();
            invoicesController = new InvoicesController();
            try
            {
                this.p_list = productController.getListProducts(ProductList.patch_product);
                this.d_list = discountController.getListProductsDiscount(ProductsDiscount.patch_product_discount);
                this.po_list = p_Order_Controller.getListProductOrders(ProductOrder.patch_order);

                foreach (Invoices i in formatInvoices())
                {
                    TableInvoices.Items.Add(i);
                }
            }
            catch (Exception) {
                MessageBox.Show("Os produtos e as ordens precisam ser carregadas para geração da nota", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public static ProductInvoices GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductInvoices();
            }
            return _instance;
        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, invoicesController.invoices(p_list, d_list, po_list));
                    MessageBox.Show("Invoice saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error to save invoices:" + er, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private List<Invoices> formatInvoices()
        {
            return invoicesController.invoicesview(p_list, d_list, po_list);
        }
    }
}
