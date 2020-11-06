using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T3_N00020449.iClases;
using T3_N00020449.Models;

namespace T3_N00020449.Controllers
{
    [Authorize]
    public class MiAppController : BaseController
    {
        private readonly N00020449Context _context;
        private IRutina tipoRutina;
        public MiAppController(N00020449Context context ) : base(context)
        {
            this._context = context;
            
        }
        [HttpGet]
        public ActionResult Index(int idRutina)
        {
            ViewBag.Ejercicios = _context.Ejercicios.ToList();

            var rutina = _context.DetalleRutinas.
                Where(o => o.IdRutina == idRutina).
                Include(o => o.Ejercicios).
                ToList();

            return View(rutina);
        }
        [HttpGet]
        public ActionResult Rutinas()
        {
            var rutinaUsuario = _context.Rutinas.
                Where(o => o.IdUsuario == LoggedUser().Id).
                ToList();
            return View(rutinaUsuario);
        }

        [HttpGet]
        public ActionResult CrearRutina()
        {
            ViewBag.Tipo = new List<string> { "Principiante", "Intermedio", "Avanzado" };
            return View(new Rutina());
        }
        [HttpPost]
        public ActionResult CrearRutina(Rutina rutina)
        {
            rutina.IdUsuario = LoggedUser().Id;
            if (ModelState.IsValid)
            {
                _context.Rutinas.Add(rutina);
                _context.SaveChanges();

                int idRutina = rutina.Id;
                var ejercicios = _context.Ejercicios.ToList();
                int ejercicio = ejercicios.Count();
                switch (rutina.Tipo)
                {
                    case "Principiante":
                        tipoRutina = new Principiante();
                        break;
                    case "Intermedio":
                        tipoRutina = new Intermedio();
                        break;
                    case "Avanzado":
                        tipoRutina = new Avanzado();
                        break;
                }

                var aplicar = tipoRutina.Rutina(idRutina, ejercicio);

                _context.DetalleRutinas.AddRange(aplicar);
                _context.SaveChanges();

                return RedirectToAction("Rutinas");
            }
            else
            {
                ViewBag.Tipo = new List<string> { "Intermedio", "Principiante", "Avanzado" };
                return View(new Rutina());
            }
        }
    }
}
