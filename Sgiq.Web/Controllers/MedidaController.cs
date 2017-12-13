using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Dados;
using Sgiq.Web.Models;
using Sgiq.Dados.Models;
using Microsoft.EntityFrameworkCore;

namespace Sgiq.Web.Controllers
{
    public class MedidaController : Controller
    {
        public MedidaController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        // GET: Medida
        public ActionResult Index()
        {
            var medidas = Context.Medida.Include(m => m.TipoDado).AsEnumerable();
            return View(medidas);
        }

        // GET: Medida/Create
        public ActionResult Create()
        {
            var tiposDados = Context.TipoDado.AsEnumerable();
            ViewBag.TiposDados = tiposDados;
            return View();
        }

        // POST: Medida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedidaView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var medida = new Medida
                    {
                        Nome = model.Nome,
                        TipoDado = Context.TipoDado.FirstOrDefault(td => td.TipoDadoId == model.TipoDadoId),
                        VlrMinimo = model.VlrMinimo,
                        VlrMaximo = model.VlrMaximo
                    };

                    Context.Medida.Add(medida);
                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                var tiposDados = Context.TipoDado.AsEnumerable();
                ViewBag.TiposDados = tiposDados;
                return View();
            }
            catch
            {
                var tiposDados = Context.TipoDado.AsEnumerable();
                ViewBag.TiposDados = tiposDados;
                return View();
            }
        }

        // GET: Medida/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medida/Edit/5
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

        // GET: Medida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medida/Delete/5
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