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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace gestión_semillero_6trimestre
{   
    public partial class Form2 : Form
    {
        Conexion Conexion = new Conexion(); // creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        DataSet ds = new DataSet(); // (conjunto de datos) creamos la variable dt con tipo DataTable para almacenar los resultados de las consultas a la base de datos
        Metodos metodo = new Metodos();// creamos una instancia de la clase Metodos para mostrar los formularios correspondientes a las funciones del administrador

        public Form2()
        {
            InitializeComponent();
        }

        // Botones para mostrar los formularios correspondientes a las funciones del administrador, cada botón llama a un método de la clase Metodos para mostrar el formulario correspondiente y luego oculta el formulario actual.
        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionUsuario();// se llama al método Admi_GestionUsuario de la clase Metodos para mostrar el formulario de gestión de usuarios
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click_1(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero(); // se llama al método Admi_GestionSemillero de la clase Metodos para mostrar el formulario de gestión de semilleros
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
          metodo.Admi_Reportes();// se llama al método Admi_Reportes de la clase Metodos para mostrar el formulario de reportes
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
           metodo.menuAdmin();// se llama al método menuAdmin de la clase Metodos para mostrar el formulario del menú principal del administrador
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e) // Evento que se ejecuta al cargar el formulario, se encarga de cargar los datos de los semilleros y las líneas de investigación en los combobox correspondientes.
        {
            SqlConnection con = Conexion.Conectar(); // establecemos la conexion a la base de datos utilizando el método Conectar de la clase Conexion

            // se cargan los semilleros en el comboBox, se utiliza un SqlDataAdapter para ejecutar una consulta SQL que obtiene el ID y el nombre de los semilleros, luego se llena un DataTable con los resultados y se asigna como origen de datos del comboBox, especificando el campo a mostrar y el campo a usar como valor.
            SqlDataAdapter daSemillero = new SqlDataAdapter("SELECT ID_semillero, nombre_semillero FROM semillero", con);// se utiliza un SqlDataAdapter para ejecutar una consulta SQL que obtiene el ID y el nombre de los semilleros
            DataTable dtSemillero = new DataTable();// se crea un DataTable para almacenar los resultados de la consulta
            daSemillero.Fill(dtSemillero);// se llena el DataTable con los resultados de la consulta

            comboSemillero.DataSource = dtSemillero;// se asigna el DataTable como origen de datos del comboBox
            comboSemillero.DisplayMember = "nombre_semillero";// se especifica el campo a mostrar en el comboBox
            comboSemillero.ValueMember = "ID_semillero";// se especifica el campo a usar como valor en el comboBox

            // Se cargan las líneas de investigación en el comboBox, se utiliza un SqlDataAdapter para ejecutar una consulta SQL que obtiene las líneas de investigación distintas, luego se llena un DataTable con los resultados y se asigna como origen de datos del comboBox, especificando el campo a mostrar.
            SqlDataAdapter daLinea = new SqlDataAdapter("SELECT DISTINCT linea_investigacion FROM semillero", con);// se utiliza un SqlDataAdapter para ejecutar una consulta SQL que obtiene las líneas de investigación distintas
            DataTable dtLinea = new DataTable();// se crea un DataTable para almacenar los resultados de la consulta
            daLinea.Fill(dtLinea);// se llena el DataTable con los resultados de la consulta

            comboLinea.DataSource = dtLinea;// se asigna el DataTable como origen de datos del comboBox
            comboLinea.DisplayMember = "linea_investigacion";// se especifica el campo a mostrar en el comboBox

            Conexion.cerrar();// se cierra la conexion a la base de datos
        }
        
        private void btnGestionEventos_Click(object sender, EventArgs e)
        {
            metodo.admi_GestionEventos();// se llama al método admi_GestionEventos de la clase Metodos para mostrar el formulario de gestión de eventos
            this.Hide();
        }

        private void btnCerrar_sesión_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // se llama al método sesiónCerrar de la clase Metodos para cerrar la sesión y volver al formulario de inicio de sesión, pasando el formulario actual como argumento para cerrarlo después de mostrar el formulario de inicio de sesión
        }

        private void btnbuscarSemillero_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón de búsqueda por semillero, se encarga de realizar una consulta a la base de datos para obtener los datos del semillero seleccionado y mostrar los resultados en un DataGridView.
        {
            SqlConnection con = Conexion.Conectar();// establecemos la conexion a la base de datos utilizando el método Conectar de la clase Conexion

            string query = "SELECT * FROM semillero WHERE ID_semillero = @id";// se define la consulta SQL para obtener los datos del semillero seleccionado, utilizando un parámetro para evitar inyecciones SQL

            SqlCommand cmd = new SqlCommand(query, con);// se crea un SqlCommand para ejecutar la consulta SQL, pasando la consulta y la conexión como argumentos
            cmd.Parameters.AddWithValue("@id", comboSemillero.SelectedValue);// se agrega el valor del parámetro @id utilizando el valor seleccionado en el comboBox de semilleros

            SqlDataAdapter da = new SqlDataAdapter(cmd);// se crea un SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados, pasando el SqlCommand como argumento
            DataTable dt = new DataTable();// se crea un DataTable para almacenar los resultados de la consulta
            da.Fill(dt);// se llena el DataTable con los resultados de la consulta
            dataGridView1.DataSource = dt;// se asigna el DataTable como origen de datos del DataGridView para mostrar los resultados de la consulta

            Conexion.cerrar();// se cierra la conexion a la base de datos
        }

        private void btnBusquedaLineaInv_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón de búsqueda por línea de investigación, se encarga de realizar una consulta a la base de datos para obtener los datos de los semilleros relacionados con la línea de investigación seleccionada y mostrar los resultados en un DataGridView.
        {
            if (comboSemillero.SelectedIndex == -1)// se valida que el usuario haya seleccionado un semillero en el comboBox antes de ejecutar la consulta, si no se ha seleccionado ningún semillero, se muestra un mensaje de error y se detiene la ejecución del método
            {
                MessageBox.Show("Debe seleccionar un semillero");// se muestra un mensaje de error al usuario indicando que debe seleccionar un semillero
                return;
            }

            SqlConnection con = Conexion.Conectar();// establecemos la conexion a la base de datos utilizando el método Conectar de la clase Conexion

            string query = "SELECT * FROM semillero WHERE linea_investigacion = @linea";// se define la consulta SQL para obtener los datos de los semilleros relacionados con la línea de investigación seleccionada, utilizando un parámetro para evitar inyecciones SQL
            SqlCommand cmd = new SqlCommand(query, con);// se crea un SqlCommand para ejecutar la consulta SQL, pasando la consulta y la conexión como argumentos
            cmd.Parameters.AddWithValue("@linea", comboLinea.Text);// se agrega el valor del parámetro @linea utilizando el texto seleccionado en el comboBox de líneas de investigación

            SqlDataAdapter da = new SqlDataAdapter(cmd);// se crea un SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados, pasando el SqlCommand como argumento
            DataTable dt = new DataTable();// se crea un DataTable para almacenar los resultados de la consulta
            da.Fill(dt);// se llena el DataTable con los resultados de la consulta
                       
            dataGridView1.DataSource = dt;// se asigna el DataTable como origen de datos del DataGridView para mostrar los resultados de la consulta
            Conexion.cerrar();// se cierra la conexion a la base de datos
        }

        private void btnConsuPorFecha_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón de búsqueda por fecha, se encarga de realizar una consulta a la base de datos para obtener los datos de los eventos relacionados con la fecha seleccionada y mostrar los resultados en un DataGridView.
        {
            if (comboLinea.SelectedIndex == -1)// se valida que el usuario haya seleccionado una línea de investigación en el comboBox antes de ejecutar la consulta, si no se ha seleccionado ninguna línea de investigación, se muestra un mensaje de error y se detiene la ejecución del método
            {
                MessageBox.Show("Debe seleccionar una línea de investigación");// se muestra un mensaje de error al usuario indicando que debe seleccionar una línea de investigación
                return;
            }

            SqlConnection con = Conexion.Conectar();// establecemos la conexion a la base de datos utilizando el método Conectar de la clase Conexion

            string query = "SELECT * FROM evento WHERE fecha_evento = @fecha";// se define la consulta SQL para obtener los datos de los eventos relacionados con la fecha seleccionada, utilizando un parámetro para evitar inyecciones SQL
            SqlCommand cmd = new SqlCommand(query, con);// se crea un SqlCommand para ejecutar la consulta SQL, pasando la consulta y la conexión como argumentos
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date);// se agrega el valor del parámetro @fecha utilizando la fecha seleccionada en el DateTimePicker, utilizando la propiedad Value.Date para obtener solo la parte de la fecha sin la hora

            SqlDataAdapter da = new SqlDataAdapter(cmd);// se crea un SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados, pasando el SqlCommand como argumento
            DataTable dt = new DataTable();// se crea un DataTable para almacenar los resultados de la consulta
            da.Fill(dt);// se llena el DataTable con los resultados de la consulta
                        
            if (dt.Rows.Count == 0)// se valida si el DataTable está vacío, lo que indica que no se encontraron eventos relacionados con la fecha seleccionada, si el DataTable está vacío, se muestra un mensaje de información al usuario y se limpia el DataGridView
            {
                MessageBox.Show("No hay semilleros relacionados con esa fecha.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information); // se muestra un mensaje de información al usuario indicando que no se encontraron semilleros relacionados con la fecha seleccionada

                dataGridView1.DataSource = null; // opcional: limpia la tabla
                return;
            }

            dataGridView1.DataSource = dt; // se asigna el DataTable como origen de datos del DataGridView para mostrar los resultados de la consulta
            Conexion.cerrar();// se cierra la conexion a la base de datos
        }
    }
   
}
