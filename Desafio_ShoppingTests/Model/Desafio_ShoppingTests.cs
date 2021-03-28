using Microsoft.VisualStudio.TestTools.UnitTesting;
using Desafio_Shopping.Model;
using System;
using System.Collections.Generic;
using Desafio_Shopping.Controller;
using Desafio_Shopping.Model.DAO.TXT_File;
using Desafio_Shopping.Model.Service;

namespace Desafio_Shopping.Model.Tests
{
    [TestClass()]
    public class Desafio_ShoppingTests
    {

        /**
         - Como forma de organização, utilizaremos para os métodos de teste o seguinte padrão:
           nomeMetodoOriginal_ComportamentoDoTeste_ResultadoEsperado();
         */
        public static string PACTCH_PRODUCT_LIST = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Product_list.txt";
        public static string PACTCH_PRODUCT_DISCOUNT = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Discount_list.txt";
        public static string PACTCH_PRODUCT_ORDERS = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Purchase_order_list.txt";
        public static string PACTCH_INVOICES = @"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\invoices.txt";

        private ProductController productController;
        private DiscountController discountController;
        private P_Order_Controller p_Order_Controller;
        private InvoicesController invoicesController;
        List<Product> p_list;
        List<Discount> d_list;
        List<PurchaseOrder> po_list;
        public Desafio_ShoppingTests()
        {
            this.productController = new ProductController();
            this.discountController = new DiscountController();
            this.p_Order_Controller = new P_Order_Controller();
            this.invoicesController = new InvoicesController();
            this.p_list = productController.getListProducts(PACTCH_PRODUCT_LIST);
            this.d_list = discountController.getListProductsDiscount(PACTCH_PRODUCT_DISCOUNT);
            this.po_list = p_Order_Controller.getListProductOrders(PACTCH_PRODUCT_ORDERS);
        }
        //Testes para regra de negócio da geração da fatura de compra

        [TestMethod()]
        public void makeDiscount_GetDiscaunt_ReturnPositiveValue()
        {
            //Arrange
            InvoicesService service = new InvoicesService();
            //Act
            //Assert
            Assert.AreEqual(12,service.makeDiscaunt(16, 8, 4, 3,2,"Tapioca"));
        }
        [TestMethod()]
        public void makeDiscount_NoDiscaunt_ReturnSameValue()
        {
            //Arrange
            InvoicesService service = new InvoicesService();
            //Act
            //Assert
            Assert.AreEqual(16, service.makeDiscaunt(16, 8, 1, 1, 2, "Tapioca"));
        }

        [TestMethod()]
        public void invoices_ErroGenarate_ReturnNull()
        {
            //Arrange
            Facade facade = Facade.GetInstance();
            //Act
            //Assert
            Assert.ThrowsException<Exception>(() => facade.invoices(null, null, null, ""));
        }

        [TestMethod()]
        public void invoices_SuccessGenarate_ReturnFullList()
        {
            //Arrange
            Facade facade = Facade.GetInstance();
            //Act
            var result = facade.invoices(p_list, d_list, po_list, PACTCH_INVOICES);
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void invoices_FolowDefault_ListInCorrectOrder()
        {
            //Arrange
            string correctOrder = "2\n1\n2\n9\n2\n6\n29\n";
            Facade facade = Facade.GetInstance();
            //Act
            var result = facade.invoices(p_list, d_list, po_list, PACTCH_INVOICES);
            //Assert
            Assert.AreEqual(correctOrder, result);
        }

        //Testes para geração de fatura de compra
        [TestMethod()]
        public void createInvoices_ErrorLoad_ThrowException()
        {
            //Arrange
            InvoicesDAO dao = InvoicesDAO.GetInstance();
            //Act
            //Assert
            Assert.IsNotNull(dao.createFullInvoice("2\n1\n2\n9\n2\n6\n29\n", PACTCH_INVOICES));
        }

        [TestMethod()]
        public void createInvoices_SuccessLoad_ReturnFullList()
        {
            //Arrange
            InvoicesDAO dao = InvoicesDAO.GetInstance();
            //Act
            //Assert
            //Id = 2, Status = RanToCompletion, Method = "{null}", Result = "System.Threading.Tasks.VoidTaskResult"
            Assert.ThrowsExceptionAsync<Exception>(() => dao.createFullInvoice("", ""));
        }

        //Testes para o carregamento da Lista de produtos
        [TestMethod()]
        public void getAllProducts_ErrorLoad_ThrowException()
        {
            //Arrange
            ProductDAO dao = ProductDAO.GetInstance();
            //Act
            //Assert
            Assert.ThrowsException<Exception>(() => dao.getAll(""));
        }

        [TestMethod()]
        public void getAllProducts_SuccessLoad_ReturnFullList()
        {
            //Arrange
            ProductDAO dao = ProductDAO.GetInstance();
            //Act
            //Assert
            Assert.IsNotNull(dao.getAll(PACTCH_PRODUCT_LIST));
        }

        // Testes para o carregamento de arquivos de desconto
        [TestMethod()]
        public void getAllProductsDiscount_ErrorLoad_ThrowException()
        {
            //Arrange
            DiscountDAO dao = DiscountDAO.GetInstance();
            //Act
            //Assert
            Assert.ThrowsException<Exception>(() => dao.getAll(""));
        }

        [TestMethod()]
        public void getAllProductsDiscount_SuccessLoad_ReturnFullList()
        {
            //Arrange
            DiscountDAO dao = DiscountDAO.GetInstance();
            //Act
            //Assert
            Assert.IsNotNull(dao.getAll(PACTCH_PRODUCT_DISCOUNT));
        }

        // Testes para o carregamento das ordens de produto
        [TestMethod()]
        public void getAllProductOrders_ErrorLoad_ThrowException()
        {
            //Arrange
            PurchaseOrderDAO dao = PurchaseOrderDAO.GetInstance();
            //Act
            //Assert
            Assert.ThrowsException<Exception>(() => dao.getAll(""));
        }

        [TestMethod()]
        public void getAllProductOrders_SuccessLoad_ReturnFullList()
        {
            //Arrange
            PurchaseOrderDAO dao = PurchaseOrderDAO.GetInstance();
            //Act
            //Assert
            Assert.IsNotNull(dao.getAll(PACTCH_PRODUCT_ORDERS));
        }
    }
}