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
        }

        public ViewResult List() => View(repository.Items);
    }
}
