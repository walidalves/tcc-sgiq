using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Dados;
using Microsoft.EntityFrameworkCore;
using Sgiq.Web.Models;
using Sgiq.Dados.Models;

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
            var atividades = Context.Atividade.Include(a => a.Projeto).AsEnumerable();
            return View(atividades);
        }        // GET: Atividade/Create
        public ActionResult Create()
        {
            var projetos = Context.Projeto.AsEnumerable();
            ViewBag.Projetos = projetos;
            return View();
        }

        // POST: Atividade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AtividadeView model)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {

                    var atividade = new Atividade
                    {
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        DtInicioPrevista = model.DtInicio,
                        DtTerminoPrevista = model.DtFim
                    };

                    atividade.Projeto = Context.Projeto.Where(p => p.ProjetoId == model.ProjetoId).FirstOrDefault();
                    Context.Atividade.Add(atividade);

                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                var projetos = Context.Projeto.AsEnumerable();
                ViewBag.Projetos = projetos;
                return View();
            }
            catch (Exception e)
            {
                var projetos = Context.Projeto.AsEnumerable();
                ViewBag.Projetos = projetos;
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