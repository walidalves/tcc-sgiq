using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Dados;

namespace Sgiq.Web.Controllers
{
    public class RequisitoController : Controller
    {
        public RequisitoController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        // GET: Projeto
        public ActionResult Index()
        {
            return View(Context.Requisito.AsEnumerable());
        }

        // GET: Requisito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Requisito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requisito/Create
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

        // GET: Requisito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Requisito/Edit/5
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

        // GET: Requisito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Requisito/Delete/5
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