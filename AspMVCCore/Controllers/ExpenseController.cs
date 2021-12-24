using AspMVCCore.Data;
using AspMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCCore.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense _Expense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(_Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_Expense);
        }
    }
}
