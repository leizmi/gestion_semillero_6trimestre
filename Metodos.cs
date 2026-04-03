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

        //metodos que se usa repetitivamente el administrador para mostrar los formularios correspondientes 
        public void menuAdmin() //Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Form2 menu = new Form2(); // Se instancia la clase Form2 y se guarda en la variable menu para poder acceder a sus propiedades y métodos
            menu.Show(); // Muestra el formulario
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
        public void sesiónCerrar(Form formularioActual)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?","Confirmar salida",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 login = new Form1();// Se instancia el formulario de inicio de sesión y se guarda en la variable login para poder acceder a sus propiedades y métodos.
                login.Show();// Se muestra el formulario de inicio de sesión

                formularioActual.Close(); // Variable de tipo Form que representa el formulario actual, se cierra para volver al inicio de sesión.
            }
        }

        /// Rol lider y sus metodos para mostrar los formularios correspondientes a sus funciones
        public void menuLider()
        {
            Menu_Lider menu = new Menu_Lider();
            menu.Show();
        }

        public void consultarEventosLider()
        {
            Consultar_eventos_lider consuEventosLider = new Consultar_eventos_lider();
            consuEventosLider.Show();
        }

        public void consultarEventos()
        {
            Consultar_eventos consulEventos = new Consultar_eventos();
            consulEventos.Show();
        }

        public void registrarProyecto()
        {
            Registrar_proyecto regisProyecto = new Registrar_proyecto();
            regisProyecto.Show();
        }

    }
}
