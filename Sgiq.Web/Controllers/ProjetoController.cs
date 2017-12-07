using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sgiq.Dados;
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
            return View();
        }

        // POST: Projeto/Create
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