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
    [Route("Projeto/{projetoId}/[controller]")]
    public class AtividadeController : Controller
    {
        public AtividadeController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }


        [HttpGet]
        [Route("Create")]
        public ActionResult Create(int projetoId)
        {
            var projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == projetoId);
            ViewBag.Projeto = projeto;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
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
                    return RedirectToAction("Details", "Projeto", new { Id = model.ProjetoId });
                }
                var projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == model.ProjetoId);
                ViewBag.Projeto = projeto;
                return View();
            }
            catch (Exception e)
            {
                var projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == model.ProjetoId);
                ViewBag.Projeto = projeto;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AtividadeEditView model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Details", "Projeto", new { ProjetoId = model.ProjetoId });
            }
            catch
            {
                return View();
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}