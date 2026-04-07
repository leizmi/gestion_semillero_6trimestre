using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestión_semillero_6trimestre
{
    public partial class Consultar_eventos_lider : Form
    {   
        Metodos metodos = new Metodos(); // instancia de la clase Metodos para acceder a sus funciones
        Conexion conexion = new Conexion(); // instancia de la clase Conexion para establecer la conexion a la base de datos

        public Consultar_eventos_lider()
        {
            InitializeComponent();
        }

        private void btnBuscarEvento_Click(object sender, EventArgs e)// evento click del botón de búsqueda
        {
            if (comboBox1.SelectedItem == null)// validación para asegurarse de que se ha seleccionado un criterio de búsqueda
            {
                MessageBox.Show("Seleccione un criterio de búsqueda."); // se muestra un mensaje de error si no se ha seleccionado ningún criterio en el ComboBox
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBuscar.Text))// validación para asegurarse de que se ha ingresado un valor para buscar
            {
                MessageBox.Show("Ingrese un valor para buscar."); // se muestra un mensaje de error si el campo de búsqueda está vacío
                return;
            }

            string columna = "";// variable para almacenar el nombre de la columna de la base de datos que se va a consultar
            string valor = txtBuscar.Text.Trim();// variable para almacenar el valor ingresado por el usuario para buscar, se utiliza Trim() para eliminar espacios en blanco al inicio y al final
            string opcion = comboBox1.SelectedItem.ToString();// variable para almacenar la opción seleccionada en el ComboBox, se convierte a cadena utilizando ToString()

            if (opcion == "ID del evento")// validación para determinar qué columna de la base de datos se va a consultar según la opción seleccionada en el ComboBox
            {
                columna = "ID_evento";// si la opción seleccionada es "ID del evento", se asigna el nombre de la columna correspondiente a la variable "columna"

                if (!int.TryParse(valor, out _))// validación para asegurarse de que el valor ingresado para buscar es un número entero, ya que el ID del evento debe ser numérico
                {
                    MessageBox.Show("El ID debe ser numérico.");// se muestra un mensaje de error si el valor ingresado no es un número entero
                    return;
                }
            }
            else if (opcion == "Nombre del evento")// si la opción seleccionada es "Nombre del evento", se asigna el nombre de la columna correspondiente a la variable "columna"
            {
                columna = "nombre_evento";// se asigna el nombre de la columna correspondiente a la variable "columna"
            }
            else if (opcion == "Fecha evento")// si la opción seleccionada es "Fecha evento", se asigna el nombre de la columna correspondiente a la variable "columna"
            {
                columna = "fecha_evento";// se asigna el nombre de la columna correspondiente a la variable "columna"

                if (!DateTime.TryParseExact(valor, "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out _)) // validación para asegurarse de que el valor ingresado para buscar tiene el formato de fecha correcto (yyyy-MM-dd), ya que la fecha del evento debe tener ese formato
                {
                    MessageBox.Show("La fecha debe tener formato: yyyy-MM-dd"); // se muestra un mensaje de error si el valor ingresado no tiene el formato de fecha correcto
                    return;
                }
            }

            if (columna == "") // validación para asegurarse de que se ha asignado un nombre de columna válido a la variable "columna", lo que indica que se ha seleccionado una opción válida en el ComboBox
            {
                MessageBox.Show("Opción no válida.");// se muestra un mensaje de error si no se ha asignado un nombre de columna válido a la variable "columna"
                return;
            }
            CargarDatos(columna, valor);// se llama al método CargarDatos, pasando como parámetros el nombre de la columna y el valor ingresado por el usuario para realizar la consulta en la base de datos y mostrar los resultados en el DataGridView
        }

        public void CargarDatos(string columna, string valor) // método para cargar los datos en el DataGridView según el criterio de búsqueda seleccionado por el usuario
        {
            string query = "";// variable para almacenar la consulta SQL que se va a ejecutar en la base de datos

            if (string.IsNullOrEmpty(columna) || string.IsNullOrEmpty(valor))// validación para determinar si se ha seleccionado un criterio de búsqueda y se ha ingresado un valor para buscar, en caso contrario se cargan todos los eventos sin filtrar
            {
                query = "SELECT * FROM evento"; // si no se ha seleccionado un criterio de búsqueda o no se ha ingresado un valor para buscar, se asigna la consulta SQL para seleccionar todos los eventos sin filtrar a la variable "query"
            }
            else
            {
                if (columna == "ID_evento")// si el criterio de búsqueda seleccionado es "ID del evento", se asigna la consulta SQL para seleccionar los eventos que coincidan exactamente con el ID ingresado por el usuario, utilizando un parámetro para evitar inyecciones SQL
                {
                    query = "SELECT * FROM evento WHERE ID_evento = @valor"; // si el criterio de búsqueda seleccionado es "ID del evento", se asigna la consulta SQL para seleccionar los eventos que coincidan exactamente con el ID ingresado por el usuario, utilizando un parámetro para evitar inyecciones SQL
                } 
                else
                {
                    query = $"SELECT * FROM evento WHERE {columna} LIKE @valor"; // si el criterio de búsqueda seleccionado es "Nombre del evento" o "Fecha evento", se asigna la consulta SQL para seleccionar los eventos que coincidan parcialmente con el valor ingresado por el usuario, utilizando un parámetro con comodines para permitir búsquedas más flexibles
                }
            }

            SqlConnection con = conexion.Conectar(); // se establece la conexión a la base de datos utilizando el método Conectar de la clase Conexion
            SqlCommand cmd = new SqlCommand(query, con);// se crea un objeto SqlCommand para ejecutar la consulta SQL, pasando como parámetros la consulta y la conexión establecida

            if (!string.IsNullOrEmpty(columna) && !string.IsNullOrEmpty(valor))// validación para agregar el parámetro a la consulta SQL solo si se ha seleccionado un criterio de búsqueda y se ha ingresado un valor para buscar
            {
                if (columna == "ID_evento")// si el criterio de búsqueda seleccionado es "ID del evento", se agrega el parámetro a la consulta SQL utilizando el tipo de dato adecuado (Int) para evitar problemas de conversión y mejorar la seguridad de la consulta
                    cmd.Parameters.Add("@valor", SqlDbType.Int).Value = Convert.ToInt32(valor);// si el criterio de búsqueda seleccionado es "ID del evento", se agrega el parámetro a la consulta SQL utilizando el tipo de dato adecuado (Int) para evitar problemas de conversión y mejorar la seguridad de la consulta
                else if (columna == "fecha_evento") // si el criterio de búsqueda seleccionado es "Fecha evento", se agrega el parámetro a la consulta SQL utilizando el tipo de dato adecuado (Date) para evitar problemas de conversión y mejorar la seguridad de la consulta
                    cmd.Parameters.AddWithValue("@valor", valor);// si el criterio de búsqueda seleccionado es "Fecha evento", se agrega el parámetro a la consulta SQL utilizando el tipo de dato adecuado (Date) para evitar problemas de conversión y mejorar la seguridad de la consulta
                else
                    cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");// si el criterio de búsqueda seleccionado es "Nombre del evento", se agrega el parámetro a la consulta SQL utilizando comodines para permitir búsquedas más flexibles, buscando coincidencias parciales en lugar de coincidencias exactas
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);// se crea un objeto SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados, pasando como parámetro el objeto SqlCommand que contiene la consulta y los parámetros necesarios
            DataTable dt = new DataTable();// se crea un objeto DataTable para almacenar los resultados de la consulta SQL
            da.Fill(dt);// se llena el DataTable con los resultados de la consulta SQL utilizando el método Fill del SqlDataAdapter

            if (dt.Rows.Count == 0) // validación para verificar si la consulta SQL no ha devuelto ningún resultado, lo que indica que no se han encontrado eventos que coincidan con el criterio de búsqueda ingresado por el usuario
            {
                if (columna == "nombre_evento")
                    MessageBox.Show("No existe ningún evento con ese nombre.");
                else if (columna == "fecha_evento")
                    MessageBox.Show("No hay eventos en esa fecha.");
                else if (columna == "ID_evento")
                    MessageBox.Show("No existe ningún evento con ese ID.");

                dataGridView1.DataSource = null; // se establece el DataSource del DataGridView a null para limpiar cualquier resultado anterior que se haya mostrado en el DataGridView, ya que no se han encontrado eventos que coincidan con el criterio de búsqueda ingresado por el usuario
                return;
            }

            dataGridView1.DataSource = dt; // se establece el DataSource del DataGridView al DataTable que contiene los resultados de la consulta SQL, lo que permite mostrar los eventos que coinciden con el criterio de búsqueda ingresado por el usuario en el DataGridView
        }

        private void Consultar_eventos_lider_Load(object sender, EventArgs e)
        {
            CargarDatos("", "");    // se llama al método CargarDatos con parámetros vacíos para cargar todos los eventos sin filtrar al cargar el formulario, lo que permite mostrar inicialmente todos los eventos disponibles en la base de datos en el DataGridView
        }


        private void btnGestionReuniones_Click(object sender, EventArgs e)
        {
            metodos.ReunionLider(); // se llama al método ReunionLider de la clase Metodos para mostrar el formulario de gestión de reuniones para el rol de líder, lo que permite al usuario acceder a las funciones de gestión de reuniones específicas para su rol
            this.Hide();
        }

        private void btnGestionarSemillero_Click_1(object sender, EventArgs e)
        {
            metodos.menuLider();
            this.Hide();
        }

        private void btnRegistrarProyecto_Click_1(object sender, EventArgs e)
        {
            metodos.registrarProyecto();// se llama al método registrarProyecto de la clase Metodos para mostrar el formulario de registro de proyectos, lo que permite al usuario acceder a las funciones de registro de proyectos específicas para su rol
            this.Hide();
        }

        private void btnConsultarEventos_Click(object sender, EventArgs e)
        {
            metodos.consultarEventosLider(); // se llama al método consultarEventosLider de la clase Metodos para mostrar el formulario de consulta de eventos para el rol de líder, lo que permite al usuario acceder a las funciones de consulta de eventos específicas para su rol
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodos.sesiónCerrar(this); // se llama al método sesiónCerrar de la clase Metodos, pasando como parámetro el formulario actual (this) para cerrar la sesión del usuario y volver a la pantalla de inicio de sesión

        }
    }
}
