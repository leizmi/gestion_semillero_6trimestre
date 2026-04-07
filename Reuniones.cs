using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestión_semillero_6trimestre
{
    public partial class Reuniones : Form
    {
        Metodos metodos = new Metodos(); // creamos una instancia de la clase Metodos para utilizar los métodos que se usan repetitivamente en el menú del administrador
        Conexion conexion = new Conexion();
        public Reuniones()
        {
            InitializeComponent();
        }

        private void btn_Reunion_Click(object sender, EventArgs e)
        {
            metodos.reunionesAdmin(); // se llama al método reunionesAdmin() para mostrar el formulario de reuniones
        }

        private void btnMenuadmi_Click(object sender, EventArgs e)
        {
           metodos.menuAdmin(); // se llama al método menuAdmin() para mostrar el formulario del menú del administrador
            this.Hide();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodos.Admi_GestionUsuario(); // se llama al método Admi_GestionUsuario() para mostrar el formulario de gestión de usuarios
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metodos.admi_GestionEventos(); // se llama al método Admi_GestionEventos() para mostrar el formulario de gestión de eventos
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            metodos.Admi_GestionSemillero(); // se llama al método Admi_GestionSemillero() para mostrar el formulario de gestión de semilleros
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            metodos.Admi_Reportes(); // se llama al método Admi_Reportes() para mostrar el formulario de reportes
            this.Hide();
        }

        public void CargarReuniones() // metodo para cargar las reuniones desde la base de dato 
        {
            SqlConnection con = conexion.Conectar();// Establecer la conexión a la base de datos utilizando el método Conectar de la clase Conexion

            string query = "SELECT * FROM reunion";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void btnAgregar_reunion_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtIDsemillero.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion_reunion.Text) ||
                string.IsNullOrWhiteSpace(txtHora_reunion.Text) ||
                string.IsNullOrWhiteSpace(txtIDsemillero.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            SqlConnection con = conexion.Conectar();// Establecer la conexión a la base de datos utilizando el método Conectar de la clase Conexion

            string query = @"INSERT INTO reunion 
                    (ID_reunion, descripcion_reunion, hora_reunion, fecha_reunion, ID_semillero)
                    VALUES (@id, @desc, @hora, @fecha, @semillero)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txt_IDreunion.Text));
            cmd.Parameters.AddWithValue("@desc", txtDescripcion_reunion.Text);
            cmd.Parameters.AddWithValue("@hora", txtHora_reunion.Text);
            cmd.Parameters.AddWithValue("@fecha", fecha_reunion.Value.Date);
            cmd.Parameters.AddWithValue("@semillero", Convert.ToInt32(txtIDsemillero.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Reunión agregada correctamente");
            LimpiarCampos();
            CargarReuniones();
        }

        private void btnActualizar_reunion_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reunión");
                return;
            }

            SqlConnection con = conexion.Conectar();
           

            int idOriginal = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_reunion"].Value);
            int nuevoId = Convert.ToInt32(txt_IDreunion.Text);

            string query = @"UPDATE reunion SET
                    ID_reunion = @nuevoId,
                    descripcion_reunion = @desc,
                    hora_reunion = @hora,
                    fecha_reunion = @fecha,
                    ID_semillero = @semillero
                    WHERE ID_reunion = @idOriginal";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@nuevoId", nuevoId); // 🔥 faltaba
            cmd.Parameters.AddWithValue("@desc", txtDescripcion_reunion.Text);
            cmd.Parameters.AddWithValue("@hora", txtHora_reunion.Text);
            cmd.Parameters.AddWithValue("@fecha", fecha_reunion.Value.Date);
            cmd.Parameters.AddWithValue("@semillero", Convert.ToInt32(txtIDsemillero.Text));
            cmd.Parameters.AddWithValue("@idOriginal", idOriginal);

            int filas = cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Filas afectadas: " + filas);
            LimpiarCampos();
            CargarReuniones();
        }

        private void btn_eliminarReunion_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reunión");
                return;
            }

            DialogResult r = MessageBox.Show("¿Desea eliminar esta reunión?", "Confirmar", MessageBoxButtons.YesNo);

            if (r == DialogResult.No) return;

            SqlConnection con = conexion.Conectar();// Establecer la conexión a la base de datos utilizando el método Conectar de la clase Conexion

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_reunion"].Value);

            string query = "DELETE FROM reunion WHERE ID_reunion = @id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Reunión eliminada");

            CargarReuniones();
            LimpiarCampos();
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodos.sesiónCerrar(this); // se llama al método sesiónCerrar de la clase Metodos para cerrar la sesión 
        }

        private void Reuniones_Load(object sender, EventArgs e)
        {
            CargarReuniones();
        }

        private void txt_IDreunion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e); // se llama al método SoloNumeros de la clase Metodos para permitir solo números en el campo ID de reunión
        }

        private void txtIDsemillero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e); // se llama al método SoloNumeros de la clase Metodos para permitir solo números en el campo ID de semillero
        }

        private void txtHora_reunion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloLetrasNumeros(e);// se llama al método SoloLetrasNumeros de la clase Metodos para permitir solo letras y números en el campo de hora de reunión
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                txt_IDreunion.Text = fila.Cells["ID_reunion"].Value.ToString();
                txtDescripcion_reunion.Text = fila.Cells["descripcion_reunion"].Value.ToString();
                txtHora_reunion.Text = fila.Cells["hora_reunion"].Value.ToString();
                fecha_reunion.Value = Convert.ToDateTime(fila.Cells["fecha_reunion"].Value);
                txtIDsemillero.Text = fila.Cells["ID_semillero"].Value.ToString();
            }   
        }
        void LimpiarCampos()
        {
            txt_IDreunion.Clear();
            txtDescripcion_reunion.Clear();
            txtHora_reunion.Clear();
            txtIDsemillero.Clear();
            fecha_reunion.Value = DateTime.Now;
        }

    }
}
