using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DbService db= new DbService();
        public ActionResult Index()
        {
            return View(db.GetData());
        }
        public ActionResult Delete(int id)
        {
            var rowData = db.GetData().Find(model => model.ID == id);
            return View(rowData);
        }
        [HttpPost]
        public ActionResult Delete(EmpModel obj)
        {
           
                db.Delete(obj);
                return RedirectToAction("Index");
           
        }

        public ActionResult Details(int id)
        {
            var rowData = db.GetData().Find(model => model.ID == id);
            return View(rowData);
        }
        [HttpPost]
        public ActionResult Details(EmpModel obj)
        {

            db.Details(obj);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var rowData = db.GetData().Find(model => model.ID == id);
            return View(rowData);
        }
        [HttpPost]
        public ActionResult Edit(EmpModel obj)
        {
            if (ModelState.IsValid == true)
            {
                db.Update(obj);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DeleteMsg = "<script>alert('something went wrong')</script>";
            }
            return View();
        }


        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(EmpModel e)
        {
            if (ModelState.IsValid == true) 
            {
                db.Add(e);
                if (db != null)
                {
                    ViewBag.AddMsg = "<script>alert('something went wrong')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.AddMsg = "<script>alert('Data Saved Successfully')</script>";
                }
               
            }    
           return View();        
        }

      
    }
}