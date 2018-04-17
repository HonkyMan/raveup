using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaveUpSite.Models;
using RaveUpSite.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace RaveUpSite.Controllers
{
    public class MainController : Controller
    {

        IItemRepository repository;
        IConfiguration config;
        public int RatedItemCount { get; set; }
        public int NewItemCount { get; set; }

        public MainController(IItemRepository repo, IConfiguration conf)
        {
            repository = repo;
            config = conf;
            Initialize();
        }

        private void Initialize()
        {
            ViewBag.ControllerName = "Main";
            if (config != null)
            {
                RatedItemCount = Int32.Parse(config["Data:RatedItemsShowCount"]);
                NewItemCount = Int32.Parse(config["Data:NewItemsShowCount"]);
            }
        }

        public ViewResult Main()
        {
            MainPageModel model = new MainPageModel();
            model.TopRatedItems = repository.Items.OrderByDescending(i => i.Rating).Take(RatedItemCount).ToList();
            model.NewItems = repository.Items.OrderByDescending(i => i.CreatedDate).Take(NewItemCount).ToList();
            return View(model);
        }
    }
}
