using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00020449.Models
{
    public class DetalleRutina
    {
        public int Id { get; set; }
        public int IdEjercicio { get; set; }
        public int IdRutina { get; set; }
        public int Tiempo { get; set; }
        public Ejercicio Ejercicios { get; set; }

    }
}
