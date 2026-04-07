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
        public void reunionesAdmin() //Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Reuniones reuniones = new Reuniones(); // Se instancia la clase Reuniones y se guarda en la variable reuniones para poder acceder a sus propiedades y métodos
            reuniones.Show(); // Muestra el formulario
        }
        public void Admi_Reportes() //Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Reportes reportes = new Reportes();// Se instancia la clase Reportes y se guarda en la variable reportes para poder acceder a sus propiedades y métodos
            reportes.Show();// Muestra el formulario
        }
        public void Admi_GestionSemillero()//Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Gestion_semilleros gestionSemillero = new Gestion_semilleros();// Se instancia la clase Gestion_semilleros y se guarda en la variable gestionSemillero para poder acceder a sus propiedades y métodos
            gestionSemillero.Show();// Muestra el formulario
        }
        public void Admi_GestionUsuario()//Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Form3 gestionUsuario = new Form3();// Se instancia la clase Form3 y se guarda en la variable gestionUsuario para poder acceder a sus propiedades y métodos
            gestionUsuario.Show();// Muestra el formulario
        }
        public void admi_GestionEventos()//Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Consultar_eventos consulEventos = new Consultar_eventos();// Se instancia la clase Consultar_eventos y se guarda en la variable consulEventos para poder acceder a sus propiedades y métodos
            consulEventos.Show();// Muestra el formulario
        }


        /// Método para cerrar sesión, muestra un mensaje de confirmación antes de cerrar la sesión y volver al formulario de inicio de sesión.
        public void sesiónCerrar(Form formularioActual)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?","Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);// se muestra un mensaje de confirmación al usuario antes de cerrar la sesión

            if (result == DialogResult.Yes)
            {
                Form1 login = new Form1();// Se instancia el formulario de inicio de sesión y se guarda en la variable login para poder acceder a sus propiedades y métodos.
                login.Show();// Se muestra el formulario de inicio de sesión

                formularioActual.Close(); // Variable de tipo Form que representa el formulario actual, se cierra para volver al inicio de sesión.
            }
        }
        

        /// Rol lider y sus metodos para mostrar los formularios correspondientes a sus funciones
        public void menuLider()//Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Menu_Lider menu = new Menu_Lider();// Se instancia la clase Menu_Lider y se guarda en la variable menu para poder acceder a sus propiedades y métodos
            menu.Show();
        }

        public void consultarEventosLider()//Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Consultar_eventos_lider consuEventosLider = new Consultar_eventos_lider();// Se instancia la clase Consultar_eventos_lider y se guarda en la variable consuEventosLider para poder acceder a sus propiedades y métodos
            consuEventosLider.Show();
        }

        public void consultarEventos()//Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Consultar_eventos consulEventos = new Consultar_eventos();// Se instancia la clase Consultar_eventos y se guarda en la variable consulEventos para poder acceder a sus propiedades y métodos
            consulEventos.Show();
        }
        public void registrarProyecto()//Metodos publico para poder acceder a el desde cualquier formulario, sin retornar ninguno valor.
        {
            Registrar_proyecto regisProyecto = new Registrar_proyecto();// Se instancia la clase Registrar_proyecto y se guarda en la variable regisProyecto para poder acceder a sus propiedades y métodos
            regisProyecto.Show();
        }

        /////validaciones para los campos de texto, se pueden usar en cualquier formulario para validar los campos de texto antes de realizar alguna acción, como guardar o actualizar datos.
        ///
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void SoloLetras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }




    }



}
