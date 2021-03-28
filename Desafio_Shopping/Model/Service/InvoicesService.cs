using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Desafio_Shopping.Model.DAO.TXT_File;
using System.Diagnostics;

namespace Desafio_Shopping.Model.Service
{
    public class InvoicesService
    {
        private InvoicesDAO dao;
        public InvoicesService()
        {
            this.dao = InvoicesDAO.GetInstance();
        }

        public Task createFullInvoice(string invoice, string patch) {
            return this.dao.createFullInvoice(invoice, patch);
        }

        //Método para criação da fatura final (conjunto de ordens de compra)
        // o txt é criado dentro do Invoices_DAO
        public string invoices(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list, string pacth)
        {
            string result = "";
            int invoice_total;
            int invoice_amount;
            List<Product> product_in_order = new List<Product>();

            // Verifica ovalor dos produtos da lista e contabiliza a frequência do mesmo na lista
            try
            {
                result += o_list.Count;
                foreach (PurchaseOrder o in o_list)
                {
                    invoice_total = 0;
                    invoice_amount = 0;

                    foreach (Product p in p_list)
                    {
                        foreach (string n in o.product_names)
                        {
                            if (n.Contains(p.product_name))
                            {
                                invoice_total += p.product_price;
                                invoice_amount++;
                                product_in_order.Add(p);
                            }
                        }
                    }
                    //Verifica se o produto da ordem faz parte da lista de desconto
                    foreach (Discount d in d_list)
                    {
                        int quant_in_order = 0;
                        Product p = null;
                        foreach (Product pr in product_in_order)
                        {
                            if (pr.product_name.Contains(d.product_name))
                            {
                                quant_in_order++;
                                p = pr;
                            }
                        }
                        if (p != null)
                        {
                            if ((quant_in_order / d.take) >= 1)
                            {
                                invoice_total =  makeDiscaunt(invoice_total, quant_in_order, d.take, d.pay, p.product_price, p.product_name);
                            }
                        }
                    }


                    result += "\n" + o.ID_order+ "\n" + invoice_amount + "\n" + invoice_total;
                }
               var r = this.createFullInvoice(result, pacth);
            }
            catch (Exception e) {
                throw new Exception("Erro ao gerar fatura"+e);
            }
            return result + "\n";
        }

        public string invoices(List<Product> p_list, List<Discount> d_list, List<PurchaseOrder> o_list)
        {
            string result = "";
            int invoice_total;
            int invoice_amount;
            List<Product> product_in_order = new List<Product>();

            // Verifica ovalor dos produtos da lista e contabiliza a frequência do mesmo na lista
            try
            {
                result += o_list.Count;
                foreach (PurchaseOrder o in o_list)
                {
                    invoice_total = 0;
                    invoice_amount = 0;

                    foreach (Product p in p_list)
                    {
                        foreach (string n in o.product_names)
                        {
                            if (n.Contains(p.product_name))
                            {
                                invoice_total += p.product_price;
                                invoice_amount++;
                                product_in_order.Add(p);
                            }
                        }
                    }
                    //Verifica se o produto da ordem faz parte da lista de desconto
                    foreach (Discount d in d_list)
                    {
                        int quant_in_order = 0;
                        Product p = null;
                        foreach (Product pr in product_in_order)
                        {
                            if (pr.product_name.Contains(d.product_name))
                            {
                                quant_in_order++;
                                p = pr;
                            }
                        }
                        if (p != null)
                        {
                            if ((quant_in_order / d.take) >= 1)
                            {
                                invoice_total = makeDiscaunt(invoice_total, quant_in_order, d.take, d.pay, p.product_price, p.product_name);
                            }
                        }
                    }
                    result += "\n" + o.ID_order + "\n" + invoice_amount + "\n" + invoice_total;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar fatura" + e);
            }
            return result + "\n";
        }

        public int makeDiscaunt(int invoice_total, int quant_in_order, int take, int pay, int price, string product_name) {
            //Cálculo para adicionar o desconto. Caso o a quantidade do mesmo produtos dividido
            //pela quantidade de produtos que ele deve levar para ganhar o desconto seja maior ou igual a 1
            //ele recebe o desconto. A multiplicação é feita de forma proporcional a quantidade de produtos.
            //Caso o cliente leve o dobro, ele também recebe o desconto da mesma proporção
            int a = (int)(quant_in_order / take) * pay * price;
            int b = quant_in_order * price;
            invoice_total = invoice_total - (b - a);
            Debug.Write("\nDesconto de: R$ " + (b - a) + " no produto: " + product_name + "\n");
            return invoice_total;
        }
    }
}
