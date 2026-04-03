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
        Metodos metodo = new Metodos();

        public Form2()
        {
            InitializeComponent();
        }

        // Botones para mostrar los formularios correspondientes a las funciones del administrador, cada botón llama a un método de la clase Metodos para mostrar el formulario correspondiente y luego oculta el formulario actual.
        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionUsuario();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click_1(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
          metodo.Admi_Reportes();
            this.Hide();
        }

        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
           metodo.menuAdmin();
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
            metodo.admi_GestionEventos();
            this.Hide();
        }

        private void btnCerrar_sesión_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        private void btnbuscarSemillero_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón de búsqueda por semillero, se encarga de realizar una consulta a la base de datos para obtener los datos del semillero seleccionado y mostrar los resultados en un DataGridView.
        {
            SqlConnection con = Conexion.Conectar();

            string query = "SELECT * FROM semillero WHERE ID_semillero = @id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", comboSemillero.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            Conexion.cerrar();
        }

        private void btnBusquedaLineaInv_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón de búsqueda por línea de investigación, se encarga de realizar una consulta a la base de datos para obtener los datos de los semilleros relacionados con la línea de investigación seleccionada y mostrar los resultados en un DataGridView.
        {
            if (comboSemillero.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un semillero");
                return;
            }

            SqlConnection con = Conexion.Conectar();

            string query = "SELECT * FROM semillero WHERE linea_investigacion = @linea";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@linea", comboLinea.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            Conexion.cerrar();
        }

        private void btnConsuPorFecha_Click(object sender, EventArgs e) // Evento que se ejecuta al hacer clic en el botón de búsqueda por fecha, se encarga de realizar una consulta a la base de datos para obtener los datos de los eventos relacionados con la fecha seleccionada y mostrar los resultados en un DataGridView.
        {
            if (comboLinea.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una línea de investigación");
                return;
            }

            SqlConnection con = Conexion.Conectar();

            string query = "SELECT * FROM evento WHERE fecha_evento = @fecha";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Se valida que la consulta haya devuelto resultados antes de asignar el DataTable como origen de datos del DataGridView, si no se encontraron eventos relacionados con la fecha seleccionada, se muestra un mensaje informativo al usuario y se limpia el DataGridView.
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay semilleros relacionados con esa fecha.",
                                "Sin resultados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                dataGridView1.DataSource = null; // opcional: limpia la tabla
                return;
            }

            dataGridView1.DataSource = dt;

            Conexion.cerrar();
        }
    }
   
}
