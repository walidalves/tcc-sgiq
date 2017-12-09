using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sgiq.Dados;
using Sgiq.Dados.Models;
using Sgiq.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sgiq.Web.Controllers
{
    public class ProjetoController : Controller
    {
        public ProjetoController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        // GET: Projeto
        public ActionResult Index()
        {
            var projetos = Context.Projeto.Include(p => p.SituacaoProjeto).AsEnumerable();
            return View(projetos);
        }

        // GET: Projeto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Projeto/Create
        public ActionResult Create()
        {
            var partesInteressadas = Context.ParteInteressada.AsEnumerable();
            ViewBag.PartesInteressadas = partesInteressadas;
            return View();
        }

        // POST: Projeto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjetoView p)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    
                    var projeto = new Projeto
                    {
                        Nome = p.Nome,
                        Descricao = p.Descricao,
                        DtInicioPrevista = p.DtInicioPrevisto,
                        DtTerminoPrevista = p.DtTFimPrevisto,
                        CustoEstimado = p.CustoEstimado                        
                    };

                    projeto.SituacaoProjeto = Context.SituacaoProjeto.Where(sp => sp.Nome.ToLower() == "iniciado").FirstOrDefault();

                    projeto = Context.Projeto.Add(projeto).Entity;

                    //Adicionando cliente
                    ParteInteressadaProjeto cliente = new ParteInteressadaProjeto { Projeto = projeto };
                    cliente.ParteInteressada = Context.ParteInteressada.Where(pi => pi.ParteInteressadaId == p.ClienteId).FirstOrDefault();
                    cliente.Papel = Context.Papel.Where(pap => pap.Nome.ToLower() == "cliente").FirstOrDefault();

                    //Adicionar Gerente de Projetos
                    ParteInteressadaProjeto gerenteProjetos = new ParteInteressadaProjeto { Projeto = projeto };
                    gerenteProjetos.ParteInteressada = Context.ParteInteressada.Where(pi => pi.ParteInteressadaId == p.GerenteProjetoId).FirstOrDefault();
                    gerenteProjetos.Papel = Context.Papel.Where(pap => pap.Nome.ToLower() == "gerente de projetos").FirstOrDefault();

                    Context.ParteInteressadaProjeto.AddRange(cliente, gerenteProjetos);

                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                var partesInteressadas = Context.ParteInteressada.AsEnumerable();
                ViewBag.PartesInteressadas = partesInteressadas;
                return View();
            }
            catch(Exception e)
            {
                var partesInteressadas = Context.ParteInteressada.AsEnumerable();
                ViewBag.PartesInteressadas = partesInteressadas;
                return View();
            }
        }

        // GET: Projeto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projeto/Edit/5
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

        // GET: Projeto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Projeto/Delete/5
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

        [Route("{id}/PartesInteressadas")]
        [HttpGet]
        public ActionResult PartesInteressadas(int id)
        {
            return View();
        }
    }
}