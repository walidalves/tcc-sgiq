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
            var parteInteressada = Context.ParteInteressada.Find(id);
            if(parteInteressada == null)
            {
                return BadRequest();
            }
            var piView = new ParteInteressadaEditView
            {
                Id = id,
                Nome = parteInteressada.Nome,
                Email = parteInteressada.Email,
                Telefone = parteInteressada.Telefone
            };
            return View(piView);
        }

        // POST: ParteInteressada/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParteInteressadaEditView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var parteInteressada = Context.ParteInteressada.Find(model.Id);
                    if(parteInteressada == null)
                    {
                        return BadRequest();
                    }

                    parteInteressada.Nome = model.Nome;
                    parteInteressada.Email = model.Email;
                    parteInteressada.Telefone = model.Telefone;           
                    Context.ParteInteressada.Update(parteInteressada);

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

        // GET: ParteInteressada/Delete/5
        public ActionResult Delete(int id)
        {
            var pi = Context.ParteInteressada.Find(id);
            if (pi == null)
            {
                return BadRequest();
            }
            Context.ParteInteressada.Remove(pi);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}