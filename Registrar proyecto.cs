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
    public partial class Registrar_proyecto : Form
    {
        public Registrar_proyecto()
        {
            InitializeComponent();
        }

        private void btnGestionSemillero_Click(object sender, EventArgs e)
        {
            Menu_Lider MLider = new Menu_Lider();
            MLider.Show();
            this.Hide();
        }

        private void btnConsultarEvento_Click(object sender, EventArgs e)
        {
            Consultar_eventos consuEvento = new Consultar_eventos();
            consuEvento.Show();             
            this.Hide();
        }
    }
}
