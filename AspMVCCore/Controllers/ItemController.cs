﻿using AspMVCCore.Data;
using AspMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCCore.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item _item)
        {
            _db.Items.Add(_item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
