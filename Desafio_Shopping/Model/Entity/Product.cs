using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Desafio_Shopping.Utils;


namespace Desafio_Shopping.Model
{
    public class Product
    {
        public string ID_Product { get; set; }
        public string product_name { get; set; }
        public int product_price { get; set; }

        public Product() {
            this.ID_Product = KeyFactory.RandomString(6);
        }
        public Product(string ID_Product, string product_name, int product_price)
        {
            this.ID_Product = ID_Product;
            this.product_name = product_name;
            this.product_price = product_price;
        }
        
        override
        public string ToString() {
            return "ID Product: "+this.ID_Product
               +"\nProduct Name: "+this.product_name
               +"\nProduct Price: "+this.product_price;
        }
    }
}
