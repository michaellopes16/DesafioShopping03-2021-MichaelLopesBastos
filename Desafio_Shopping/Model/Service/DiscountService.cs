using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Shopping.Model.Service
{
    class DiscountService
    {
        DiscountDAO dao;
        public DiscountService()
        {
            this.dao =  DiscountDAO.GetInstance();
        }
        public List<Discount> getListProductsDiscount(string patch)
        {
            //Existe alguma regra de negocio a ser implementada aqui ?
            return this.dao.getAll(patch);
        }
    }
}
