using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Shopping.Model.Service
{
    class ProductOrderService
    {
        private PurchaseOrderDAO dao;
        public ProductOrderService()
        {
            this.dao = PurchaseOrderDAO.GetInstance();
        }

        public List<PurchaseOrder> getListProductOrders(string patch)
        {
            //Existe alguma regra de negocio a ser implementada aqui ?
            return this.dao.getAll(patch);
        }
    }
}
