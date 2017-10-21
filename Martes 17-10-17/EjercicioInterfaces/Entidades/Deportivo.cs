using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Deportivo:Auto,IAFIP,IARBA
    {
        protected int _caballosFuerza;
        
        public Deportivo(double precio, string patente, int hp)
            :base(precio,patente)
        {
            this._caballosFuerza = hp;
        }
        double  IAFIP.CalcularImpuesto()
        {
            return base.Precio * 1.28;
        }

        double IARBA.CalcularImpuesto()
        {
            return base.Precio * 1.23;
        }


    }
}
