using OnLineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Repositories
{
   public interface IGeneric<T>
    {
        T RetriveById(int id);
        List<T> RetriveAll();
        T Create(T entity);
        T Patch(T entity);
        bool Delete(int id);
     

    }
}
