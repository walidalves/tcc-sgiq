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
            var metricas = Context.Metrica.Include(m => m.FrequenciaAfericao).AsEnumerable();
            return View(metricas);
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
        public ActionResult Create(MetricaView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metrica = new Metrica
                    {
                        FrequenciaAfericaoId = model.FrequenciaAfericaoId,
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        Formula = model.Formula
                    };
                    Context.Metrica.Add(metrica);
                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.MedidasMetricas = new List<MedidaMetricaView>();
                ViewBag.Medidas = Context.Medida.AsEnumerable();
                ViewBag.FrequenciasAfericao = Context.FrequenciaAfericao.AsEnumerable();
                return View();
            }
            catch
            {
                ViewBag.MedidasMetricas = new List<MedidaMetricaView>();
                ViewBag.Medidas = Context.Medida.AsEnumerable();
                ViewBag.FrequenciasAfericao = Context.FrequenciaAfericao.AsEnumerable();
                return View();
            }
        }

        // GET: Metrica/Edit/5
        public ActionResult Edit(int id)
        {
            var metrica = Context.Metrica.Find(id);
            if (metrica == null)
            {
                return BadRequest();
            }
            ViewBag.MedidasMetricas = new List<MedidaMetricaView>();
            ViewBag.Medidas = Context.Medida.AsEnumerable();
            ViewBag.FrequenciasAfericao = Context.FrequenciaAfericao.AsEnumerable();
            var metricaView = new MetricaEditView
            {
                Id =  id,
                Nome  = metrica.Nome,
                Formula = metrica.Formula,
                Descricao = metrica.Descricao,
                FrequenciaAfericaoId = metrica.FrequenciaAfericaoId
            };
            return View(metricaView);
        }

        // POST: Metrica/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MetricaEditView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metrica = Context.Metrica.Find(model.Id);
                    metrica.FrequenciaAfericaoId = model.FrequenciaAfericaoId;
                    metrica.Nome = model.Nome;
                    metrica.Descricao = model.Descricao;
                    metrica.Formula = model.Formula;
                    
                    Context.Metrica.Update(metrica);
                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.MedidasMetricas = new List<MedidaMetricaView>();
                ViewBag.Medidas = Context.Medida.AsEnumerable();
                ViewBag.FrequenciasAfericao = Context.FrequenciaAfericao.AsEnumerable();
                return View();
            }
            catch
            {
                ViewBag.MedidasMetricas = new List<MedidaMetricaView>();
                ViewBag.Medidas = Context.Medida.AsEnumerable();
                ViewBag.FrequenciasAfericao = Context.FrequenciaAfericao.AsEnumerable();
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            var metrica = Context.Metrica.FirstOrDefault(p => p.MetricaId == id);
            if (metrica == null)
                return BadRequest();

            Context.Metrica.Remove(metrica);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));


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