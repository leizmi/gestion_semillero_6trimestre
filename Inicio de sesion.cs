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
    public partial class Form1 : Form
    {

        Conexion conexion = new Conexion();// creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        Consultas consultas = new Consultas(); // creamos una instancia de la clase Consultas para ejecutar las consultas a la base de datos


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
                consultas.Iniciar_sesion(int.Parse(txt_id.Text), txt_contraseña.Text); // si los campos de usuario y contraseña no estan vacios, se ejecuta el metodo Iniciar_sesion para verificar si el usuario y la contraseña ingresados por el usuario coinciden con los resultados de la consulta a la base de datos)
                this.Hide(); // ocultamos el formulario Form1 al usuario
            }
        }

        private void btnSalirAPP_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool mostrarMensaje = true;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                if (mostrarMensaje)
                {
                    MessageBox.Show("Solo se aceptan numeros.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mostrarMensaje = false;
                }
            }
            else
            {
                mostrarMensaje = true; // se reinicia cuando escribe bien
            }

        }

        private void txt_contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
