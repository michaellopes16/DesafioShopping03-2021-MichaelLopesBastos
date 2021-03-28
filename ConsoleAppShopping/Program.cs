using Desafio_Shopping.Controller;
using Desafio_Shopping.Model;
using System;
using System.Collections.Generic;

namespace ConsoleAppShopping
{
    class Program
    {
        //public static string PACTCH_PRODUCT_LIST = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Product_list.txt";

        static void Main(string[] args)
        {
            ProductController productController;
            productController = new ProductController();

            DiscountController discountController;
            discountController = new DiscountController();
             
            P_Order_Controller p_Order_Controller;
            p_Order_Controller = new P_Order_Controller();

            InvoicesController invoicesController;
            invoicesController = new InvoicesController();

            // Coletar informações dos caminhos ao usuário
            Console.WriteLine("\nInsira a URL para a Lista de produtos:\n");
            string patch_product_list = @""+Console.ReadLine();

            Console.WriteLine("\nInsira a URL para a Lista de produtos com desconto:\n");
            string patch_product_discaunt= @"" + Console.ReadLine();

            Console.WriteLine("\nInsira a URL para a Lista com as ordens de compra:\n");
            string patch_product_orders = @"" + Console.ReadLine();

            Console.WriteLine("\nInsira a URL para onde irá a fatura com as ordens de compra:\n");
            string patch_product_invoice = @"" + Console.ReadLine();

            List<Product> p_list = productController.getListProducts(patch_product_list);
            List<Discount> d_list = discountController.getListProductsDiscount(patch_product_discaunt);
            List<PurchaseOrder> po_list = p_Order_Controller.getListProductOrders(patch_product_orders);
            
            foreach (Product p in p_list)
             {
                Console.WriteLine(p.ToString());
                Console.WriteLine("\n----------------\n");
             }
            foreach (Discount d in d_list)
            {
                Console.WriteLine(d.ToString());
                Console.WriteLine("\n================\n");
            }

            foreach (PurchaseOrder po in po_list)
            {
                Console.WriteLine(po.ToString());
                Console.WriteLine("\n================\n");
            }
            string result = invoicesController.invoices(p_list, d_list, po_list, patch_product_invoice);
            string[] itemValores = result.Split('\n');
            int counter = 0;
            int i = 0;
            while (i < itemValores.Length-1) 
            {
                if (counter == 0)
                {
                    Console.WriteLine("Quantidade de ordens da fatura:           "+itemValores[i].ToString());
                    counter++;
                }
                else if (counter == 1)
                {
                    Console.WriteLine("ID da Ordem de compra do produto:         "+itemValores[i].ToString());
                    counter++;
                }
                else if (counter == 2) {
                    Console.WriteLine("Montante da Ordem de compra do produto:   "+itemValores[i].ToString());
                    counter++;
                }
                else if (counter == 3)
                {
                    Console.WriteLine("Valor total da Ordem de compra do produto:"+itemValores[i].ToString());
                    Console.WriteLine("\n===================================================================\n");
                    counter = 1;
                }
                i++;
            }
        }
    }
}
