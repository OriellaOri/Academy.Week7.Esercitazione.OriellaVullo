using System;
using System.Collections.Generic;

namespace Academy.Week7.Esercitazione.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Fetch(Func<T, bool> filter = null);
        T GetByID(int id);
        bool Add(T newItem);
        bool Update(T updatedItem);
        bool DeleteById(int id);
    }
}