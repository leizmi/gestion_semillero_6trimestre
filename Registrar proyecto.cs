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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestión_semillero_6trimestre
{
    public partial class Registrar_proyecto : Form
    {
        Conexion conexion = new Conexion();// creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        Consultas consultas = new Consultas(); // creamos una instancia de la clase Consultas para ejecutar las consultas a la base de datos
        Metodos metodo = new Metodos(); // creamos una instancia de la clase Metodos para ejecutar los metodos de la clase Metodos
        DataSet ds = new DataSet();

        public Registrar_proyecto()
        {
            InitializeComponent();
        }

        
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        private void btnConsularEvento_Click(object sender, EventArgs e)
        {
            metodo.consultarEventosLider();
            this.Hide();
        }

        private void btnGestionarSemillero_Click(object sender, EventArgs e)
        {
            metodo.menuLider();
            this.Hide();
        }

        private void btnRegistrarProyecto_Click(object sender, EventArgs e)
        {
            metodo.registrarProyecto();
            this.Hide();
        }

        private void CargarProyectos()
        { 
            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM proyecto", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void Registrar_proyecto_Load(object sender, EventArgs e)
        {
            CargarProyectos();
            CargarProyectos(); // 🔥 Carga los proyectos al iniciar el formulario   
        }

        private void btnRegisProye_Click(object sender, EventArgs e)
        {
            if (txtIdProyecto.Text == "" || txtNombreProyecto.Text == "" || txtActividadProyecto.Text == "")
            {
                MessageBox.Show("Por favor complete los campos.");
                return;
            }

            using (SqlConnection con = conexion.Conectar())
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // 🔥 1. VALIDAR SI EXISTE EL SEMILLERO
                string validar = "SELECT COUNT(*) FROM semillero WHERE ID_semillero = @id";

                SqlCommand cmdValidar = new SqlCommand(validar, con);
                cmdValidar.Parameters.AddWithValue("@id", txtIdSemillero.Text);

                int existe = (int)cmdValidar.ExecuteScalar();

                if (existe == 0)
                {
                    MessageBox.Show(
                        "El ID de semillero no existe.\nPrimero debe crear el semillero.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // 🔥 2. INSERTAR PROYECTO (solo si pasó la validación)
                string query = "INSERT INTO proyecto (ID_proyecto, nombre_proyecto, actividad_proyecto, fecha_inicio_proyecto, fecha_fin_proyecto, ID_semillero) " +
                               "VALUES (@idProyecto, @nombre, @actividad, @fechaInicio, @fechaFin, @IdSemillero)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@idProyecto", txtIdProyecto.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombreProyecto.Text);
                cmd.Parameters.AddWithValue("@actividad", txtActividadProyecto.Text);
                cmd.Parameters.AddWithValue("@fechaInicio", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@fechaFin", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@IdSemillero", txtIdSemillero.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Proyecto registrado correctamente");

            CargarProyectos();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtIdProyecto.Clear();
            txtNombreProyecto.Clear();
            txtActividadProyecto.Clear();
            txtIdSemillero.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
