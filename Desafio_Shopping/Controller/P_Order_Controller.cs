using System;
using System.Collections.Generic;
using System.Text;
using Desafio_Shopping.Model;

namespace Desafio_Shopping.Controller
{
    public class P_Order_Controller
    {
        Facade facade;
        public P_Order_Controller()
        {
            this.facade = Facade.GetInstance();
        }

        public List<PurchaseOrder> getListProductOrders(string patch)
        {
            return this.facade.getProductOrders(patch);
        }

    }
}
