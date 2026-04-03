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

        // Eventos para navegar entre formularios del menú principal del administrador
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
            metodo.sesiónCerrar(this);
        }

        // Evento para agregar un nuevo semillero a la base de datos
        private void btnAgregarSemi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information); // Validación para asegurarse de que todos los campos estén llenos antes de agregar un nuevo semillero
                return;
            }

            SqlConnection con = conexion.Conectar();// Establecemos la conexión a la base de datos utilizando el método Conectar de la clase Conexion
            int nuevoID = ObtenerNuevoID();// Obtener un nuevo ID para el semillero

            SqlCommand cmd = new SqlCommand(
              "INSERT INTO semillero (ID_semillero, nombre_semillero, linea_investigacion, fecha_creacion_semillero, descripcion_semillero, estado) " +
              "VALUES (@id, @nombre, @linea, @fecha, @descripcion, 'activo')", con);

            cmd.Parameters.AddWithValue("@id", nuevoID);
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@linea", textBox2.Text);
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@descripcion", textBox4.Text);

            con.Open();// Abrimos la conexión a la base de datos
            cmd.ExecuteNonQuery();// Ejecutamos el comando SQL para insertar el nuevo semillero en la base de datos
            con.Close();//  

            MessageBox.Show("Semillero agregado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();// Recargamos los datos para mostrar el nuevo semillero en el DataGridView
            LimpiarCampos();// Limpiamos los campos después de agregar un nuevo semillero y recargamos los datos para mostrar el nuevo semillero en el DataGridView
        }


        // Evento para cargar los datos de los semilleros al iniciar el formulario
        private void Gestion_semilleros_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Método para obtener un nuevo ID para el semillero, se consulta el máximo ID existente en la base de datos y se le suma 1 para generar un nuevo ID único
        private int ObtenerNuevoID()
        {
            int nuevoID = 1; // Valor inicial para el nuevo ID

            SqlConnection con = conexion.Conectar();// Establecemos la conexión a la base de datos utilizando el método Conectar de la clase Conexion

            SqlCommand cmd = new SqlCommand(
                "SELECT ISNULL(MAX(ID_semillero), 0) + 1 FROM semillero", con); // Consulta SQL para obtener el máximo ID existente en la tabla semillero y sumarle 1 para generar un nuevo ID único


            nuevoID = Convert.ToInt32(cmd.ExecuteScalar());// Ejecutamos la consulta y convertimos el resultado a un entero para obtener el nuevo ID
            con.Close();// Cerramos la conexión a la base de datos

            return nuevoID;// Retornamos el nuevo ID generado para el semillero
        }

        // Método para cargar los datos de los semilleros desde la base de datos y mostrarlos en el DataGridView
        private void CargarDatos()
        {
            SqlConnection con = conexion.Conectar();

            SqlDataAdapter da = new SqlDataAdapter(
            @"SELECT 
            s.ID_semillero,
            s.nombre_semillero,
            s.linea_investigacion,
            s.fecha_creacion_semillero,
            s.descripcion_semillero,
            s.estado,
            (SELECT TOP 1 i.nombre_investigador + ' ' + i.apellido_investigador
             FROM investigadores i
             WHERE i.ID_semillero = s.ID_semillero) AS Lider
             FROM semillero s",
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

        // Evento para cargar los datos del semillero seleccionado en los campos de texto al hacer clic en una fila del DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            txtID.Text = fila.Cells["ID_semillero"].Value.ToString();
            textBox1.Text = fila.Cells["nombre_semillero"].Value.ToString();
            textBox2.Text = fila.Cells["linea_investigacion"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["fecha_creacion_semillero"].Value);
            textBox4.Text = fila.Cells["descripcion_semillero"].Value.ToString();
            txtLider.Text = fila.Cells["Lider"].Value.ToString();
        }

        // Evento para actualizar los datos del semillero seleccionado en la base de datos
        private void btnActualizarSemi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Seleccione un semillero", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand(
                @"UPDATE semillero SET 
                    nombre_semillero = @nombre,
                    linea_investigacion = @linea,
                    fecha_creacion_semillero = @fecha,
                    descripcion_semillero = @descripcion
                  WHERE ID_semillero = @id", con);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@linea", textBox2.Text);
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@descripcion", textBox4.Text);

            
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Semillero actualizado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mostramos un mensaje de información al usuario indicando que el semillero ha sido actualizado correctamente
            CargarDatos();// Recargamos los datos para mostrar los cambios realizados en el DataGridView
            LimpiarCampos();//  Limpiamos los campos después de actualizar el semillero y recargamos los datos para mostrar los cambios realizados en el DataGridView
        }

        private void btnEliminarSemi_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Seleccione un semillero", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea desactivar este semillero?",
                "Advertencia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.No) return;// Si el usuario selecciona "No" en la confirmación, se cancela la operación y no se desactiva el semillero

            SqlConnection con = conexion.Conectar();
            SqlCommand cmd = new SqlCommand(
                "UPDATE semillero SET estado = 'inactivo' WHERE ID_semillero = @id", con);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));// Agregamos el parámetro @id al comando SQL para evitar inyecciones SQL y asegurarnos de que el ID del semillero se pase correctamente a la consulta

            con.Open();// Abrimos la conexión a la base de datos
            cmd.ExecuteNonQuery();// Ejecutamos el comando SQL para actualizar el estado del semillero a "inactivo" en la base de datos
            con.Close();// Cerramos la conexión a la base de datos

            MessageBox.Show("Semillero desactivado","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            CargarDatos();
            LimpiarCampos();
        }


        void LimpiarCampos()// Método para limpiar los campos de texto y restablecer el valor del DateTimePicker después de realizar una operación (agregar, actualizar o eliminar) y recargar los datos para mostrar los cambios realizados en el DataGridView
        {
            txtID.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            txtLider.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.ClearSelection();
        }

        private void btnActivarSemillero_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))// Validación para asegurarse de que se haya seleccionado un semillero antes de intentar activarlo
            {
                MessageBox.Show("Seleccione un semillero", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);// Validación para asegurarse de que se haya seleccionado un semillero antes de intentar activarlo
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea activar este semillero?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);// Mostramos un mensaje de confirmación al usuario antes de activar el semillero, para evitar activaciones accidentales

            if (r == DialogResult.No) return;// Si el usuario selecciona "No" en la confirmación, se cancela la operación y no se activa el semillero

            SqlConnection con = conexion.Conectar();
            SqlCommand cmd = new SqlCommand(
                "UPDATE semillero SET estado = 'activo' WHERE ID_semillero = @id", con);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Semillero activado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
            LimpiarCampos();
        }
    }   

}
