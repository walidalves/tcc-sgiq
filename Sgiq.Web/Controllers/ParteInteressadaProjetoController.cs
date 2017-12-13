using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Web.Models;
using Sgiq.Dados;
using Sgiq.Dados.Models;

namespace Sgiq.Web.Controllers
{
    [Route("Projeto/{projetoId}/[controller]")]
    public class ParteInteressadaProjetoController : Controller
    {
        public ParteInteressadaProjetoController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create(int projetoId)
        {
            var projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == projetoId);
            var parteInteressadas = Context.ParteInteressada.AsEnumerable();
            var papeis = Context.Papel.AsEnumerable();

            ViewBag.Projeto = projeto;
            ViewBag.Papeis = papeis;
            ViewBag.PartesInteressadas = parteInteressadas;
            return View();
        }

        // POST: ParteInteressadaProjeto/Create
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParteInteressadaProjetoView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var parteInteressadaProjeto = new ParteInteressadaProjeto
                    {
                        Projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == model.ProjetoId),
                        ParteInteressada = Context.ParteInteressada.FirstOrDefault(pi => pi.ParteInteressadaId == model.ParteInteressadaId),
                        Papel = Context.Papel.FirstOrDefault(p => p.PapelId == model.PapelId)
                    };

                    Context.ParteInteressadaProjeto.Add(parteInteressadaProjeto);

                    Context.SaveChanges();
                    return RedirectToAction("Details", "Projeto", new { Id = model.ProjetoId });
                }

                var projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == model.ProjetoId);
                var parteInteressadas = Context.ParteInteressada.AsEnumerable();
                var papeis = Context.Papel.AsEnumerable();

                ViewBag.Projeto = projeto;
                ViewBag.Papeis = papeis;
                ViewBag.PartesInteressadas = parteInteressadas;
                return View();
            }
            catch
            {
                var projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == model.ProjetoId);
                var parteInteressadas = Context.ParteInteressada.AsEnumerable();
                var papeis = Context.Papel.AsEnumerable();

                ViewBag.Projeto = projeto;
                ViewBag.Papeis = papeis;
                ViewBag.PartesInteressadas = parteInteressadas;
                return View();
            }
        }

        // GET: ParteInteressadaProjeto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: ParteInteressadaProjeto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}