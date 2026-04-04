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

        Consultas consultas = new Consultas(); // creamos una instancia de la clase Consultas para ejecutar las consultas a la base de datos


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" || txt_contraseña.Text == "") // si los campos de usuario y contraseña estan vacios, se muestra un mensaje de error al usuario
            {
                MessageBox.Show("Por favor ingrese la informacion pedida.", "Informacion incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);// mostramos un mensaje de error al usuario indicando que debe ingresar la informacion pedida
            }
            else
            {
                consultas.Iniciar_sesion(int.Parse(txt_id.Text), txt_contraseña.Text); // si los campos de usuario y contraseña no estan vacios, se ejecuta el metodo Iniciar_sesion para verificar si el usuario y la contraseña ingresados por el usuario coinciden con los resultados de la consulta a la base de datos)
                this.Hide(); // ocultamos el formulario Form1 al usuario
            }
        }

        private void btnSalirAPP_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);// se muestra un mensaje de confirmación al usuario antes de cerrar la aplicación
            if (result == DialogResult.Yes)// si el usuario confirma que desea salir, se cierra la aplicación
            {
                Application.Exit();// se cierra la aplicación
            }
        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)// este evento se ejecuta cada vez que el usuario presiona una tecla en el campo de texto txt_id, se utiliza para validar que solo se ingresen números en el campo de texto
        { 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))// si la tecla presionada no es un dígito ni una tecla de control (como backspace), se marca el evento como manejado para evitar que se ingrese el carácter no permitido
            {
                e.Handled = true; // se marca el evento como manejado para evitar que se ingrese el carácter no permitido

                MessageBox.Show("Solo se aceptan números.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);// se muestra un mensaje de advertencia al usuario indicando que solo se aceptan números en el campo de texto
            }
        }
    }
}