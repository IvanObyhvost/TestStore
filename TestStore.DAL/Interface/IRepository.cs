using System;
using System.Collections.Generic;

namespace TestStore.Core.Repository
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate ); 
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}