using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Entidades;
namespace Frm_Aplicacion
{
    public partial class Form1 : Form
    {
        private Persona _per;
        
        public Form1()
        {
            InitializeComponent();
            Persona per = new Persona("Lucas", "Carreño");
            this._per = per;
        }
      

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            this.saveFileDialog1.Filter = "Archivo de texto | *.txt";
            this.saveFileDialog1.DefaultExt = "txt";
            
            this.saveFileDialog1.ShowDialog();
            
            StreamWriter sw = new StreamWriter(this.saveFileDialog1.FileName, false);
            sw.WriteLine(this._per.ToString());
            sw.Close();

        }

        private void leerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.openFileDialog1.ShowDialog();
            StreamReader sr = new StreamReader(this.saveFileDialog1.FileName);
            MessageBox.Show(sr.ReadToEnd());
            sr.Close();
           
        }

        
    }
}
