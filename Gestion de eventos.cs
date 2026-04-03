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
    public partial class Consultar_eventos : Form
    {
        
        Conexion conexion = new Conexion();
        Metodos metodo = new Metodos();
        public Consultar_eventos()
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
            metodo.Admi_GestionUsuario();
            this.Hide();
        }

        private void btnGestionEventos_Click(object sender, EventArgs e)
        {
            metodo.admi_GestionEventos();
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

        private void btnCerrar_sesión_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        // Evento para cargar los datos del evento seleccionado en los campos de texto al hacer clic en una fila del DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                txtIdEvento.Text = fila.Cells["ID_evento"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["fecha_evento"].Value);
                txtNombre.Text = fila.Cells["nombre_evento"].Value.ToString();
                txtDescripcion.Text = fila.Cells["descripción_evento"].Value.ToString();
                txtIdSemillero.Text = fila.Cells["ID_semillero"].Value.ToString();
            }
        }

        // Método para cargar los eventos desde la base de datos y mostrarlos en el DataGridView
        void CargarEventos()
        {
            try
            {
                SqlConnection con = conexion.Conectar();
                string query = "SELECT * FROM evento";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        // Evento para cargar los eventos al iniciar el formulario
        private void Consultar_eventos_Load(object sender, EventArgs e)
        {
            CargarEventos();
        }

        // Método para validar que todos los campos estén llenos antes de realizar una operación (agregar o modificar)
        bool ValidarCampos()
        {
            if (txtIdEvento.Text == "" ||
                txtNombre.Text == "" ||
                txtDescripcion.Text == "" ||
                txtIdSemillero.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // validar que todos los campos estén llenos antes de intentar agregar un nuevo evento
            if (txtIdEvento.Text == "" ||
                txtNombre.Text == "" ||
                txtDescripcion.Text == "" ||
                txtIdSemillero.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try // utilizamos un bloque try-catch para manejar cualquier error que pueda ocurrir al agregar un nuevo evento a la base de datos
            {
                SqlConnection con = conexion.Conectar();

                string query = "INSERT INTO evento VALUES (@id, @fecha, @nombre, @descripcion, @idSemillero)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", txtIdEvento.Text);
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@idSemillero", txtIdSemillero.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Evento agregado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conexion.cerrar();

                CargarEventos();
                LimpiarCampos();
            }
            catch (Exception ex) // si ocurre un error al agregar el nuevo evento, se muestra un mensaje de error
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)// Evento para eliminar un evento seleccionado, muestra una confirmación antes de eliminar
        {
            if (txtIdEvento.Text == "")
            {
                MessageBox.Show("Seleccione un evento", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar este evento?",
                "Advertencia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    SqlConnection con = conexion.Conectar();

                    string query = "DELETE FROM evento WHERE ID_evento = @id";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", txtIdEvento.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Evento eliminado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conexion.cerrar();

                    CargarEventos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnModificarEvento_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;// Validar que todos los campos estén llenos antes de intentar modificar el evento

            try
            {
                SqlConnection con = conexion.Conectar();

                string query = @"UPDATE evento 
                              SET fecha_evento = @fecha,
                              nombre_evento = @nombre,
                              descripción_evento = @descripcion,
                              ID_semillero = @idSemillero
                              WHERE ID_evento = @id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", txtIdEvento.Text);
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@idSemillero", txtIdSemillero.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Evento actualizado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conexion.cerrar();

                CargarEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void LimpiarCampos() // Método para limpiar los campos de texto y restablecer el DateTimePicker al valor actual
        {
            txtIdEvento.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtIdSemillero.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
