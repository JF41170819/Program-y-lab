using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace test_consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado unEmpleado = new Empleado();
            unEmpleado.nombre = "Carlitos";
            unEmpleado.limiteSueldo += new DelEmp(Manejador);
            unEmpleado.limiteSueldoEmpleado += new DelEmpBoton(new Program().Manejador2);
            unEmpleado.perdonador += new Verificador(Manejador3);
            unEmpleado.sueldo = 15000;
            Console.ReadLine();
        }
        static void Manejador()
        {
            Console.WriteLine("Estoy en el Manejador del evento limiteSueldo");
        }
        void Manejador2(Empleado x)
        {
            Console.WriteLine("Estoy en el Manejador2 del evento limiteSueldo del empleado");
        }
        static void Manejador3(Empleado x,double sueldo)
        {
            Console.WriteLine("Estoy en el Manejador3 del evento limiteSueldo del empleado "+x.nombre+" a "+sueldo);
        }
    }
}
