using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers
{
    public class HomeController : Controller
    {
       
        TodoContext db;
        public HomeController(TodoContext context)
        {
            db = context;
        }
        // Справочник дел 
        public IActionResult Index()
        {
            return View(db.Works.ToList());
        }

        [HttpGet]
        public IActionResult AddNewWork()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewWork(Work work)
        {
            db.Works.Add(work);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteWork(int? id)
        {
            if (id > 0)
            {
                var works = db.Works.Where(w => w.WorkId == id).ToList();
                foreach (var w in works)
                {
                    db.Works.Attach(w);
                    db.Works.Remove(w);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult UpdateWork(int? id)
        {
            if (id > 0)
            {
                var wUpdate = db.Works.Find(id);
                wUpdate.IsReady = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }




        // Справочник списка дел 
        public IActionResult WorkTypesList()
        {
            return View(db.WorkTypes.ToList());
        }

        [HttpGet]
        public IActionResult AddNewWorkType()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewWorkType(WorkType wt)
        {
            db.WorkTypes.Add(wt);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("WorkTypesList");
        }

        [HttpGet]
        public IActionResult DeleteWorkType(int? id)
        {
            if (id > 0)
            {
                var workTypes = db.WorkTypes.Where(w => w.WorkTypeId == id).ToList();
                foreach (var wt in workTypes)
                {
                    db.WorkTypes.Attach(wt);
                    db.WorkTypes.Remove(wt);
                }
                db.SaveChanges();
            }
            return RedirectToAction("WorkTypesList");
        }

    }
}
