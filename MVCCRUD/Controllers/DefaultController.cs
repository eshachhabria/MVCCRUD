using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class DefaultController : Controller
    {
        MVC_DBEntities1 _context = new MVC_DBEntities1();
        // GET: Default
        public ActionResult Index()
        {
            var ListOfData = _context.Students.ToList();
            return View(ListOfData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.message = "Data Inserterd Sucessfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student model) 
        {
            var data = _context.Students.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = model.StudentCity;
                data.StudentName = model.StudentName;
                data.StudentFees = model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Details(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.message = "Record Deleted Successfully ";
            return RedirectToAction("Index");
        }
       

    }
}