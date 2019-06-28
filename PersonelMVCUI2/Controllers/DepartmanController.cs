using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelMVCUI2.Models.EntityFramework;
using PersonelMVCUI2.ViewModels;

namespace PersonelMVCUI2.Controllers
{

    public class DepartmanController : Controller
    {
        PersonelManagementEntities db = new PersonelManagementEntities();

        MesajViewModel model = new MesajViewModel();


        public ActionResult Index()
        {
            var model = db.Departman.ToList(); 
            return View(model);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm", new Departman());
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }

            if(departman.Id == 0)
            {
                db.Departman.Add(departman);
                model.Mesaj = departman.Ad +" departmanı başarıyla eklendi";
            }
            else
            {
                var guncellenecekDepartman = db.Departman.Find(departman.Id);
                if(guncellenecekDepartman == null)
                {
                    return HttpNotFound();
                }

                guncellenecekDepartman.Ad = departman.Ad;
                model.Mesaj = departman.Ad + " departmanı başarıyla güncellendi";
            }
            db.SaveChanges();
            model.Status = true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departman";

            return View("_Mesaj", model);
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm",model);
        }

        public ActionResult Sil(int id)
        {
            Departman silinecekDepartman = db.Departman.Find(id);
            if(silinecekDepartman == null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            model.Status = true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departman";
            return View("_Mesaj", model);
        }
    }
}