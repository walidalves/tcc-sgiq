using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgiq.Dados;
using Sgiq.Web.Models;

namespace Sgiq.Web.Controllers
{
    public class MetricaController : Controller
    {
        public MetricaController(SGIQContext context)
        {
            Context = context;
        }

        private SGIQContext Context { get; set; }

        // GET: Atividade
        public ActionResult Index()
        {
            return View(Context.Metrica.AsEnumerable());
        }

        // GET: Metrica/Create
        public ActionResult Create()
        {
            ViewBag.MedidasMetricas = new List<MedidaMetricaView>();
            ViewBag.Medidas = Context.Medida.AsEnumerable();
            ViewBag.FrequenciasAfericao = Context.FrequenciaAfericao.AsEnumerable();
            return View();
        }

        // POST: Metrica/Create
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

        // GET: Metrica/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Metrica/Edit/5
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

        // GET: Metrica/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Metrica/Delete/5
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

        [HttpPost]
        public ActionResult AddMedida(IFormCollection collection)
        {
            var medidas = collection["Medidas"];
            int medidaId = int.Parse(collection["MedidaId"]);
            var list = new List<MedidaMetricaView>();
            var medidaMetricaView = new MedidaMetricaView { MedidaId = medidaId };
            var medida = Context.Medida.Find(medidaId);
            medidaMetricaView.Nome = medida.Nome;
            list.Add(medidaMetricaView);

            foreach (var m in medidas)
            {
                medidaId = int.Parse(m);
                medida = Context.Medida.Find(medidaId);
                medidaMetricaView = new MedidaMetricaView { MedidaId = medidaId, Nome = medida.Nome };
                list.Add(medidaMetricaView);
            }
            
            return Json(list);
        }
    }
}