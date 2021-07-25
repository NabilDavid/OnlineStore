using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using OnLineStore.Models;
using OnLineStore.Entities;

namespace OnLineStore.Repositories
{
    public class RepoCategory : IGeneric<Category>
    {
        private readonly taskDbContext _db;

        public RepoCategory(taskDbContext taskDbContext)
        {
            this._db = taskDbContext;
        }

        public Category Create(Category entity)
        {
            try
            {
                if (entity == null)
                {
                    return null;
                }

                _db.categories.Add(entity);
                int affected = _db.SaveChanges();

                if (affected == 1)
                {
                    return entity;
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                Category category = RetriveById(id);
                if (category == null)
                {
                    return false;
                }
                _db.categories.Remove(category);
                int affected = _db.SaveChanges();

                if (affected == 1)
                {
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }

        public Category Patch(Category entity)
        {
            try
            {

                Category category = RetriveById(entity.categoryId);
                if (category == null)
                {
                    return null;
                }
                category.categoryName = entity.categoryName;
                int affected = _db.SaveChanges();
                if (affected == 1)
                {
                    return category;
                }
                return null;

            }
            catch
            {
                return null;
            }
        }

        public List<Category> RetriveAll()
        {
            try
            {
                return _db.categories.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Category RetriveById(int id)
        {
            try
            {
                return _db.categories.Single(i => i.categoryId == id);
            }
            catch
            {
                return null;
            }
        }

    }
}
