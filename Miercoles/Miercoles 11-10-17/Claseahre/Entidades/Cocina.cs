﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cocina
    {
        private int _codigo;
        private bool _esIndustrial;
        private double _precio;

        public int Codigo { get { return this._codigo; } }
        public bool EsIndustrial { get { return this._esIndustrial; } }
        public double Precio { get { return this._precio; } }
        public Cocina()
        {
        }
        public Cocina(int codigo, double precio, bool esIndustrial)
        {
            this._codigo = codigo;
            this._precio = precio;
            this._esIndustrial = esIndustrial;
        }

        public static bool operator ==(Cocina a, Cocina b)
        {
            return a.Codigo == b.Codigo;
        }

        public static bool operator !=(Cocina a, Cocina b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            return obj is Cocina && this == (Cocina)obj;
        }

        public override string ToString()
        {
            return " Codigo: " + this._codigo + " Precio: " + this._precio + " Es industrial: " + this._esIndustrial;
        }
    }
}
