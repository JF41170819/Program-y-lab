using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formulario
{
    public partial class Form1 : Form
    {
        Empleado unEmpleado;
        Form1 probador;
        public Form1()
        {
            InitializeComponent();
            
        }
        public void ManejadorGenerico(object o, EventArgs a)
        {
            //MessageBox.Show("Este es el manejador generico");
            if (o is TextBox)
            {
                ((TextBox)o).ForeColor = Color.Red;
                //((TextBox)o).Size = new Size(new Point(18));
                ((TextBox)o).Font = new Font("Tahoma", 18);
            }
            else if (o is Label)
            {
                ((Label)o).FlatStyle = FlatStyle.Flat;
            }
            else if (o is Button)
            {
                ((Button)o).Location = new Point(0, 0);
            }
        }
        private void Agregar_Click(object sender, EventArgs e)
        {
            
            unEmpleado.nombre = this.txtNombre.Text;
            unEmpleado.apellido = this.txtApellido.Text;
            unEmpleado.sueldo = double.Parse(this.txtSueldo.Text);
            //unEmpleado.cuartoVerificador -= new VerificadorDos(probador.Manejador4);
        }
        static void Manejador()
        {
           // MessageBox.Show("Estoy en el Manejador del evento limiteSueldo");
        }
        void Manejador2(Empleado x)
        {
           // MessageBox.Show("Estoy en el Manejador2 del evento limiteSueldo del empleado");
        }
        static void Manejador3(Empleado x, double sueldo)
        {
           // MessageBox.Show("Estoy en el Manejador3 del evento limiteSueldo del empleado " + x.nombre + " a " + sueldo);
        }
        void Manejador4(object x, EventArgs y)
        {
            MessageBox.Show("Estoy en el Manejador3 del evento limiteSueldo del empleado " + ((Empleado)x).nombre + " a " + ((EmpleadoEventArgs)y).sueldo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            probador = new Form1();
            unEmpleado = new Empleado();
            unEmpleado.limiteSueldo += new DelEmp(Manejador);
            unEmpleado.limiteSueldoEmpleado += new DelEmpBoton(new Form1().Manejador2);
            unEmpleado.perdonador += new Verificador(Manejador3);
            unEmpleado.cuartoVerificador += new VerificadorDos(probador.Manejador4);
            foreach (Control u in this.Controls)
            {
                u.Click += new EventHandler(ManejadorGenerico);
            }
            //txtNombre.Click += new EventHandler(ManejadorGenerico);
            //txtApellido.Click += new EventHandler(ManejadorGenerico);
            //txtSueldo.Click += new EventHandler(ManejadorGenerico);
            //label1.Click += new EventHandler(ManejadorGenerico);
            //label2.Click += new EventHandler(ManejadorGenerico);
            //label3.Click += new EventHandler(ManejadorGenerico);
            //btnAgregar.Click += new EventHandler(ManejadorGenerico);

        }

    }
}
