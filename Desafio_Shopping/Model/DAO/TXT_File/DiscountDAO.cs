using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Desafio_Shopping.Model
{
    public class DiscountDAO : I_DAO<Discount>
    {
        private static DiscountDAO _instance;
        private DiscountDAO()
        {
        }
        public static DiscountDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DiscountDAO();
            }
            return _instance;
        }

        public List<Discount> getAll(string patch)
        {
            List<Discount> list_d = new List<Discount>();
            int counter = 0;
            string line;
            int n;
            Discount d = new Discount();
            // Read the file and display it line by line.  
            try
            {
                Debug.Write("\n ======================        Load Products Discount        =======================\n");
                System.IO.StreamReader file =
                    new System.IO.StreamReader(patch);
                while ((line = file.ReadLine()) != null)
                {
                    switch (counter)
                    {
                        case 0: n = int.Parse(line); counter++; break;
                        case 1: d = new Discount(); d.product_name = line; counter++; break;
                        case 2: d.take = int.Parse(line); counter++; break;
                        case 3: d.pay = int.Parse(line); list_d.Add(d); d = new Discount(); counter = 1; break;
                    }
                }

                file.Close();
            }
            catch (Exception e) {
                throw new Exception("\n xxxxxxxxxxxxxxxx  Error in load discount file: " + e + "   xxxxxxxxxxxxxxxxxxx\n");
            }

            return list_d;
        }
        public List<Discount> getAll()
        {
            throw new NotImplementedException();
        }

        public Discount GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Discount obj)
        {
            throw new NotImplementedException();
        }

        public bool remove(Discount obj)
        {
            throw new NotImplementedException();
        }

        public bool update(Discount obj)
        {
            throw new NotImplementedException();
        }
    }
}
