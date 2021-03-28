using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Shopping.Model
{
    interface I_DAO <T>
    {
        public bool insert(T obj);
        public bool remove(T obj);
        public T GetItem(int id);

        public bool update(T obj);

        public List<T> getAll();
    }
}
