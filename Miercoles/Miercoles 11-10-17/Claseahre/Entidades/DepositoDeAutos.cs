using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoDeAutos
    {
        private int _capacidadMaxima;
        private List<Auto> _lista;

        public DepositoDeAutos(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<Auto>();
        }
        public static bool operator +(DepositoDeAutos d, Auto a)
        {
            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(a);
                return true;
            }
            return false;
        }

        private int GetIndice(Auto a)
        {
            for (int i = 0; i < this._lista.Count; i++)
            {
                if (this._lista[i] == a)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool operator -(DepositoDeAutos d, Auto a)
        {
            int index = d.GetIndice(a);
            if (index!= -1)
            {
                d._lista.RemoveAt(index);
            }

            return false;
        }

        public bool Remover(Auto a)
        {
            if (this - a)
            {
                return true;
            }
            return false;
        }

        public bool Agregar(Auto a)
        {
            if (this + a)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            
            string retorno = "\nCapacidad maxima: "+this._capacidadMaxima+"\n"+"Lista de autos: \n";

            foreach (Auto i in this._lista)
            {
                retorno += i.ToString()+"\n";
            }

            return retorno;
        }
    }
}
