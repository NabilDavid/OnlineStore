using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OnLineStore.Models;
using OnLineStore.Entities;

namespace OnLineStore.Repositories
{
    public class RepoDevice : IGeneric<Device>
    {
        private readonly taskDbContext _db;

        public RepoDevice( taskDbContext taskDbContext)
        {
            this._db = taskDbContext;
        }
        
        public Device Create(Device entity)
        {
            try
            {
                if (entity == null)
                {
                    return null;
                }

                _db.Devices.Add(entity);
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

                Device device = RetriveById(id);
                if (device == null)
                {
                    return false;
                }
                _db.Devices.Remove(device);
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

        public Device Patch(Device entity)
        {
            try
            {

                Device device = RetriveById(entity.deviceId);
                if (device == null)
                {
                    return null;
                }
                device.deviceName = entity.deviceName;
                device.categoryId = entity.categoryId;
                device.acquisitionDate = entity.acquisitionDate;
                device.memo = entity.memo;
                int affected = _db.SaveChanges();
                if (affected == 1)
                {
                    return device;
                }
                return null;

            }
            catch
            {
                return null;
            }
        }

        public List<Device> RetriveAll()
        {
            try
            {
                return _db.Devices.Include(c => c.Category).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Device RetriveById(int id)
        {
            try
            {
                return _db.Devices.Include(c => c.Category).Single(i => i.deviceId == id);
            }
            catch
            {
                return null;
            }
        }

    }
}
