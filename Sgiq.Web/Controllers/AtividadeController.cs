using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Dados;

namespace Sgiq.Web.Controllers
{
    public class AtividadeController : Controller
    {
        public AtividadeController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        // GET: Atividade
        public ActionResult Index()
        {
            return View(Context.Atividade.AsEnumerable());
        }        // GET: Atividade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atividade/Create
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

        // GET: Atividade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Atividade/Edit/5
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

        // GET: Atividade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Atividade/Delete/5
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