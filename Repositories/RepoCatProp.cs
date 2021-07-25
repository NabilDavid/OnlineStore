using OnLineStore.Entities;
using System;
using System.Collections.Generic;
using OnLineStore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnLineStore.Repositories
{
    public class RepoCatProp : ICatProp
    {
        private readonly taskDbContext _db;
        public RepoCatProp(taskDbContext taskDbContext)
        {
            this._db = taskDbContext;
        }
        public CatProp Create(CatProp entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CatProp Patch(CatProp entity)
        {
            throw new NotImplementedException();
        }

        public List<CatProp> RetriveAll()
        {
            throw new NotImplementedException();
        }

        public CatProp RetriveById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CatProp> GetAllCatProps(int id)
        {
            return _db.catProps.Include(y=>y.property).Where(x => x.categoryId == id).ToList();
        }
    }
}
