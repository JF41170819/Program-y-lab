using System;
using System.Windows.Forms;
using System.IO;
using Entidades;

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
                txtDisplay.Clear();
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
                    txtDisplay.Clear();
                    txtDisplay.Text = Calculadora.del.Invoke(numUno, numDos, operacion).ToString();

                    foreach (Control i in panelNumeros.Controls)
                    {
                        i.Click -= new EventHandler(ManejadorCentral);
                    }
                    foreach (Control i in panelOperaciones.Controls)
                    {
                        i.Click -= new EventHandler(ManejadorCentral);
                    }

                    btnLimpiar.Click += new EventHandler(ManejadorCentral);
                    StreamWriter sw = new StreamWriter("Texto.txt", true);
                    sw.WriteLine(DateTime.Now.ToString() + Environment.NewLine + "Operacion: " + Environment.NewLine + this.numUno.ToString() + operacion + this.numDos.ToString() + "=" + txtDisplay.Text + Environment.NewLine);
                    sw.Close();
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
                txtDisplay.Clear();
                btnLimpiar.Click -= new EventHandler(ManejadorCentral);
                foreach (Control i in panelNumeros.Controls)
                {
                    i.Click += new EventHandler(ManejadorCentral);
                }
                flag = 0;

            }


        }
    }
}
