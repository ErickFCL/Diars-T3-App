using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_N00020449.Models;

namespace T3_N00020449.iClases
{
    public class Intermedio : IRutina
    {
        public List<DetalleRutina> Rutina(int idRutina, int ejercicios)
        {
            Random random = new Random();
            List<DetalleRutina> detalles = new List<DetalleRutina>();
            for (int i = 0; i < 10; i++)
            {
                var detalle = new DetalleRutina();
                var ejercicio = random.Next(0, ejercicios);
                var tiempo = random.Next(60, 120);

                detalle.IdEjercicio = ejercicio;
                detalle.IdRutina = idRutina;
                detalle.Tiempo = tiempo;

                detalles.Add(detalle);
            }
            return detalles;
        }
    }
}
