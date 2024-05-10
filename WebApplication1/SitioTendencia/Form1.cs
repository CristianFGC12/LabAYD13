using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitioTendencia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Usuario = textBox1.Text;
            string Pagina = textBox2.Text;
            var cliente = new ServiceReference1.LabServiceSoapClient();
            bool permisos = cliente.PedirPermiso(Usuario, Pagina);
            if (permisos == true)
            {
                label4.Text = "Si posee permisos";
            }
            else 
            {
                label4.Text = "No posee permisos";
            }
        }
    }
}
