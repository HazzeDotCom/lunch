using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Lunchsajten.Controllers
{ 
    public class CompanyController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Company/

        public ViewResult Index()
        {
            return View(db.Companies.ToList());
        }

        //
        // GET: /Company/Details/5

        public ViewResult Details(long id)
        {
            Company company = db.Companies.Find(id);
            return View(company);
        }

        //
        // GET: /Company/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Company/Create

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(company);
        }
        
        //
        // GET: /Company/Edit/5
 
        public ActionResult Edit(long id)
        {
            Company company = db.Companies.Find(id);
            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //
        // GET: /Company/Delete/5
 
        public ActionResult Delete(long id)
        {
            Company company = db.Companies.Find(id);
            return View(company);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}