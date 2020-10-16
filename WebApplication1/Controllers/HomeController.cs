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
        TofaelAhmedEntities4 db = new TofaelAhmedEntities4();
        public ActionResult Index()
        {
            ViewBag.Message = "lorem site with web applicaton on windowns 10.";
            return View();
        }
        [HttpPost]
        public ActionResult Index(contact model)
        {
            contact tbl = new contact();
            tbl.fullname = model.fullname;
            tbl.email = model.email;
            tbl.subject = model.subject;
            tbl.messege = model.messege;
            db.contact.Add(tbl);
            db.SaveChanges();
            return View();
        }
        public ActionResult showcontent()
        {
            var item = db.contact.ToList();
            return View(item);
        }
        public ActionResult Delete(int id)
        {
            var item = db.contact.Where(x => x.id == id).First();
            db.contact.Remove(item);
            db.SaveChanges();
            var item2 = db.contact.ToList();
            return View("showcontent", item2);
        }
        public ActionResult Edit(int id)
        {
            var item = db.contact.Where(x => x.id == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(contact model)
        {
            var item = db.contact.Where(x => x.id == model.id).First();
            item.fullname = model.fullname;
            item.email = model.email;
            item.subject = model.subject;
            item.messege = model.messege;
            db.SaveChanges();
            return View(item);
        }
    }
}