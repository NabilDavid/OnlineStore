using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnLineStore.Entities;
using OnLineStore.Repositories;
using OnLineStore.DevCatVM;


namespace OnLineStore.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IGeneric<Device> _repo;
        private readonly IGeneric<Category> _repoCategory;
        private readonly ICatProp _repoCatProps;
        private readonly IdevProps _repoDevProp;

        public DevicesController(IGeneric<Device> repo , IGeneric<Category> repoCategory, ICatProp repoCatProps , IdevProps repoDevProp) 
        {
            _repo = repo;
            _repoCategory = repoCategory;
            _repoCatProps = repoCatProps;
            _repoDevProp = repoDevProp;
        }

        // GET: Devices
        public IActionResult Index()
        {
            var devices = _repo.RetriveAll();
            return View(devices);
        }

        public List<CatProp> GetCatProps(int id)
        {
            var catprop = _repoCatProps.GetAllCatProps(id);

            return catprop ;
        }


        // GET: Devices/Details/5
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var devprop = _repoDevProp.RetriveAll(id);
            var device = _repo.RetriveById(id);
            DeviceCategoryVM model = new DeviceCategoryVM
            {
                device = device,
                devProps = devprop
            };


            if (device == null)
            {
                return NotFound();
            }
            ViewData["categoryId"] = new SelectList(_repoCategory.RetriveAll(), "categoryId", "categoryName", device.categoryId);

            return View(model);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_repoCategory.RetriveAll(), "categoryId", "categoryName");
          
            return View();
        }
        [HttpPost]
        //string Name, DateTime Date, string memo, int Id
        public Device CreateDevice(Device device)
        {
           var _device = _repo.Create(device);
           return _device;
        }
        [HttpPost]
        public bool CreateDeviceProp(List<DevProp> devProps)
        {
            bool effected = _repoDevProp.CreateListDevProp(devProps);
            return effected;
        }
       
        // GET: Devices/Edit/5
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var devprop = _repoDevProp.RetriveAll(id); 
            var device = _repo.RetriveById(id);
            DeviceCategoryVM model = new DeviceCategoryVM
            {
                device = device ,
                devProps = devprop
            };
                

            if (device == null)
            {
                return NotFound();
            }
            ViewData["categoryId"] = new SelectList(_repoCategory.RetriveAll(), "categoryId", "categoryName", device.categoryId);
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, DeviceCategoryVM model)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Patch(model.device);
                    _repoDevProp.PatchDevProps(model.devProps);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
            }
            ViewData["categoryId"] = new SelectList(_repoCategory.RetriveAll(), "categoryId", "categoryName", model.device.categoryId);
            return View();
        }

        // GET: Devices/Delete/5
        public  IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var devprop = _repoDevProp.RetriveAll(id);
            var device = _repo.RetriveById(id);
            DeviceCategoryVM model = new DeviceCategoryVM
            {
                device = device,
                devProps = devprop
            };
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
