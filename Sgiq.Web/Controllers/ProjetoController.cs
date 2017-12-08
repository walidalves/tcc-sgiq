using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sgiq.Dados;
using Sgiq.Dados.Models;
using Sgiq.Web.Models;
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
            return View(Context.Projeto.AsEnumerable());
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

                    Context.Projeto.Add(projeto);
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