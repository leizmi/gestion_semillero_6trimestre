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
        Metodos metodo = new Metodos(); // creamos una instancia de la clase Metodos para utilizar sus métodos en la navegación entre formularios y otras funcionalidade
        Conexion conexion = new Conexion();// creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        public Gestion_semilleros()
        {
            InitializeComponent();
        }   

        private void btnDashboard_Click(object sender, EventArgs e) // Evento para navegar al formulario del menu admi
        {
            metodo.menuAdmin();  // Llamamos al método menuAdmin de la clase Metodos para mostrar el formulario del menú de administrador
            this.Hide();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionUsuario(); // Llamamos al método Admi_GestionUsuario de la clase Metodos para mostrar el formulario de gestión de usuarios
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero(); // Llamamos al método Admi_GestionSemillero de la clase Metodos para mostrar el formulario de gestión de semilleros
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            metodo.Admi_Reportes(); // Llamamos al método Admi_Reportes de la clase Metodos para mostrar el formulario de reportes
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // Llamamos al método sesiónCerrar de la clase Metodos para cerrar la sesión actual y mostrar el formulario de inicio de sesión
        }

       
        private void btnAgregarSemi_Click(object sender, EventArgs e) // Evento para agregar un nuevo semillero a la base de datos
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || // Validación para asegurarse de que el campo de nombre del semillero no esté vacío o contenga solo espacios en blanco
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
              "VALUES (@id, @nombre, @linea, @fecha, @descripcion, 'activo')", con); // Comando SQL para insertar un nuevo semillero en la base de datos, utilizando parámetros para evitar inyecciones SQL y asegurar que los datos se pasen correctamente a la consulta

            cmd.Parameters.AddWithValue("@id", nuevoID); // Agregamos el parámetro @id al comando SQL con el nuevo ID generado para el semillero
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text); // Agregamos el parámetro @nombre al comando SQL con el valor del campo de texto para el nombre del semillero
            cmd.Parameters.AddWithValue("@linea", textBox2.Text); // Agregamos el parámetro @linea al comando SQL con el valor del campo de texto para la línea de investigación del semillero
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value); // Agregamos el parámetro @fecha al comando SQL con el valor del DateTimePicker para la fecha de creación del semillero
            cmd.Parameters.AddWithValue("@descripcion", textBox4.Text); // Agregamos el parámetro @descripcion al comando SQL con el valor del campo de texto para la descripción del semillero

            con.Open();// Abrimos la conexión a la base de datos
            cmd.ExecuteNonQuery();// Ejecutamos el comando SQL para insertar el nuevo semillero en la base de datos
            con.Close();

            MessageBox.Show("Semillero agregado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Mostramos un mensaje de información al usuario indicando que el semillero ha sido agregado correctamente
            CargarDatos();// Recargamos los datos para mostrar el nuevo semillero en el DataGridView
            LimpiarCampos();// Limpiamos los campos después de agregar un nuevo semillero y recargamos los datos para mostrar el nuevo semillero en el DataGridView
        }


        private void Gestion_semilleros_Load(object sender, EventArgs e) // Evento para cargar los datos de los semilleros al iniciar el formulario
        {
            CargarDatos(); // Llamamos al método CargarDatos para cargar los datos de los semilleros desde la base de datos y mostrarlos en el DataGridView al iniciar el formulario
        }


        private int ObtenerNuevoID() // Método para obtener un nuevo ID para el semillero, se consulta el máximo ID existente en la base de datos y se le suma 1 para generar un nuevo ID único
        {
            int nuevoID = 1; // Valor inicial para el nuevo ID

            SqlConnection con = conexion.Conectar();// Establecemos la conexión a la base de datos utilizando el método Conectar de la clase Conexion

            SqlCommand cmd = new SqlCommand(
            "SELECT ISNULL(MAX(ID_semillero), 0) + 1 FROM semillero", con); // Consulta SQL para obtener el máximo ID existente en la tabla semillero y sumarle 1 para generar un nuevo ID único


            nuevoID = Convert.ToInt32(cmd.ExecuteScalar());// Ejecutamos la consulta y convertimos el resultado a un entero para obtener el nuevo ID
            con.Close();// Cerramos la conexión a la base de datos

            return nuevoID;// Retornamos el nuevo ID generado para el semillero
        }

        private void CargarDatos() // Método para cargar los datos de los semilleros desde la base de datos y mostrarlos en el DataGridView
        {
            SqlConnection con = conexion.Conectar(); // Establecemos la conexión a la base de datos utilizando el método Conectar de la clase Conexion

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
                con); // Consulta SQL para obtener los datos de los semilleros, incluyendo el nombre del líder del semillero utilizando una subconsulta para obtener el nombre completo del investigador asociado al semillero

            DataTable dt = new DataTable(); // Creamos un DataTable para almacenar los datos obtenidos de la consulta SQL
            da.Fill(dt);// Llenamos el DataTable con los datos obtenidos de la consulta SQL utilizando el SqlDataAdapter

            dataGridView1.DataSource = dt; // Asignamos el DataTable como fuente de datos para el DataGridView, lo que permitirá mostrar los datos de los semilleros en la interfaz de usuario
        }

        private void btnConsultarEvento_Click(object sender, EventArgs e)// Evento para navegar al formulario de gestión de eventos
        {
            metodo.admi_GestionEventos();    // Llamamos al método admi_GestionEventos de la clase Metodos para mostrar el formulario de gestión de eventos
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Evento para cargar los datos del semillero seleccionado en los campos de texto y el DateTimePicker para su posterior actualización o eliminación
        {
            if (e.RowIndex < 0) return; // Validación para asegurarse de que se haya seleccionado una fila válida en el DataGridView antes de intentar cargar los datos del semillero

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex]; // Obtenemos la fila seleccionada en el DataGridView utilizando el índice de la fila proporcionado por el evento CellClick

            txtID.Text = fila.Cells["ID_semillero"].Value.ToString(); // Cargamos el valor del ID del semillero seleccionado en el campo de texto txtID para su posterior uso en las operaciones de actualización o eliminación0
            textBox1.Text = fila.Cells["nombre_semillero"].Value.ToString();// Cargamos el valor del nombre del semillero seleccionado en el campo de texto textBox1 para su posterior uso en las operaciones de actualización o eliminación
            textBox2.Text = fila.Cells["linea_investigacion"].Value.ToString();// Cargamos el valor de la línea de investigación del semillero seleccionado en el campo de texto textBox2 para su posterior uso en las operaciones de actualización o eliminación
            dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["fecha_creacion_semillero"].Value);// Cargamos el valor de la fecha de creación del semillero seleccionado en el DateTimePicker dateTimePicker1 para su posterior uso en las operaciones de actualización o eliminación
            textBox4.Text = fila.Cells["descripcion_semillero"].Value.ToString();// Cargamos el valor de la descripción del semillero seleccionado en el campo de texto textBox4 para su posterior uso en las operaciones de actualización o eliminación
            txtLider.Text = fila.Cells["Lider"].Value.ToString();// Cargamos el valor del nombre del líder del semillero seleccionado en el campo de texto txtLider para mostrarlo al usuario, aunque este campo no se utiliza para las operaciones de actualización o eliminación, ya que el líder se asigna a través de la gestión de investigadores y no se actualiza directamente desde este formulario
        }

        private void btnActualizarSemi_Click(object sender, EventArgs e)// Evento para actualizar los datos del semillero seleccionado en la base de datos con los valores ingresados en los campos de texto y el DateTimePicker
        {
            if (string.IsNullOrWhiteSpace(txtID.Text)) // Validación para asegurarse de que se haya seleccionado un semillero antes de intentar actualizarlo, verificando que el campo de texto txtID no esté vacío o contenga solo espacios en blanco
            {
                MessageBox.Show("Seleccione un semillero", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mostramos un mensaje de información al usuario indicando que debe seleccionar un semillero antes de intentar actualizarlo, para evitar errores al intentar actualizar un semillero sin haber seleccionado uno previamente
                return;
            }

            SqlConnection con = conexion.Conectar(); // Establecemos la conexión a la base de datos utilizando el método Conectar de la clase Conexion

            SqlCommand cmd = new SqlCommand(
                @"UPDATE semillero SET 
                    nombre_semillero = @nombre,
                    linea_investigacion = @linea,
                    fecha_creacion_semillero = @fecha,
                    descripcion_semillero = @descripcion
                  WHERE ID_semillero = @id", con); // Comando SQL para actualizar los datos del semillero seleccionado en la base de datos, utilizando parámetros para evitar inyecciones SQL y asegurar que los datos se pasen correctamente a la consulta, y especificando la condición WHERE para actualizar solo el semillero con el ID correspondiente al seleccionado

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text)); // Agregamos el parámetro @id al comando SQL con el valor del ID del semillero seleccionado, convertido a entero para asegurarnos de que se pase correctamente a la consulta
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);// Agregamos el parámetro @nombre al comando SQL con el valor del campo de texto para el nombre del semillero, para actualizar el nombre del semillero en la base de datos
            cmd.Parameters.AddWithValue("@linea", textBox2.Text);// Agregamos el parámetro @linea al comando SQL con el valor del campo de texto para la línea de investigación del semillero, para actualizar la línea de investigación del semillero en la base de datos
            cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);// Agregamos el parámetro @fecha al comando SQL con el valor del DateTimePicker para la fecha de creación del semillero, para actualizar la fecha de creación del semillero en la base de datos
            cmd.Parameters.AddWithValue("@descripcion", textBox4.Text);//   Agregamos el parámetro @descripcion al comando SQL con el valor del campo de texto para la descripción del semillero, para actualizar la descripción del semillero en la base de datos


            cmd.ExecuteNonQuery();// Ejecutamos el comando SQL para actualizar los datos del semillero en la base de datos
            con.Close(); // Cerramos la conexión a la base de datos

            MessageBox.Show("Semillero actualizado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mostramos un mensaje de información al usuario indicando que el semillero ha sido actualizado correctamente
            CargarDatos();// Recargamos los datos para mostrar los cambios realizados en el DataGridView
            LimpiarCampos();//  Limpiamos los campos después de actualizar el semillero y recargamos los datos para mostrar los cambios realizados en el DataGridView
        }

        private void btnEliminarSemi_Click(object sender, EventArgs e)// Evento para desactivar un semillero seleccionado, cambiando su estado a "inactivo" en la base de datos, en lugar de eliminarlo físicamente, para mantener la integridad de los datos y permitir la posibilidad de reactivar el semillero en el futuro si es necesario
        {

            if (string.IsNullOrWhiteSpace(txtID.Text)) // Validación para asegurarse de que se haya seleccionado un semillero antes de intentar desactivarlo, verificando que el campo de texto txtID no esté vacío o contenga solo espacios en blanco
            {
                MessageBox.Show("Seleccione un semillero", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Mostramos un mensaje de información al usuario indicando que debe seleccionar un semillero antes de intentar desactivarlo, para evitar errores al intentar desactivar un semillero sin haber seleccionado uno previamente
                return;
            }

            DialogResult r = MessageBox.Show( // Mostramos un mensaje de confirmación al usuario antes de desactivar el semillero, para evitar desactivaciones accidentales
             "¿Desea desactivar este semillero?",
             "Advertencia",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning);

            if (r == DialogResult.No) return;// Si el usuario selecciona "No" en la confirmación, se cancela la operación y no se desactiva el semillero

            SqlConnection con = conexion.Conectar();// Establecemos la conexión a la base de datos utilizando el método Conectar de la clase Conexion
            SqlCommand cmd = new SqlCommand(
                "UPDATE semillero SET estado = 'inactivo' WHERE ID_semillero = @id", con); // Comando SQL para actualizar el estado del semillero a "inactivo" en la base de datos, utilizando un parámetro para evitar inyecciones SQL y asegurar que el ID del semillero se pase correctamente a la consulta, y especificando la condición WHERE para actualizar solo el semillero con el ID correspondiente al seleccionado

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));// Agregamos el parámetro @id al comando SQL para evitar inyecciones SQL y asegurarnos de que el ID del semillero se pase correctamente a la consulta

            con.Open();// Abrimos la conexión a la base de datos
            cmd.ExecuteNonQuery();// Ejecutamos el comando SQL para actualizar el estado del semillero a "inactivo" en la base de datos
            con.Close();// Cerramos la conexión a la base de datos

            MessageBox.Show("Semillero desactivado","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);// Mostramos un mensaje de información al usuario indicando que el semillero ha sido desactivado correctamente
            CargarDatos();// Recargamos los datos para mostrar los cambios realizados en el DataGridView
            LimpiarCampos(); // Limpiamos los campos después de desactivar el semillero y recargamos los datos para mostrar los cambios realizados en el DataGridView
        }


        void LimpiarCampos()// Método para limpiar los campos de texto y restablecer el valor del DateTimePicker después de realizar una operación (agregar, actualizar o eliminar) y recargar los datos para mostrar los cambios realizados en el DataGridView
        {
            txtID.Clear(); // Limpiamos el campo de texto txtID para eliminar el ID del semillero seleccionado después de realizar una operación, para evitar confusión al usuario sobre qué semillero está seleccionado actualmente
            textBox1.Clear();// Limpiamos el campo de texto textBox1 para eliminar el nombre del semillero seleccionado después de realizar una operación, para evitar confusión al usuario sobre qué semillero está seleccionado actualmente
            textBox2.Clear();// Limpiamos el campo de texto textBox2 para eliminar la línea de investigación del semillero seleccionado después de realizar una operación, para evitar confusión al usuario sobre qué semillero está seleccionado actualmente
            textBox4.Clear();// Limpiamos el campo de texto textBox4 para eliminar la descripción del semillero seleccionado después de realizar una operación, para evitar confusión al usuario sobre qué semillero está seleccionado actualmente
            txtLider.Clear();// Limpiamos el campo de texto txtLider para eliminar el nombre del líder del semillero seleccionado después de realizar una operación, para evitar confusión al usuario sobre qué semillero está seleccionado actualmente, aunque este campo no se utiliza para las operaciones de actualización o eliminación, ya que el líder se asigna a través de la gestión de investigadores y no se actualiza directamente desde este formulario
            dateTimePicker1.Value = DateTime.Now;// Restablecemos el valor del DateTimePicker a la fecha actual después de limpiar los campos
            dataGridView1.ClearSelection();// Limpiamos la selección del DataGridView para evitar que quede seleccionado un semillero después de realizar una operación, lo que puede causar confusión al usuario sobre qué semillero está seleccionado actualmente
        }

        private void btnActivarSemillero_Click(object sender, EventArgs e) // Evento para activar un semillero seleccionado, cambiando su estado a "activo" en la base de datos, para permitir que el semillero vuelva a estar disponible y visible en la lista de semilleros activos después de haber sido desactivado previamente
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))// Validación para asegurarse de que se haya seleccionado un semillero antes de intentar activarlo
            {
                MessageBox.Show("Seleccione un semillero", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);// Validación para asegurarse de que se haya seleccionado un semillero antes de intentar activarlo
                return;
            }

            DialogResult r = MessageBox.Show( "¿Desea activar este semillero?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // Mostramos un mensaje de confirmación al usuario antes de activar el semillero, para evitar activaciones accidentales

            if (r == DialogResult.No) return;// Si el usuario selecciona "No" en la confirmación, se cancela la operación y no se activa el semillero

            SqlConnection con = conexion.Conectar();// Establecemos la conexión a la base de datos utilizando el método Conectar de la clase Conexion
            SqlCommand cmd = new SqlCommand(
            "UPDATE semillero SET estado = 'activo' WHERE ID_semillero = @id", con);// Comando SQL para actualizar el estado del semillero a "activo" en la base de datos, utilizando un parámetro para evitar inyecciones SQL y asegurar que el ID del semillero se pase correctamente a la consulta, y especificando la condición WHERE para actualizar solo el semillero con el ID correspondiente al seleccionado

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));// Agregamos el parámetro @id al comando SQL para evitar inyecciones SQL y asegurarnos de que el ID del semillero se pase correctamente a la consulta
            con.Open();// Abrimos la conexión a la base de datos
            cmd.ExecuteNonQuery();// Ejecutamos el comando SQL para actualizar el estado del semillero a "activo" en la base de datos
            con.Close();// Cerramos la conexión a la base de datos

            MessageBox.Show("Semillero activado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);// Mostramos un mensaje de información al usuario indicando que el semillero ha sido activado correctamente
            CargarDatos();// Recargamos los datos para mostrar los cambios realizados en el DataGridView
            LimpiarCampos();// Limpiamos los campos después de activar el semillero y recargamos los datos para mostrar los cambios realizados en el DataGridView
        }
    } 
}
