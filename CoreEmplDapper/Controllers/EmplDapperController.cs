using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;  
using CoreEmplDapper.Models;
using Microsoft.Data.SqlClient;

namespace CoreEmplDapper.Controllers
{
    public class EmplDapperController : Controller
    {


        IEmplRepository repo;
        public EmplDapperController(IEmplRepository r)
        {
            repo = r;
        }

        public ActionResult Index()
        {
            return View(repo.GetEmpls());
        }
 
        public ActionResult Details(int id)
        {
            Empl empl = repo.Get(id);
            if (empl != null)
                return View(empl);
            return NotFound();
        }
 
        public ActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult Create(Empl user)
        {
            repo.Create(user);
            return RedirectToAction("Index");
        }
 
        public ActionResult Edit(int id)
        {
            Empl empl = repo.Get(id);
            if (empl != null)
                return View(empl);
            return NotFound();
        }
 
        [HttpPost]
        public ActionResult Edit(Empl empl)
        {
            repo.Update(empl);
            return RedirectToAction("Index");
        }
 
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Empl empl = repo.Get(id);
            if (empl != null)
                return View(empl);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
        
        //---------------------

    }
}