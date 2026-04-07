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
        DataSet ds = new DataSet(); // creamos una instancia de la clase DataSet para almacenar los datos obtenidos de la base de datos y poder manipularlos en el formulario

        public Registrar_proyecto()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // se llama al método sesiónCerrar de la clase Metodos para cerrar la sesión del usuario y volver al formulario de inicio de sesión, pasando el formulario actual como parámetro para cerrarlo después de mostrar el formulario de inicio de sesión
        }

        private void btnConsularEvento_Click(object sender, EventArgs e)
        {
            metodo.consultarEventosLider();// se llama al método consultarEventosLider de la clase Metodos para mostrar el formulario de consulta de eventos para el rol de líder
            this.Hide();
        }

        private void btnGestionarSemillero_Click(object sender, EventArgs e)
        {
            metodo.menuLider(); // se llama al método menuLider de la clase Metodos para mostrar el formulario de gestión de semilleros para el rol de líder
            this.Hide();
        }

        private void btnRegistrarProyecto_Click(object sender, EventArgs e)
        {
            metodo.registrarProyecto();// se llama al método registrarProyecto de la clase Metodos para mostrar el formulario de registro de proyectos para el rol de líder
            this.Hide();
        }

        private void CargarProyectos() // este método se encarga de cargar los proyectos registrados en la base de datos y mostrarlos en el DataGridView del formulario
        {
            using (SqlConnection con = conexion.Conectar())// se establece la conexión a la base de datos utilizando el método Conectar de la clase Conexion, y se utiliza un bloque using para asegurar que la conexión se cierre correctamente después de su uso
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM proyecto", con);// se crea una instancia de la clase SqlDataAdapter para ejecutar la consulta SQL que obtiene todos los registros de la tabla proyecto, utilizando la conexión establecida
                DataTable dt = new DataTable();// se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la consulta SQL
                da.Fill(dt);// se llena el DataTable con los datos obtenidos de la consulta SQL utilizando el método Fill del SqlDataAdapter

                dataGridView1.DataSource = dt;// se asigna el DataTable como fuente de datos del DataGridView para mostrar los proyectos en el formulario
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;// se ajusta el tamaño de las columnas del DataGridView para que se ajusten al ancho del control, utilizando la propiedad AutoSizeColumnsMode con el valor Fill
            }
        }

        private void Registrar_proyecto_Load(object sender, EventArgs e)
        {
            CargarProyectos();// se llama al método
        }

        private void btnRegisProye_Click(object sender, EventArgs e)
        {
            if (txtIdProyecto.Text == "" || txtNombreProyecto.Text == "" || txtActividadProyecto.Text == "")//  se valida que los campos de texto para el ID del proyecto, el nombre del proyecto y la actividad del proyecto no estén vacíos, y si alguno de ellos está vacío, se muestra un mensaje de error al usuario indicando que debe completar los campos antes de registrar el proyecto
            {
                MessageBox.Show("Por favor complete los campos.");// se muestra un mensaje de error al usuario indicando que debe completar los campos antes de registrar el proyecto
                return;
            }

            using (SqlConnection con = conexion.Conectar())// se establece la conexión a la base de datos utilizando el método Conectar de la clase Conexion, y se utiliza un bloque using para asegurar que la conexión se cierre correctamente después de su uso
            {
                if (con.State == ConnectionState.Closed)// se verifica si la conexión está cerrada, y si es así, se abre la conexión utilizando el método Open del SqlConnection
                {
                    con.Open();// se abre la conexión a la base de datos
                }

                string validar = "SELECT COUNT(*) FROM semillero WHERE ID_semillero = @id";// se define la consulta SQL para validar si el ID del semillero ingresado por el usuario existe en la tabla semillero, utilizando un parámetro @id para evitar inyecciones SQL

                SqlCommand cmdValidar = new SqlCommand(validar, con);// se crea una instancia de la clase
                cmdValidar.Parameters.AddWithValue("@id", txtIdSemillero.Text);// se agrega el valor del ID del semillero ingresado por el usuario como parámetro a la consulta SQL utilizando el método AddWithValue del SqlCommand

                int existe = (int)cmdValidar.ExecuteScalar();// se ejecuta la consulta SQL utilizando el método ExecuteScalar del SqlCommand, que devuelve el resultado de la consulta como un objeto, y se convierte a entero para verificar si el ID del semillero existe (si el resultado es mayor que 0) o no (si el resultado es 0)

                if (existe == 0)// si el resultado de la consulta SQL es 0, significa que el ID del semillero ingresado por el usuario no existe en la tabla semillero, y se muestra un mensaje de advertencia al usuario indicando que debe crear el semillero antes de registrar el proyecto
                {
                    MessageBox.Show("El ID de semillero no existe.\nPrimero debe crear el semillero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔥 2. INSERTAR PROYECTO (solo si pasó la validación)
                string query = "INSERT INTO proyecto (ID_proyecto, nombre_proyecto, actividad_proyecto, fecha_inicio_proyecto, fecha_fin_proyecto, ID_semillero) " +
                               "VALUES (@idProyecto, @nombre, @actividad, @fechaInicio, @fechaFin, @IdSemillero)";

                SqlCommand cmd = new SqlCommand(query, con);// se crea una instancia de la clase

                cmd.Parameters.AddWithValue("@idProyecto", txtIdProyecto.Text);// se agrega el valor del ID del proyecto ingresado por el usuario como parámetro a la consulta SQL utilizando el método AddWithValue del SqlCommand
                cmd.Parameters.AddWithValue("@nombre", txtNombreProyecto.Text);// se agrega el valor del nombre del proyecto ingresado por el usuario como parámetro a la consulta SQL utilizando el método AddWithValue del SqlCommand
                cmd.Parameters.AddWithValue("@actividad", txtActividadProyecto.Text);// se agrega el valor de la actividad del proyecto ingresado por el usuario como parámetro a la consulta SQL utilizando el método AddWithValue del SqlCommand
                cmd.Parameters.AddWithValue("@fechaInicio", dateTimePicker1.Value);// se agrega el valor de la fecha de inicio del proyecto seleccionada por el usuario como parámetro a la consulta SQL utilizando el método AddWithValue del SqlCommand
                cmd.Parameters.AddWithValue("@fechaFin", dateTimePicker2.Value);// se agrega el valor de la fecha de fin del proyecto seleccionada por el usuario como parámetro a la consulta SQL utilizando el método AddWithValue del SqlCommand
                cmd.Parameters.AddWithValue("@IdSemillero", txtIdSemillero.Text);// se agrega el valor del ID del semillero ingresado por el usuario como parámetro a la consulta SQL utilizando el método AddWithValue del SqlCommand
                cmd.ExecuteNonQuery();// se ejecuta la consulta SQL utilizando el método ExecuteNonQuery del SqlCommand, que ejecuta la consulta y devuelve el número de filas afectadas, pero en este caso no se utiliza el resultado ya que solo se necesita insertar el proyecto en la base de datos
            }

            MessageBox.Show("Proyecto registrado correctamente");// se muestra un mensaje de confirmación al usuario indicando que el proyecto se ha registrado correctamente en la base de dato
            CargarProyectos();// se llama al método CargarProyectos para actualizar el DataGridView con el nuevo proyecto registrado en la base de datos
            limpiarCampos();// se llama al método limpiarCampos para limpiar los campos de texto y restablecer el valor del DateTimePicker después de registrar el proyecto, para que el usuario pueda ingresar un nuevo proyecto sin tener que borrar manualmente los campos anteriores
        }

        private void limpiarCampos()// este método se encarga de limpiar los campos de texto y restablecer el valor del DateTimePicker después de registrar un proyecto, para que el usuario pueda ingresar un nuevo proyecto sin tener que borrar manualmente los campos anteriores
        {
            txtIdProyecto.Clear();// se limpia el campo de texto para el ID del proyecto utilizando el método Clear del TextBox
            txtNombreProyecto.Clear();// se limpia el campo de texto para el nombre del proyecto utilizando el método Clear del TextBox
            txtActividadProyecto.Clear();// se limpia el campo de texto para la actividad del proyecto utilizando el método Clear del TextBox
            txtIdSemillero.Clear();// se limpia el campo de texto para el ID del semillero utilizando el método Clear del TextBox
            dateTimePicker1.Value = DateTime.Now;// se restablece el valor del DateTimePicker para la fecha de inicio del proyecto al valor predeterminado (la fecha actual) utilizando la propiedad Value del DateTimePicker
        }

        private void txtIdProyecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);// se llama al método SoloNumeros de la clase Metodos para validar que solo se ingresen números en el campo de texto para el ID del proyecto, pasando el evento KeyPress como parámetro para validar cada tecla presionada por el usuario
        }

        private void txtNombreProyecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloLetras(e);// se llama al método SoloLetras de la clase Metodos para validar que solo se ingresen letras en el campo de texto para el nombre del proyecto, pasando el evento KeyPress como parámetro para validar cada tecla presionada por el usuario
        }

        private void txtIdSemillero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);// se llama al método SoloNumeros de la clase Metodos para validar que solo se ingresen números en el campo de texto para el ID del semillero, pasando el evento KeyPress como parámetro para validar cada tecla presionada por el usuario
        }
    }
}
