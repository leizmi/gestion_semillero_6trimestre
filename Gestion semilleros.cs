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
    public partial class Gestion_semilleros : Form
    {
        public Gestion_semilleros()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Form2 menu = new Form2();
            menu.Show();
            this.Close();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            Form3 gestionUsuario = new Form3();
            gestionUsuario.Show();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            Gestion_semilleros gestion = new Gestion_semilleros();
            gestion.Show();
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
    }
}
