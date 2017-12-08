using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Web.Models;
using Sgiq.Dados.Models;
using Sgiq.Dados;

namespace Sgiq.Web.Controllers
{
    public class ParteInteressadaController : Controller
    {
        public ParteInteressadaController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        // GET: ParteInteressada
        public ActionResult Index()
        {
            return View(Context.ParteInteressada.AsEnumerable());
        }        // GET: ParteInteressada/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParteInteressada/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParteInteressadaView pi)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ParteInteressadaView parteInteressada = new ParteInteressadaView();
                    parteInteressada.Nome = pi.Nome;
                    parteInteressada.Email = pi.Email;
                    parteInteressada.Telefone = pi.Telefone;
                    var parteInteressadaBd = new ParteInteressada { Nome = parteInteressada.Nome, Email = parteInteressada.Email, Telefone = parteInteressada.Telefone };
                    Context.ParteInteressada.Add(parteInteressadaBd);

                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ParteInteressada/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParteInteressada/Edit/5
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

        // GET: ParteInteressada/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParteInteressada/Delete/5
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