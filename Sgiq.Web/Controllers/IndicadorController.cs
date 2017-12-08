using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Dados;

namespace Sgiq.Web.Controllers
{
    public class IndicadorController : Controller
    {
        // GET: Indicador
        public IndicadorController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        // GET: Atividade
        public ActionResult Index()
        {
            return View(Context.Indicador.AsEnumerable());
        }        // GET: Indicador/Create

        // GET: Indicador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indicador/Create
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

        // GET: Indicador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indicador/Edit/5
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

        // GET: Indicador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indicador/Delete/5
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