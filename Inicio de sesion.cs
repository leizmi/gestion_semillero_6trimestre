using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient; //insertar libreria obligado
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestión_semillero_6trimestre
{
    //Conexion cn = new Conexion(); //Creacion de instancia(VARIABLE) de la clase Conexion

    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" || txt_contraseña.Text == "")
            {
                MessageBox.Show("Por favor ingrese la informacion pedida.", "Informacion incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //cn.Iniciar_Sesion(txt_id.Text), txt_contraseña.Text);
                Form2 formulario = new Form2();
                formulario.Show();
                this.Hide();
            }
        }

        private void btnSalirAPP_Click(object sender, EventArgs e)
        {

        }
    }
}
