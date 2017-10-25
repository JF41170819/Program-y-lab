using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Entidades
{
    

    public class Alumno:Persona
    {
        public int _legajo;

     
        public Alumno()
        {

        }
        public Alumno(string nombre,string apellido,int legajo):base(nombre,apellido)
        {
            this._legajo = legajo;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this._legajo;
        }
    }
}
