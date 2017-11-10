using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelEmp();
    public delegate void DelEmpBoton(Empleado a);
    public delegate void Verificador(Empleado a, double sueldo);
    public delegate void VerificadorDos(object a, EventArgs sueldo);
    public class EmpleadoEventArgs : EventArgs
    {
        public double sueldo;
        public EmpleadoEventArgs(double sueldo)
        {
            this.sueldo = sueldo;
        }
    }
    public class Empleado
    {
        private string _nombre;
        private string _apellido;
        private double _sueldo;
        public event DelEmp limiteSueldo;
        public event DelEmpBoton limiteSueldoEmpleado;
        public event Verificador perdonador;
        public event VerificadorDos cuartoVerificador;



        public string nombre
        {
            get { return this._nombre;}
            set { this._nombre = value; }
        }
        public string apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public double sueldo
        {
            get
            {
                return this._sueldo;
            }
            set
            {
                if (value > 0 && value <= 9500)
                    this._sueldo = value;
                else
                {
                    if (value <= 0)
                        throw new Exception("Solo valores positivos en el sueldo porfi");
                    else
                    {
                        this.limiteSueldo();
                        this.limiteSueldoEmpleado(this);
                        this.perdonador(this,value);
                        this.cuartoVerificador((object)this,new EmpleadoEventArgs(value));
                    }
                }
            }
        }
        public override string ToString()
        {
            return "Nombre: "+this._nombre+" apellido: "+this._apellido+" sueldo: "+this._sueldo;
        }
    }
}
