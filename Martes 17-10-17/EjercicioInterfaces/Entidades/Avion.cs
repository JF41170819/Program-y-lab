﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Avion:Vehiculo,IAFIP
    {
        protected double _velocidadMaxima;

        public Avion(double precio, double velMax):base(precio)
        {
            this._velocidadMaxima = velMax;
        }



        public double CalcularImpuesto()
        {
            return this._precio * 1.33;
        }

    }
}
