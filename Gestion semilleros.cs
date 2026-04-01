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
    public partial class Gestion_semilleros : Form
    {
        Metodos metodo = new Metodos();
        Conexion conexion = new Conexion();// creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        public Gestion_semilleros()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            metodo.menuAdmin();
            this.Hide();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodo.menuAdmin();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            metodo.Admi_Reportes();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        private void btnAgregarSemi_Click(object sender, EventArgs e)
        {
            SqlConnection con = conexion.Conectar();

            int nuevoID = ObtenerNuevoID(); // 🔥 genera ID automático

            SqlCommand cmd = new SqlCommand("INSERT INTO semillero (ID_semillero, nombre_semillero, linea_investigacion, fecha_creacion_semillero, descripcion_semillero) " + "VALUES (@id, @nombre, @linea, @fecha, @descripcion)", con);

            cmd.Parameters.AddWithValue("@id", nuevoID);
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@linea", textBox2.Text);
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@descripcion", textBox4.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Semillero agregado correctamente");

            CargarDatos();
        }

        private void Gestion_semilleros_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private int ObtenerNuevoID()
        {
            int nuevoID = 1;

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand(
                "SELECT ISNULL(MAX(ID_semillero), 0) + 1 FROM semillero", con);

            con.Open();
            nuevoID = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return nuevoID;
        }

        private void CargarDatos()
        {
            SqlConnection con = conexion.Conectar();

            SqlDataAdapter da = new SqlDataAdapter(
             "SELECT ID_semillero, nombre_semillero, linea_investigacion, fecha_creacion_semillero FROM semillero",
             con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnConsultarEvento_Click(object sender, EventArgs e)
        {
            metodo.admi_GestionEventos();
            this.Hide();
        }

      
    }   
}
