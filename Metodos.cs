using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestión_semillero_6trimestre
{
    internal class Metodos
    {

        //metodos q usa repetitivamente el administrador para mostrar los formularios correspondientes 
        public void menuAdmin()
        {
            Form2 menu = new Form2();
            menu.Show();
        }
        public void Admi_Reportes()
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }
        public void Admi_GestionSemillero()
        {
            Gestion_semilleros gestionSemillero = new Gestion_semilleros();
            gestionSemillero.Show();
        }
        public void Admi_GestionUsuario()
        {
            Form3 gestionUsuario = new Form3();
            gestionUsuario.Show();
        }
        public void admi_GestionEventos()
        {
            Consultar_eventos consulEventos = new Consultar_eventos();
            consulEventos.Show();
        }


        
        /// Método para cerrar sesión, muestra un mensaje de confirmación antes de cerrar la sesión y volver al formulario de inicio de sesión.
        public void sesiónCerrar()
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 menu = new Form1();
                menu.Show();
            }
        }

    }
}
