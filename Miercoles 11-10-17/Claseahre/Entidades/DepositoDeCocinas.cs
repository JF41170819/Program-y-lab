using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoDeCocinas
    {
        private int _capacidadMaxima;
        private List<Cocina> _lista;

        public static bool operator +(DepositoDeCocinas d,Cocina c)
        {
            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(c);
                return true;
            }

            return false;
        }
        public DepositoDeCocinas(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<Cocina>();
        }
        private int GetIndice(Cocina c)
        {
            for (int i = 0; i < this._lista.Count; i++)
			{
			     if(this._lista[i]==c)
                 {
                     return i;
                 }
			}
            return -1;
        }

        public static bool operator -(DepositoDeCocinas d, Cocina c)
        {
            int index=d.GetIndice(c);
            if (index != -1)
            {
                d._lista.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool Agregar(Cocina c)
        {
            if (this + c)
            {
                return true;
            }
            return false;
        }

        public bool Remover(Cocina c)
        {
            if (this - c)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string retorno = "Capacidad Maxima: " + this._capacidadMaxima + "\nLista de Cocinas:\n";
            foreach (Cocina i in this._lista)
            {
                retorno += i.ToString()+"\n";
            }
            return retorno;
        }

    }
}
