using System;
using System.Collections.Generic;
using System.Text;
using Desafio_Shopping.Utils;
namespace Desafio_Shopping.Model
{
    public class PurchaseOrder
    {
        public int ID_order { get; set; }
        public int quant { get; set; }
        public List<String> product_names { get; set; }
        public PurchaseOrder()
        {
        }

        public PurchaseOrder(int iD_order, int quant, List<string> product_names)
        {
            ID_order = iD_order;
            this.quant = quant;
            this.product_names = product_names;
        }

        override
        public string ToString()
        {
            string result = "ID Product: " + this.ID_order
               + "\nProduct quant: " + this.quant;

            foreach (string name in product_names) {
                result += "\nProduct name: "+name+"";
            }
            return result;     
        }

    }
}
