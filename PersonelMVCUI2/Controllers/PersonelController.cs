using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelMVCUI2.Models.EntityFramework;
using PersonelMVCUI2.ViewModels;

namespace PersonelMVCUI2.Controllers
{   


    public class PersonelController : Controller
    {

        PersonelManagementEntities db = new PersonelManagementEntities();
        MesajViewModel model2 = new MesajViewModel();
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
        }


        [Authorize (Roles ="A")]
        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new Personel()
            };
            return View("PersonelForm", model);
        }           


        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };

                return View("PersonelForm",model);
            }

            

            if (personel.Id == 0)
            {
                db.Personel.Add(personel);
                model2.Mesaj = personel.Ad +" "+personel.Soyad+ " başarıyla eklendi";

            }
            else
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            model2.Status = true;
            model2.LinkText = "Personel Listesi";
            model2.Url = "/Personel";
            return View("_Mesaj",model2);

        }

        public ActionResult Guncelle (int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);

        }

        public ActionResult Sil (int id)
        {
            var silinecekPersonel = db.Personel.Find(id);

            if(silinecekPersonel == null)
            {
                return HttpNotFound();
            }

            db.Personel.Remove(silinecekPersonel);
            model2.Mesaj = silinecekPersonel.Ad + " " + silinecekPersonel.Soyad + " başarıyla silindi";
            db.SaveChanges();
            model2.Status = true;
            model2.LinkText = "Personel Listesi";
            model2.Url = "/Personel";
            return View("_Mesaj", model2);

        }

        public ActionResult PersonelleriListele(int id)
        {
            var model = db.Personel.Where(x => x.DepartmanId == id).ToList();
            return PartialView(model);
        }

    }
}

    