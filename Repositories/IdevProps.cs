using OnLineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Repositories
{
    public interface IdevProps :IGeneric<DevProp>
    {
        bool CreateListDevProp(List<DevProp> devProps);
        List<DevProp> RetriveAll(int id);
        bool PatchDevProps(List<DevProp> devProps);
      


    }
}
