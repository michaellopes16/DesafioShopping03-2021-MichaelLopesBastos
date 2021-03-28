using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Desafio_Shopping.Model
{
    public class PurchaseOrderDAO: I_DAO<PurchaseOrder>
    {
        private static PurchaseOrderDAO _instance;
        private PurchaseOrderDAO()
        {
        }
        public static PurchaseOrderDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PurchaseOrderDAO();
            }
            return _instance;
        }
        public List<PurchaseOrder> getAll(string patch)
        {
            List<PurchaseOrder> list_po = new List<PurchaseOrder>();
            int counter = 0;
            string line;
            PurchaseOrder po = new PurchaseOrder();
            // Read the file and display it line by line.
            try
            {
                Debug.Write("\n ======================        Load Purchase Orders        =======================\n");
                System.IO.StreamReader file =
                    new System.IO.StreamReader(patch);
                List<string> names = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    if (counter == 0)
                    {
                        counter++;
                    }
                    else if (counter == 1)
                    {
                        po = new PurchaseOrder(); names = new List<string>(); po.ID_order = int.Parse(line); counter++;
                    }
                    else if (counter == 2)
                    {
                        po.quant = int.Parse(line); counter++;
                    }
                    else if (counter > 2 && counter <= (po.quant + 2))
                    {
                        names.Add(line);
                        if ((po.quant + 2) == counter)
                        {
                            po.product_names = names;
                            list_po.Add(po);
                            names = null;
                            counter = 1;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                }

                file.Close();
            }
            catch (Exception e) {
                throw new Exception("\n xxxxxxxxxxxxxxxx  Error in load Purchase Order file: " + e + "   xxxxxxxxxxxxxxxxxxx\n");
            }

            return list_po;
        }

        public List<PurchaseOrder> getAll()
        {
            throw new NotImplementedException();
        }

        public PurchaseOrder GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(PurchaseOrder obj)
        {
            throw new NotImplementedException();
        }

        public bool remove(PurchaseOrder obj)
        {
            throw new NotImplementedException();
        }

        public bool update(PurchaseOrder obj)
        {
            throw new NotImplementedException();
        }
    }
}
