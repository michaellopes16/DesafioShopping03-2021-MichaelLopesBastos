using System;
using System.Collections.Generic;
using System.Text;
using Desafio_Shopping.Model;

namespace Desafio_Shopping.Controller
{
    public class DiscountController
    {
        Facade facade;
        public DiscountController()
        {
            this.facade = Facade.GetInstance();
        }
        public List<Discount> getListProductsDiscount(string patch)
        {
            return this.facade.getListProductsDiscount(patch);
        }
    }
}
