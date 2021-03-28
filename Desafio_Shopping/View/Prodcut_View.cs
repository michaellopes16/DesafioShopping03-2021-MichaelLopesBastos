using System;
using System.Collections.Generic;
using System.Text;
using Desafio_Shopping.Controller;
using Desafio_Shopping.Model;
using System.Diagnostics;
using Desafio_Shopping.Utils;

namespace Desafio_Shopping.View
{
    //Classe base para testes
    class Prodcut_View
    {
        private ProductController productController;
        private DiscountController discountController;
        private P_Order_Controller p_Order_Controller;
        private InvoicesController invoicesController;

        public static string PACTCH_PRODUCT_LIST = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Product_list.txt";
        public static string PACTCH_PRODUCT_DISCOUNT = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Discount_list.txt";
        public static string PACTCH_PRODUCT_ORDERS = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Purchase_order_list.txt";
        public static string PACTCH_INVOICES = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\invoices.txt";

        public Prodcut_View()
        {
            this.productController = new ProductController();
            this.discountController = new DiscountController();
            this.p_Order_Controller = new P_Order_Controller();
            this.invoicesController = new InvoicesController();
        }

        public void printResults() {

           // MyConsole myConsole = new MyConsole();
            //string userInput = Console.ReadLine();
            
            List<Product>  p_list = this.productController.getListProducts(PACTCH_PRODUCT_LIST);
            List<Discount> d_list = this.discountController.getListProductsDiscount(PACTCH_PRODUCT_DISCOUNT);
            List<PurchaseOrder> po_list = this.p_Order_Controller.getListProductOrders(PACTCH_PRODUCT_ORDERS);

            foreach (Product p in p_list) {
                Debug.Write(p.ToString());
                Debug.Write("\n----------------\n");
            }
            foreach (Discount d in d_list)
            {
                Debug.Write(d.ToString());
                Debug.Write("\n================\n");
            }

            foreach (PurchaseOrder po in po_list)
            {
                Debug.Write(po.ToString());
                Debug.Write("\n================\n");
            }

            Debug.Write(this.invoicesController.invoices(p_list, d_list, po_list, PACTCH_INVOICES));
        }
    }
}
