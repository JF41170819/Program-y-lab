using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deposito<T> where T : new()
    {
        private int _capacidadMaxima;
        private List<T> _lista;

        public static bool operator +(Deposito<T> d,T c)
        {
            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(c);
                return true;
            }

            return false;
        }
        public Deposito(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<T>();
        }

        private int GetIndice(T c)
        {
            for (int i = 0; i < this._lista.Count; i++)
			{
			     if(this._lista[i].Equals(c))
                 {
                     return i;
                 }
			}
            return -1;
        }

        public static bool operator -(Deposito<T> d,T c)
        {
            int index=d.GetIndice(c);
            if (index != -1)
            {
                d._lista.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool Agregar(T c)
        {
            if (this + c)
            {
                return true;
            }
            return false;
        }

        public bool Remover(T c)
        {
            if (this - c)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string retorno = "Capacidad Maxima: " + this._capacidadMaxima + "\nListado "+typeof(T).Name+"\n";
            foreach(T i in this._lista)
            {
                retorno += i.ToString()+"\n";
            }
            return retorno;
        }
        
    }
}
