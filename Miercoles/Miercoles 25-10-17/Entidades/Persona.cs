using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Entidades
{
    [XmlInclude(typeof(Alumno))]
    public class Persona
    {
        
        protected string _nombre;
        protected string _apellido;

        public string Apellido { get { return this._apellido; } set { this._apellido = value; } }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }

        public Persona()
        {

        }
        public Persona(string nombre,string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public override string ToString()
        {
            return this.Nombre + " " + this.Apellido;
        }
    }
}
