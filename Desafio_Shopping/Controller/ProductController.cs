using System;
using System.Collections.Generic;
using System.Text;
using Desafio_Shopping.Model;

namespace Desafio_Shopping.Controller
{

    public class ProductController
    {
        Facade facade;
        public ProductController()
        {
            this.facade = Facade.GetInstance();
        }

        public List<Product> getListProducts(string patch)
        {
            return this.facade.getListProducts(patch);
        }

    }
}
