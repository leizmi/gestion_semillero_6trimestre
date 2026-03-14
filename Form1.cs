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
    public partial class Form1 : Form
    {
        Consultas cn = new Consultas();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            if (txt_correo_electronico.Text == "" || txt_contraseña.Text == "")
            {
                MessageBox.Show("Por favor ingrese la informacion pedida.", "Informacion incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else
            {
                //              cn.Iniciar_Sesion(txt_correo_electronico.Text), txt_contraseña.Text);
                //            this.Hide();
            }
        }
    }
}
