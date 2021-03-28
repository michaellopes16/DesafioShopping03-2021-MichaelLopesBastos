using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Desafio_Shopping.Model
{
    public class ProductDAO: I_DAO<Product>
    {
        private static ProductDAO _instance;
        private ProductDAO()
        {
            //getAll(@"C:\Users\michael.bastos\source\repos\Desafio_Shopping\Desafio_Shopping\repository_txt\Product_list.txt");
        }
        public static ProductDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductDAO();
            }
            return _instance;
        }
        public List<Product> getAll(string patch)
        {
            List<Product> list_p = new List<Product>();
            int counter = 0;
            string line;
            int n = 0;
            Product p = new Product();
            // Read the file and display it line by line.
            try
            {
                Debug.Write("\n ======================        Load Product List        =======================\n");
                System.IO.StreamReader file =
                    new System.IO.StreamReader(patch);
                while ((line = file.ReadLine()) != null)
                {
                    switch (counter)
                    {
                        case 0: n = int.Parse(line); counter++; break;
                        case 1: p = new Product(); p.product_name = line; counter++; break;
                        case 2: p.product_price = int.Parse(line); list_p.Add(p); counter = 1; break;
                    }
                }

                file.Close();
            }
            catch (Exception e) {
                throw new Exception("\n xxxxxxxxxxxxxxxx  Error in load products file: " + e + "  - Verify the order format  xxxxxxxxxxxxxxxxxxx\n");
            }
            return list_p;
        }

        public List<Product> getAll()
        {
            throw new NotImplementedException();
        }

        public Product GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Product obj)
        {
            throw new NotImplementedException();
        }

        public bool remove(Product obj)
        {
            throw new NotImplementedException();
        }

        public bool update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
