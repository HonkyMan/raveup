using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RaveUpSite.Models.ViewModels;
using RaveUpSite.Models;

namespace RaveUpSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IItemRepository repository;

        public AdminController(IItemRepository repo)
        {
            repository = repo;
        }

        public ViewResult Items()
        {
            return View(repository.Items);
        }

        public ViewResult Edit(int itemId)
        {
            return View(repository.Items.FirstOrDefault(i => i.ItemID == itemId));
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                repository.SaveItem(item);
                return RedirectToAction("Items");
            }
            else return View(item);
        }

        
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                repository.CreateItem(item);
                return RedirectToAction("Items");
            }
            else return View(item);
        }

        public IActionResult Delete(int itemId)
        {
            repository.DeleteItem(itemId);
            return RedirectToAction("Items");
        }


    }
}
