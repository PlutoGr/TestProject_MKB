using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetProject_1.Models;

namespace PetProject_1.Controllers
{
    public class HomeController : Controller
    {

        PortletContext db = new PortletContext();

        [HttpGet]
        public ActionResult Index()
        {
            SelectGlobalModulesPortlet portlet = new SelectGlobalModulesPortlet();
            portlet.GlobalModules = db.GlobalModules.Include(gm => gm.UsingUser).ToList();
            portlet.UsingUser = new SelectList(db.Users, "Id", "FullName");
            
            return View(portlet);
        }

        

        [HttpPost]
        public ActionResult Index(int usingUserId, List<SelectedGlobalModules> item)
        {
            User SelectedUser = db.Users.Find(usingUserId);

            foreach (SelectedGlobalModules gm in item.Where(g => g.Selected).ToList())
            {
                GlobalModule globalModule = db.GlobalModules.Find(gm.Id);
                globalModule.Selected = false;
                globalModule.UsingUser = SelectedUser;

                db.Entry(globalModule).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Index();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class SelectedGlobalModules
    {
        public int Id { get; set; }
        public bool Selected { get; set; }
    }
}