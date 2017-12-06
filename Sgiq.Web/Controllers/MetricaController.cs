using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sgiq.Web.Controllers
{
    public class MetricaController : Controller
    {
        // GET: Metrica
        public ActionResult Index()
        {
            return View();
        }

        // GET: Metrica/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Metrica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Metrica/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Metrica/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Metrica/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Metrica/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Metrica/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}