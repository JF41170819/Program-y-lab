using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected double _precio;

        protected abstract double Precio
        {
            get;
        }
        public void MostrarPrecio()
        {
            Console.WriteLine("Precio: " + this._precio);
        }

        public Vehiculo(double precio)
        {
            this._precio = precio;
        }


    }
}
