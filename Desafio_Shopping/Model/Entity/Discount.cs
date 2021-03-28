using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Desafio_Shopping.Utils;

namespace Desafio_Shopping.Model
{
    public class Discount
    {
        public string ID_Discount { get; set; }
        public string product_name { get; set; }
        public int take { get; set; }
        public int pay { get; set; }

        public Discount(string product_name, int take, int pay)
        {
            ID_Discount = KeyFactory.RandomString(5);
            this.product_name = product_name;
            this.take = take;
            this.pay = pay;
        }

        public Discount()
        {
            ID_Discount = KeyFactory.RandomString(5);
        }

        override
        public string ToString()
        {
            return "ID Discaunt: " + this.ID_Discount
               + "\nProduct Name: " + this.product_name
               + "\nTake: " + this.take
                +"\nPay: " + this.pay;
        }
    }
}
