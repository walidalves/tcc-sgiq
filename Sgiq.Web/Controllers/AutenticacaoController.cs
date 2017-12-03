using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sgiq.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }    

        // POST: Autenticacao/Autenticar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autenticar(IFormCollection collection)
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

        public ActionResult RecuperarSenha(int id)
        {
            return View();
        }

        // GET: Autenticacao/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}