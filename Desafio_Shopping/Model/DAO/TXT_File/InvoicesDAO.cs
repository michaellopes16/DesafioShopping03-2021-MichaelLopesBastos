using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Desafio_Shopping.Model.DAO.TXT_File
{
    public class InvoicesDAO: I_DAO<Invoices>
    {
        private static InvoicesDAO _instance;
        private InvoicesDAO()
        {
        }
        public static InvoicesDAO GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InvoicesDAO();
            }
            return _instance;
        }
        public async Task createFullInvoice(String invoices, string patch) {
            try
            {
                await File.WriteAllTextAsync(patch, invoices);
            }
            catch (Exception e) {
                throw new Exception("Erro ao escrever arquivo:"+e);
            }
        }

        public List<Invoices> getAll()
        {
            throw new NotImplementedException();
        }

        public Invoices GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public static async Task Insert(Invoices obj)
        {
            try
            {
                using StreamWriter file = new StreamWriter("invoices.txt", append: true);
                await file.WriteLineAsync("Fourth line");
            }
            catch (Exception e) {
                throw new Exception("Error in create invoices"+e);
            }
        }

        public bool remove(Invoices obj)
        {
            throw new NotImplementedException();
        }

        public bool update(Invoices obj)
        {
            throw new NotImplementedException();
        }

        public bool insert(Invoices obj)
        {
            throw new NotImplementedException();
        }
    }
}
