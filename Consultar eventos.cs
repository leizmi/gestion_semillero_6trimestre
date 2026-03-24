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
    public partial class Consultar_eventos : Form
    {
        public Consultar_eventos()
        {
            InitializeComponent();
        }

        private void btnGestionSemillero_Click(object sender, EventArgs e)
        {
            Gestion_semilleros gestionSemillero = new Gestion_semilleros();
            gestionSemillero.Show();
            this.Hide();
        }

        private void btnRegistrarProyecto_Click(object sender, EventArgs e)
        {
            Registrar_proyecto regisProyecto = new Registrar_proyecto();   
            regisProyecto.Show();
            this.Hide();
        }

        private void btnConsultarEvento_Click(object sender, EventArgs e)
        {
            Consultar_eventos consulEventos = new Consultar_eventos();
            consulEventos.Show();
            this.Hide();
        }
    }
}
