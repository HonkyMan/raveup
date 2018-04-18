using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaveUpSite.Models;

namespace RaveUpSite.Controllers
{
    public class ItemController : Controller
    {
        
        private IItemRepository repository;
        public ItemController(IItemRepository repo)
        {
            repository = repo;
            Initialize();
        }
        private void Initialize()
        {
            ViewBag.ControllerName = "Item";
        }

        public ViewResult List() => View(repository.Items);

        public ViewResult GetOne(int itemId) => View(repository.Items.FirstOrDefault(i => i.ItemID == itemId));


    }
}
