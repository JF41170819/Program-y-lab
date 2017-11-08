using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRM_Calculadora
{
    public partial class Form1 : Form
    {
        // 0 PRIMERA ENTRADA,1 YA TOCO UN OPERADOR
        int flag = 0;
        int numUno = 0;
        int numDos = 0;
        string operacion = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Name = "Calculadora";
            txtDisplay.ReadOnly = true;
      

            foreach (Control i in panelNumeros.Controls)
            {
                i.Click += new EventHandler(ManejadorCentral);
            }

        }

        public void ManejadorCentral(object sender, EventArgs e)
        {
            //PARTE QUE ENTRA POR PRIMERA VEZ
            if (flag == 0)
            {
                foreach (Control i in this.panelNumeros.Controls)
                {
                    if (sender == i)
                    {

                        txtDisplay.Text = ((Button)sender).Text;
                        numUno = int.Parse(txtDisplay.Text);
                        foreach (Control j in this.panelOperaciones.Controls)
                        {
                            j.Click += new EventHandler(ManejadorCentral);
                        }
                        this.flag = 1;
                        break;
                    }

                }

            }
            //PARTE QUE TOCA UNA OPERACION
            else if (flag == 1)
            {
                foreach (Control i in this.panelOperaciones.Controls)
                {
                    if (sender == i)
                    {
                        operacion = ((Button)sender).Text;
                        foreach (Control j in this.panelOperaciones.Controls)
                        {
                            j.Click -= new EventHandler(ManejadorCentral);
                        }
                        txtDisplay.Clear();
                        flag = 2;
                        break;
                    }
                }
                foreach (Control i in this.panelNumeros.Controls)
                {
                    if (sender == i)
                    {
                        txtDisplay.Text += ((Button)sender).Text;
                        numUno = int.Parse(txtDisplay.Text);
                        break;
                    }
                }
            }
            //PARTE QUE YA TOCO LA OPERACION
            else if (flag == 2)
            {
                foreach (Control i in this.panelNumeros.Controls)
                {
                    if (sender == i)
                    {
                        txtDisplay.Text = ((Button)sender).Text;
                        btnCalcular.Enabled = true;
                        btnCalcular.Click += new EventHandler(ManejadorCentral);
                        flag = 3;
                    }
                }
            }
            //PARTE QUE TOCA EL IGUAL O OTRO NUMERO
            else if (flag == 3)
            {
                if (sender == btnCalcular)
                {
                    numDos = int.Parse(txtDisplay.Text);
                    int resultado=0;
                    switch (operacion)
                    {
                        case "+":
                            resultado=numUno+numDos;
                            break;
                        case "-":
                            resultado=numUno-numDos;
                            break;
                        case "/":
                            resultado=numUno/numDos;
                            break;
                        case "*":
                            resultado = numUno * numDos;
                            break;
                    }           
                    txtDisplay.Clear();
                    txtDisplay.Text = resultado.ToString();
                    foreach (Control i in this.panelNumeros.Controls)
                    {
                        i.Click -= new EventHandler(ManejadorCentral);
                    }
                    foreach (Control i in this.panelOperaciones.Controls)
                    {
                        i.Click -= new EventHandler(ManejadorCentral);
                    }
                    flag = 4;

                }
                else
                {
                    foreach (Control i in this.panelNumeros.Controls)
                    {
                        if (sender == i)
                        {
                            txtDisplay.Text += ((Button)sender).Text;
                            numDos = int.Parse(txtDisplay.Text);
                        }

                    }
                }
                

            }
            else if (flag == 4)
            {
                if (sender == btnLimpiar)
                {
                    txtDisplay.Clear();
                }
                
            }

        }
    }
}
