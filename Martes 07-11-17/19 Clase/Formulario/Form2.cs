using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void ManejadorGenerico(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                if (sender == this.button1)
                {
                    MessageBox.Show("Este es el " + ((Button)sender).Text.ToString());
                    button1.Click -= new EventHandler(ManejadorGenerico);
                    button2.Click += new EventHandler(ManejadorGenerico);
                }
                else if (sender == this.button2)
                {
                    MessageBox.Show("Este es el " + ((Button)sender).Text.ToString());
                    button2.Click -= new EventHandler(ManejadorGenerico);
                    button3.Click += new EventHandler(ManejadorGenerico);
                }
                else if (sender == this.button3)
                {
                    MessageBox.Show("Este es el " + ((Button)sender).Text.ToString());
                    button3.Click -= new EventHandler(ManejadorGenerico);
                    button4.Click += new EventHandler(ManejadorGenerico);
                }
                else
                {
                    MessageBox.Show("Este es el " + ((Button)sender).Text.ToString());
                    button4.Click -= new EventHandler(ManejadorGenerico);
                    button1.Click += new EventHandler(ManejadorGenerico);
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
             button1.Click += new EventHandler(ManejadorGenerico);
        }
    }
}
