using Desafio_Shopping.Model;
using Desafio_Shopping.Model.DAO.TXT_File;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Shopping.Controller
{
    public class InvoicesController
    {
        Facade facade;
        public InvoicesController()
        {
            this.facade = Facade.GetInstance();
        }
        public string invoices(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list, string patch)
        {
            return this.facade.invoices(p_list, d_list, o_list, patch);
        }
        public string invoices(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list)
        {
            return this.facade.invoices(p_list, d_list, o_list);
        }
        public List<Invoices> invoicesview(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list)
        {
            List<Invoices> result = new List<Invoices>();
            string resultSplit = this.facade.invoices(p_list, d_list, o_list);
            string[] itemValores = resultSplit.Split('\n');
            int counter = 0;
            int i = 0;
            Invoices invoices = new Invoices();
            while (i < itemValores.Length - 1)
            {
                if (counter == 0)
                {
                    invoices.quant = int.Parse(itemValores[i].ToString());
                    counter++;
                }
                else if (counter == 1)
                {
                    invoices.ID_invoice = int.Parse(itemValores[i].ToString());
                    counter++;
                }
                else if (counter == 2)
                {
                    invoices.amount_invoice = int.Parse(itemValores[i].ToString());
                    counter++;
                }
                else if (counter == 3)
                {
                    invoices.invoice_total = int.Parse(itemValores[i].ToString());
                    counter = 1;
                    result.Add(invoices);
                    invoices = new Invoices();
                }

                i++;
            }
            return result;
        }
    }
}
