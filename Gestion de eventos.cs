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
        Conexion conexion = new Conexion(); // Se instancia la clase Conexion y se guarda en la variable conexion para poder acceder a sus propiedades y métodos.
        Metodos metodo = new Metodos(); // Se instancia la clase Metodos y se guarda en la variable metodo para poder acceder a sus propiedades y métodos.
        public Consultar_eventos()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)// Evento para volver al menú principal del administrador, se oculta el formulario actual para mostrar el menú principal
        {
            metodo.menuAdmin();// Se llama al método menuAdmin para mostrar el menú principal del administrador
            this.Hide();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionUsuario();// Se llama al método Admi_GestionUsuario para mostrar el formulario de gestión de usuarios del administrador
            this.Hide();
        }

        private void btnGestionEventos_Click(object sender, EventArgs e)
        { 
          metodo.admi_GestionEventos();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero();// Se llama al método Admi_GestionSemillero para mostrar el formulario de gestión de semilleros del administrador
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            metodo.Admi_Reportes();// Se llama al método Admi_Reportes para mostrar el formulario de reportes del administrador
            this.Hide();
        }

        private void btnCerrar_sesión_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // Se llama al método sesiónCerrar para mostrar el mensaje de confirmación de cierre de sesión y cerrar el formulario actual si el usuario confirma que desea salir
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)// Evento para mostrar los datos del evento seleccionado en los campos de texto correspondientes, se obtiene la fila seleccionada y se asignan los valores de las celdas a los campos de texto
        {
            if (e.RowIndex >= 0)// Validar que se haya seleccionado una fila válida (no el encabezado)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];// Obtener la fila seleccionada

                txtIdEvento.Text = fila.Cells["ID_evento"].Value.ToString();// Asignar el valor de la celda "ID_evento" al campo de texto txtIdEvento
                dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["fecha_evento"].Value);   // Asignar el valor de la celda "fecha_evento" al DateTimePicker dateTimePicker1, convirtiendo el valor a DateTime
                txtNombre.Text = fila.Cells["nombre_evento"].Value.ToString();// Asignar el valor de la celda "nombre_evento" al campo de texto txtNombre
                txtDescripcion.Text = fila.Cells["descripción_evento"].Value.ToString();// Asignar el valor de la celda "descripción_evento" al campo de texto txtDescripcion
                txtIdSemillero.Text = fila.Cells["ID_semillero"].Value.ToString();// Asignar el valor de la celda "ID_semillero" al campo de texto txtIdSemillero
            }
        }

        void CargarEventos() // Método para cargar los eventos desde la base de datos y mostrarlos en el DataGridView, se establece la conexión a la base de datos, se ejecuta la consulta para obtener los eventos, se llena un DataTable con los resultados y se asigna como fuente de datos del DataGridView
        {
            try
            {
                SqlConnection con = conexion.Conectar();// Establecer la conexión a la base de datos utilizando el método Conectar de la clase Conexion
                string query = "SELECT * FROM evento";// Consulta SQL para obtener todos los eventos de la tabla "evento"
                SqlDataAdapter da = new SqlDataAdapter(query, con);// Crear un SqlDataAdapter para ejecutar la consulta y llenar un DataTable con los resultados
                DataTable dt = new DataTable();// Crear un DataTable para almacenar los resultados de la consulta
                da.Fill(dt);// Llenar el DataTable con los resultados de la consulta

                dataGridView1.DataSource = dt;// Asignar el DataTable como fuente de datos del DataGridView para mostrar los eventos en la interfaz
                conexion.cerrar();// Cerrar la conexión a la base de datos utilizando el método cerrar de la clase Conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message); // Si ocurre un error al cargar los datos, se muestra un mensaje de error con la descripción del error
            }
        }

        private void Consultar_eventos_Load(object sender, EventArgs e) // Evento que se ejecuta al cargar el formulario, se llama al método CargarEventos para mostrar los eventos en el DataGridView al iniciar la aplicación
        {
            CargarEventos();// Llamar al método CargarEventos para cargar los eventos desde la base de datos y mostrarlos en el DataGridView al cargar el formulario
        }

        bool ValidarCampos() // Método para validar que todos los campos estén llenos antes de intentar agregar o modificar un evento, se verifica que ninguno de los campos de texto esté vacío y se muestra un mensaje de información si alguno de los campos no está lleno
        {
            if (txtIdEvento.Text == "" || txtNombre.Text == "" || txtDescripcion.Text == "" || txtIdSemillero.Text == "") // Validar que ninguno de los campos de texto esté vacío
            {
                MessageBox.Show("Debe llenar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Si alguno de los campos está vacío, se muestra un mensaje de información al usuario indicando que debe llenar todos los campos
                return false; // Retornar false para indicar que la validación no pasó y no se debe continuar con la operación de agregar o modificar el evento
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtIdEvento.Text == "" || txtNombre.Text == "" || txtDescripcion.Text == "" || txtIdSemillero.Text == "") // Validar que ninguno de los campos de texto esté vacío
            {
                MessageBox.Show("Debe llenar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information); // Si alguno de los campos está vacío, se muestra un mensaje de información al usuario indicando que debe llenar todos los campos
                return;
            }

            try // utilizamos un bloque try-catch para manejar cualquier error que pueda ocurrir al agregar un nuevo evento a la base de datos
            {
                SqlConnection con = conexion.Conectar();// Establecer la conexión a la base de datos utilizando el método Conectar de la clase Conexion

                string query = "INSERT INTO evento VALUES (@id, @fecha, @nombre, @descripcion, @idSemillero)";// Consulta SQL para insertar un nuevo evento en la tabla "evento" utilizando parámetros para evitar inyección SQL
                SqlCommand cmd = new SqlCommand(query, con);// Crear un SqlCommand para ejecutar la consulta de inserción

                cmd.Parameters.AddWithValue("@id", txtIdEvento.Text);// Agregar el valor del campo de texto txtIdEvento como parámetro "@id" en la consulta SQL
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);// Agregar el valor del DateTimePicker dateTimePicker1 como parámetro "@fecha" en la consulta SQL
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);// Agregar el valor del campo de texto txtNombre como parámetro "@nombre" en la consulta SQL
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);// Agregar el valor del campo de texto txtDescripcion como parámetro "@descripcion" en la consulta SQL
                cmd.Parameters.AddWithValue("@idSemillero", txtIdSemillero.Text);// Agregar el valor del campo de texto txtIdSemillero como parámetro "@idSemillero" en la consulta SQL

                cmd.ExecuteNonQuery();// Ejecutar la consulta de inserción para agregar el nuevo evento a la base de datos

                MessageBox.Show("Evento agregado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Si el evento se agrega correctamente, se muestra un mensaje de información al usuario indicando que el evento fue agregado correctamente

                conexion.cerrar();// Cerrar la conexión a la base de datos utilizando el método cerrar de la clase Conexion
                CargarEventos();// Llamar al método CargarEventos para actualizar el DataGridView con el nuevo evento agregado
                LimpiarCampos();// Llamar al método LimpiarCampos para limpiar los campos de texto y restablecer el DateTimePicker después de agregar un nuevo evento
            }
            catch (Exception ex) // si ocurre un error al agregar el nuevo evento, se muestra un mensaje de error
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)// Evento para eliminar un evento seleccionado, muestra una confirmación antes de eliminar
        {
            if (txtIdEvento.Text == "")// Validar que se haya seleccionado un evento (que el campo de texto txtIdEvento no esté vacío)
            {
                MessageBox.Show("Seleccione un evento", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Si no se ha seleccionado un evento, se muestra un mensaje de información al usuario indicando que debe seleccionar un evento para eliminar
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este evento?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );// Mostrar un mensaje de confirmación al usuario antes de eliminar el evento, con opciones "Sí" y "No" y un ícono de advertencia
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    SqlConnection con = conexion.Conectar();// Establecer la conexión a la base de datos utilizando el método Conectar de la clase Conexion

                    string query = "DELETE FROM evento WHERE ID_evento = @id";// Consulta SQL para eliminar un evento de la tabla "evento" utilizando un parámetro para identificar el evento a eliminar
                    SqlCommand cmd = new SqlCommand(query, con);// Crear un SqlCommand para ejecutar la consulta de eliminación

                    cmd.Parameters.AddWithValue("@id", txtIdEvento.Text);// Agregar el valor del campo de texto txtIdEvento como parámetro "@id" en la consulta SQL para identificar el evento a eliminar
                    cmd.ExecuteNonQuery();// Ejecutar la consulta de eliminación para eliminar el evento de la base de datos

                    MessageBox.Show("Evento eliminado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Si el evento se elimina correctamente, se muestra un mensaje de información al usuario indicando que el evento fue eliminado correctamente
                    conexion.cerrar();// Cerrar la conexión a la base de datos utilizando el método cerrar de la clase Conexion
                    CargarEventos();// Llamar al método CargarEventos para actualizar el DataGridView después de eliminar el evento
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);// Si ocurre un error al eliminar el evento, se muestra un mensaje de error con la descripción del error
                }
            }
        }

        private void btnModificarEvento_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;// Validar que todos los campos estén llenos antes de intentar modificar el evento

            try
            {
                SqlConnection con = conexion.Conectar();// Establecer la conexión a la base de datos utilizando el método Conectar de la clase Conexion

                string query = @"UPDATE evento 
                              SET fecha_evento = @fecha,
                              nombre_evento = @nombre,
                              descripción_evento = @descripcion,
                              ID_semillero = @idSemillero
                              WHERE ID_evento = @id";// Consulta SQL para actualizar un evento en la tabla "evento" utilizando parámetros para evitar inyección SQL, se actualizan los campos fecha_evento, nombre_evento, descripción_evento e ID_semillero del evento identificado por el ID_evento

                SqlCommand cmd = new SqlCommand(query, con);// Crear un SqlCommand para ejecutar la consulta de actualización

                cmd.Parameters.AddWithValue("@id", txtIdEvento.Text);// Agregar el valor del campo de texto txtIdEvento como parámetro "@id" en la consulta SQL para identificar el evento a modificar
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);// Agregar el valor del DateTimePicker dateTimePicker1 como parámetro "@fecha" en la consulta SQL para actualizar la fecha del evento
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);// Agregar el valor del campo de texto txtNombre como parámetro "@nombre" en la consulta SQL para actualizar el nombre del evento
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);// Agregar el valor del campo de texto txtDescripcion como parámetro "@descripcion" en la consulta SQL para actualizar la descripción del evento
                cmd.Parameters.AddWithValue("@idSemillero", txtIdSemillero.Text);// Agregar el valor del campo de texto txtIdSemillero como parámetro "@idSemillero" en la consulta SQL para actualizar el ID del semillero asociado al evento

                cmd.ExecuteNonQuery();// Ejecutar la consulta de actualización para modificar el evento en la base de datos

                MessageBox.Show("Evento actualizado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Si el evento se actualiza correctamente, se muestra un mensaje de información al usuario indicando que el evento fue actualizado correctamente
                conexion.cerrar();// Cerrar la conexión a la base de datos utilizando el método cerrar de la clase Conexion
                CargarEventos();// Llamar al método CargarEventos para actualizar el DataGridView después de modificar el evento
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);// Si ocurre un error al modificar el evento, se muestra un mensaje de error con la descripción del error
            }
        }
        void LimpiarCampos() // Método para limpiar los campos de texto y restablecer el DateTimePicker al valor actual
        {
            txtIdEvento.Clear();// Limpiar el campo de texto txtIdEvento
            txtNombre.Clear();// Limpiar el campo de texto txtNombre
            txtDescripcion.Clear();// Limpiar el campo de texto txtDescripcion
            txtIdSemillero.Clear();// Limpiar el campo de texto txtIdSemillero
            dateTimePicker1.Value = DateTime.Now;// Restablecer el DateTimePicker dateTimePicker1 al valor actual (fecha y hora actual)
        }

        private void txtIdEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);// Llamar al método SoloNumeros para validar que solo se ingresen números en el campo de texto txtIdEvento, pasando el evento KeyPressEventArgs como argumento para validar la tecla presionada
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloLetras(e);// Llamar al método SoloLetras para validar que solo se ingresen letras en el campo de texto txtNombre, pasando el evento KeyPressEventArgs como argumento para validar la tecla presionada
        }

        private void txtIdSemillero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);// Llamar al método SoloNumeros para validar que solo se ingresen números en el campo de texto txtIdSemillero, pasando el evento KeyPressEventArgs como argumento para validar la tecla presionada
        }

        private void btn_Reunion_Click(object sender, EventArgs e)
        {
            metodo.reunionesAdmin();// Llamar al método Gestion_Reuniones para mostrar el formulario de gestión de reuniones del administrador
            this.Hide();// Ocultar el formulario actual para mostrar el formulario de gestión de reuniones
        }
    }
}
