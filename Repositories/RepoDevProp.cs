using Microsoft.EntityFrameworkCore;
using OnLineStore.Entities;
using OnLineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Repositories
{
    public class RepoDevProp : IdevProps
    {
        private readonly taskDbContext _db;

        public RepoDevProp(taskDbContext taskDbContext)
        {
            this._db = taskDbContext;
        }
        public DevProp Create(DevProp entity)
        {
            throw new NotImplementedException();
        }

        public bool CreateListDevProp(List<DevProp> devProps)
        {
            var flag = false;
            foreach (var item in devProps)
            {
                _db.devProps.Add(item);
                _db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DevProp Patch(DevProp entity)
        {
            throw new NotImplementedException();
        }

        public List<DevProp> RetriveAll()
        {
            throw new NotImplementedException();
        }

        public List<DevProp> RetriveAll(int id)
        {
            var listProp = _db.devProps.Include(x=>x.property).Where(x => x.deviceId == id).ToList();
            return listProp;
        }
        public bool PatchDevProps(List<DevProp> devProps)
        {
            try
            {

                foreach (var item in devProps)
                {
                    _db.devProps.Update(item);
                    _db.SaveChanges();
                    
                }
                return true;
            }
            catch 
            {

                return false;
            }
        }
        public DevProp RetriveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
