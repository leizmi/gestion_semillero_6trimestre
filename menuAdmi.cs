using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestión_semillero_6trimestre
{   
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            Form3 gestionUsuario  = new Form3();
            gestionUsuario.Show();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click_1(object sender, EventArgs e)
        {
            Gestion_semilleros gestionSemillero = new Gestion_semilleros();
            gestionSemillero.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes(); 
            reportes.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }


    }
   
}
