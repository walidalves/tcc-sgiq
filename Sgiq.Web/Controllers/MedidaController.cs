using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sgiq.Web.Controllers
{
    public class MedidaController : Controller
    {
        // GET: Medida
        public ActionResult Index()
        {
            return View();
        }

        // GET: Medida/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medida/Create
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

        // GET: Medida/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medida/Edit/5
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

        // GET: Medida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medida/Delete/5
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