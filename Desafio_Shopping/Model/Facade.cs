using System;
using System.Collections.Generic;
using System.Text;
using Desafio_Shopping.Model.Service;


namespace Desafio_Shopping.Model
{
    public class Facade
    {
        ProductService productService;
        DiscountService discountService;
        ProductOrderService productOrderService;
        InvoicesService invoicesService;

        private static Facade _instance;
        private Facade()
        {
            this.productService = new ProductService();
            this.discountService = new DiscountService();
            this.productOrderService = new ProductOrderService();
            this.invoicesService = new InvoicesService();
           
        }

        public string invoices(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list, string pacth) {
            return this.invoicesService.invoices(p_list, d_list, o_list, pacth);
        }
        public string invoices(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list)
        {
            return this.invoicesService.invoices(p_list, d_list, o_list);
        }

        public string invoicesView(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list, string pacth)
        {
            return this.invoicesService.invoices(p_list, d_list, o_list, pacth);
        }

        public List<Product> getListProducts(string patch) {
            return this.productService.getListProduct(patch);
        }

        public List<Discount> getListProductsDiscount(string patch)
        {
            return this.discountService.getListProductsDiscount(patch);
        }
        public List<PurchaseOrder> getProductOrders(string patch)
        {
            return this.productOrderService.getListProductOrders(patch);
        }
        public static Facade GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Facade();
            }
            return _instance;
        }
    }
}
