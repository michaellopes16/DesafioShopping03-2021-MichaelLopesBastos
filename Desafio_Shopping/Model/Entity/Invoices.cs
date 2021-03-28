using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Shopping.Model.DAO.TXT_File
{
    public class Invoices
    {
        public int ID_invoice { get; set; }
        public int amount_invoice { get; set; }
        public int invoice_total { get; set; }
        public int quant { get; set; }
        public Invoices()
        {
        }

        override
        public string ToString() {
            return "ID_Invoice:         "+this.ID_invoice
                +"\nQuantidade de itens:"+this.amount_invoice
                +"\nValor total:        "+this.invoice_total;
        }

      
    }
}
