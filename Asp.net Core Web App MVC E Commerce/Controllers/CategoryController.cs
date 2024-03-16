﻿using Asp.net_Core_Web_App_MVC_E_Commerce.Data;
using Asp.net_Core_Web_App_MVC_E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_App_MVC_E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Category.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj){

            if(ModelState.IsValid)
            {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
            
            
        }

    }
}
