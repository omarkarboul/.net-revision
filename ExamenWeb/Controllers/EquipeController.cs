using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWeb.Controllers
{
    public class EquipeController : Controller
    {
        IServiceEquipe se;

        public EquipeController(IServiceEquipe se)
        {
            this.se = se;
        }
        // GET: EquipeController
        public ActionResult Index()
        {
            return View(se.GetMany());
        }

        // POST: EquipeController
        [HttpPost]
        public ActionResult Index(String filter)
        {
            return View(se.GetMany(e=>e.NomEquipe.Contains(filter)));
        }

        // GET: EquipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipe collection, IFormFile file)
        {
            try
            {
                //image upload
                collection.Logo = file.FileName;
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                   file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                //simple add
                se.Add(collection);
                se.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
