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
        public Gestion_semilleros()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Form2 menu = new Form2();
            menu.Show();
            this.Close();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            Form3 gestionUsuario = new Form3();
            gestionUsuario.Show();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            Gestion_semilleros gestion = new Gestion_semilleros();
            gestion.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAgregarSemi_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(
         "Data Source=DESKTOP-HPRJHVG;Initial Catalog=GestionSemillero;Integrated Security=True");

            int nuevoID = ObtenerNuevoID(); // 🔥 genera ID automático

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO semillero (ID_semillero, nombre_semillero, linea_investigacion, fecha_creacion_semillero, descripcion_semillero) " +
                "VALUES (@id, @nombre, @linea, @fecha, @descripcion)", conexion);

            cmd.Parameters.AddWithValue("@id", nuevoID);
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@linea", textBox2.Text);
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@descripcion", textBox4.Text);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

            MessageBox.Show("Semillero agregado correctamente");

            CargarDatos();
        }

        private void CargarDatos()
        {
            SqlConnection conexion = new SqlConnection(
                "Data Source=DESKTOP-HPRJHVG;Initial Catalog=GestionSemillero;Integrated Security=True");

            SqlDataAdapter da = new SqlDataAdapter(
             "SELECT ID_semillero, nombre_semillero, linea_investigacion, fecha_creacion_semillero FROM semillero",
             conexion);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void Gestion_semilleros_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private int ObtenerNuevoID()
        {
            int nuevoID = 1;

            SqlConnection conexion = new SqlConnection(
                "Data Source=DESKTOP-HPRJHVG;Initial Catalog=GestionSemillero;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(
                "SELECT ISNULL(MAX(ID_semillero), 0) + 1 FROM semillero", conexion);

            conexion.Open();
            nuevoID = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();

            return nuevoID;
        }

       
    }   
}
