using OnLineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Repositories
{
   public interface ICatProp :IGeneric<CatProp>
    {
        List<CatProp> GetAllCatProps(int id);
    }
}
