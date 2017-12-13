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
    public class RequisitoController : Controller
    {
        public RequisitoController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }


        [HttpGet]
        [Route("Create")]
        public ActionResult Create(int projetoId)
        {
            var projeto = Context.Projeto.Include(p => p.Requisitos).FirstOrDefault(p => p.ProjetoId == projetoId);
            var tiposRequisitos = Context.TipoRequisito.AsEnumerable();
            if (projeto == null)
            {
                return BadRequest();
            }
            ViewBag.Projeto = projeto;
            ViewBag.TiposRequisito = tiposRequisitos;
            return View();
        }


        // POST: Requisito/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create(RequisitoView model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var requisito = new Requisito { Descricao = model.Descricao, DtInclusao = DateTime.Now };
                    requisito.TipoRequisito = Context.TipoRequisito.FirstOrDefault(tr => tr.TipoRequisitoId == model.TipoRequisitoId);
                    requisito.Projeto = Context.Projeto.FirstOrDefault(p => p.ProjetoId == model.ProjetoId);
                    Context.Requisito.Add(requisito);

                    Context.SaveChanges();
                    return RedirectToAction("Details", "Projeto", new { Id = model.ProjetoId });
                }
                var tiposRequisitos = Context.TipoRequisito.AsEnumerable();
                return View();
            }
            catch
            {
                var tiposRequisitos = Context.TipoRequisito.AsEnumerable();
                return View();
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Requisito/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, RequisitoEditView model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Details","Projeto", new { ProjetoId = model.ProjetoId});
            }
            catch
            {
                return View();
            }
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}