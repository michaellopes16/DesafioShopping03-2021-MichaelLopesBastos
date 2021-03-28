using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Shopping.Model
{
    class ProductService
    {
        ProductDAO dao;
        public ProductService()
        {
            this.dao = ProductDAO.GetInstance();
        }

        public List<Product> getListProduct(string patch) {
            //Existe alguma regra de negocio a ser implementada aqui ?
            return this.dao.getAll(patch);
        }

        //public 

    }
}
