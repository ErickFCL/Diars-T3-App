using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_N00020449.Models;

namespace T3_N00020449.iClases
{
    public interface IRutina
    {
        public List<DetalleRutina> Rutina(int idRutina, int ejercicios);
    }
}
