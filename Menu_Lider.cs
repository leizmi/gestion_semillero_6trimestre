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
    public partial class Menu_Lider : Form
    {
        Conexion conexion = new Conexion();// creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        Consultas consultas = new Consultas(); // creamos una instancia de la clase Consultas para ejecutar las consultas a la base de datos
        Metodos metodo = new Metodos(); // creamos una instancia de la clase Metodos para ejecutar los metodos de la clase Metodos
        DataSet ds = new DataSet();// creamos una instancia de la clase DataSet para almacenar los datos obtenidos de la base de datos

        public Menu_Lider()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // llamamos al método sesiónCerrar de la clase Metodos para cerrar la sesión y volver al formulario de inicio de sesión.
        }

        private void Menu_Lider_Load(object sender, EventArgs e) // evento que se ejecuta al cargar el formulario, se encarga de cargar los datos de los semilleros los comboBox y en el dataGridView.
        {
            SqlConnection con = conexion.Conectar();// establecemos la conexion a la base de datos utilizando el método Conectar de la clase Conexion
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID_semillero, nombre_semillero FROM semillero", con); // creamos una instancia de la clase SqlDataAdapter para ejecutar la consulta a la base de datos y obtener los datos de los semilleros
            DataTable dt = new DataTable();// creamos una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos
            da.Fill(dt);//Ejecutamos la consulta y llenamos el DataTable con los datos obtenidos de la base de datos
            comboBox1.DataSource = dt;// se le asigna al comboBox1 el DataTable como fuente de datos para mostrar la información de los semilleros
            comboBox1.DisplayMember = "nombre_semillero"; // se le asigna al comboBox1 el nombre de la columna que se va a mostrar en el comboBox, en este caso el nombre del semillero
            comboBox1.ValueMember = "ID_semillero";// se le asigna al comboBox1 el nombre de la columna que se va a utilizar como valor para cada opción del comboBox, en este caso el ID del semillero

            CargarSemilleros();// llamamos al método CargarSemilleros para cargar los datos de los semilleros en el dataGridView
            CargarLineasInvestigacion();// llamamos al método CargarLineasInvestigacion para cargar los datos de las líneas de investigación en el comboBox2
            CargarSemillerosComboInvestigadores();// llamamos al método CargarSemillerosComboInvestigadores para cargar los datos de los semilleros en el comboBoxSemillero para la consulta de investigadores

        }
      
        private void CargarSemilleros()   // Método para cargar los datos de los semilleros en el dataGridView.
        {
            using (SqlConnection con = conexion.Conectar())// establecemos la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM semillero", con); // se crea una instancia de la clase SqlDataAdapter para ejecutar la consulta a la base de datos y obtener los datos de los semilleros, utilizando el método Conectar para establecer la conexion a la base de datos.
                DataTable dt = new DataTable(); // se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos.
                da.Fill(dt);
                dataGridView2.DataSource = dt;// se le asigna al dataGridView el dt como fuente de datos para mostrar la información de los semilleros
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;// se ajusta el tamaño de las columnas del dataGridView al tamaño del control para mejorar la visualización de los datos
            }
        }     

       
       
        private void btnMostraSemiDataGridView_Click(object sender, EventArgs e) //Se llama al método para cargar los datos de los semilleros en el dataGridView.
        {
            CargarSemilleros();// se llama al método CargarSemilleros para cargar los datos de los semilleros en el dataGridView y mostrar la información actualizada de los semilleros en el dataGridView.
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)/// este evento se ejecuta cada vez que el usuario presiona una tecla en el campo de texto textBox1
        {
            Metodos.SoloLetras(e); // se llama al método SoloLetras de la clase Metodos para validar que solo se ingresen letras en el campo de texto textBox1, que corresponde al nombre del semillero, mostrando un mensaje de advertencia si se intenta ingresar un carácter no permitido.
            MessageBox.Show("Solo se aceptan letras.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);// se muestra un mensaje de advertencia al usuario indicando que solo se aceptan letras en el campo de texto
            
        }

        private void btnAgregarSemi_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox1.Text == "")//validación para que no se intente agregar un semillero sin ingresar toda la información requerida, se muestra un mensaje. 
            {
                MessageBox.Show("Por favor ingrese la informacion pedida.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);// validación para que no se ingresen campos vacíos y se muestra un mensaje.
                return;
            }

            using (SqlConnection con = conexion.Conectar())// se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                string query = "INSERT INTO semillero (ID_semillero, nombre_semillero, fecha_creacion_semillero, descripcion_semillero, linea_investigacion) " + // se crea la consulta SQL para insertar un nuevo semillero en la base de datos, utilizando parámetros.
                               "VALUES (@id, @nombre, @fecha, @desc, @linea)";

                SqlCommand cmd = new SqlCommand(query, con);//Se usa SqlCommand para ejecutar la consulta SQL, se le asigna la consulta y la conexion a la base de datos.

                cmd.Parameters.AddWithValue("@id", textBox1.Text);// se le asigna a cada parámetro el valor correspondiente obtenido de los textBox y el dateTimePicker.
                cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@desc", textBox4.Text);
                cmd.Parameters.AddWithValue("@linea", textBox5.Text);

                if (con.State == ConnectionState.Closed) // se valida si la conexion a la base de datos está cerrada, si es así se abre la conexion para ejecutar la consulta.
                {
                    con.Open();// se abre la conexion a la base de datos utilizando el método Open de la clase SqlConnection.
                }

                cmd.ExecuteNonQuery();// ejecuta la consulta SQL utilizando este metodo que se utiliza para ejecutar consultas SQL que no devuelven resultados.

                MessageBox.Show("Semillero agregado correctamente","INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                CargarSemilleros(); // se llama al método CargarSemilleros para cargar los datos de los semilleros en el dataGridView y mostrar el nuevo semillero agregado.
                limpiarCampos(); // se llama al método limpiarCampos para limpiar los campos de texto y el dateTimePicker después de agregar un nuevo semillero.
            }
        }

        private void btnEliminarSemi_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")// validación para que no se intente eliminar un semillero sin seleccionar uno, se muestra un mensaje.
            {
                MessageBox.Show("Seleccione un semillero.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);// validación para que no se intente eliminar un semillero sin seleccionar uno, se muestra un mensaje.
                return;
            }

            using (SqlConnection con = conexion.Conectar()) // se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {                
                string validar = "SELECT COUNT(*) FROM proyecto WHERE ID_semillero = @id"; // se crea la consulta SQL para validar si el semillero que se desea eliminar tiene proyectos asociados, utilizando un parámetro para el ID del semillero.

                SqlCommand cmdValidar = new SqlCommand(validar, con); // Se crea un comando para ejecutar la consulta de validación usando la conexión activa.
                cmdValidar.Parameters.AddWithValue("@id", textBox1.Text); //Se asigna el ID ingresado por el usuario al parámetro de la consulta.

                int tieneProyectos = (int)cmdValidar.ExecuteScalar(); // Se ejecuta la consulta de validacion y se obtiene el resultado como un entero, que representa la cantidad de proyectos asociados al semillero.

                if (tieneProyectos > 0) //Si el resultado es mayor a 0 no se puede eliminar el semillero porque tiene proyectos asociados.
                {
                    MessageBox.Show("No se puede eliminar porque tiene proyectos asociados.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si el semillero no tiene proyectos asociados se puede eliminar creando la consulta SQL y usando el ID como parámetro para eliminar el semillero de la base de datos.
                string query = "DELETE FROM semillero WHERE ID_semillero = @id"; // se crea la consulta SQL para eliminar un semillero de la base de datos, utilizando un parámetro para el ID del semillero.

                SqlCommand cmd = new SqlCommand(query, con); // Se crea un comando para ejecutar la consulta de eliminación usando la conexión activa.
                cmd.Parameters.AddWithValue("@id", textBox1.Text); // Se asigna el ID ingresado por el usuario al parámetro de la consulta.

                cmd.ExecuteNonQuery(); // Se ejecuta la consulta de eliminacion
            }

            MessageBox.Show("Semillero eliminado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarSemilleros();// se llama al método CargarSemilleros para cargar los datos de los semilleros en el dataGridView y mostrar la lista actualizada después de eliminar el semillero.
            limpiarCampos();// se llama al método CargarSemilleros para cargar los datos de los semilleros en el dataGridView y mostrar la lista actualizada después de eliminar el semillero, y se llama al método limpiarCampos para limpiar los campos de texto y el dateTimePicker después de eliminar un semillero.
        }

        private void btnActualizarSemi_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "") // validación para que no se intente actualizar un semillero sin seleccionar uno o sin ingresar toda la información requerida, se muestra un mensaje.
            {
                MessageBox.Show("Por favor ingrese la informacion pedida.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);// validación para que no se intente actualizar un semillero sin seleccionar uno o sin ingresar toda la información requerida, se muestra un mensaje.
                return;
            }

            using (SqlConnection con = conexion.Conectar())// se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                string query = "UPDATE semillero SET ID_semillero=@id, nombre_semillero=@nombre, " +
                "fecha_creacion_semillero=@fecha, descripcion_semillero=@desc, linea_investigacion=@linea WHERE ID_semillero=@id"; // se crea la consulta SQL para actualizar un semillero en la base de datos, utilizando parámetros para cada campo que se desea actualizar y el ID del semillero como condición para identificar el semillero a actualizar.

                SqlCommand cmd = new SqlCommand(query, con);// Se crea un comando para ejecutar la consulta de actualización usando la conexión activa.

                cmd.Parameters.AddWithValue("@id", textBox1.Text);// se le asigna a cada parámetro el valor correspondiente obtenido de los textBox y el dateTimePicker.
                cmd.Parameters.AddWithValue("@nombre", textBox2.Text);// se le asigna a cada parámetro el valor correspondiente obtenido de los textBox y el dateTimePicker.
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);// se le asigna a cada parámetro el valor correspondiente obtenido de los textBox y el dateTimePicker.
                cmd.Parameters.AddWithValue("@desc", textBox4.Text);// se le asigna a cada parámetro el valor correspondiente obtenido de los textBox y el dateTimePicker.
                cmd.Parameters.AddWithValue("@linea", textBox5.Text);// se le asigna a cada parámetro el valor correspondiente obtenido de los textBox y el dateTimePicker.
                
                if (con.State == ConnectionState.Closed) // se valida si la conexion a la base de datos está cerrada, si es así se abre la conexion para ejecutar la consulta.
                {
                    con.Open();// se abre la conexion a la base de datos utilizando el método Open de la clase SqlConnection.
                }
                cmd.ExecuteNonQuery();// ejecuta la consulta SQL utilizando este metodo que se utiliza para ejecutar consultas SQL que no devuelven resultados.
            }

            MessageBox.Show("Semillero actualizado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// se muestra un mensaje de información al usuario indicando que el semillero se ha actualizado correctamente.
            CargarSemilleros(); // Se refresca el DataGridView
            limpiarCampos();// Se limpian los campos despues de actualizar el semillero
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e); // se llama al método SoloNumeros de la clase Metodos para validar que solo se ingresen números en el campo de texto textBox2, que corresponde a la descripción del semillero, mostrando un mensaje de advertencia si se intenta ingresar un carácter no permitido.
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
           Metodos.SoloNumeros(e); // se llama al método SoloNumeros de la clase Metodos para validar que solo se ingresen números en el campo de texto textBox5, que corresponde a la línea de investigación, mostrando un mensaje de advertencia si se intenta ingresar un carácter no permitido.
           
        }
        private void limpiarCampos() //Metodo para limpiar las cajas de texto y el dateTimePicker.
        {
            textBox2.Clear();// se limpia el contenido del textBox2 utilizando el método Clear, que borra el texto que se encuentra en el campo de texto.
            textBox5.Clear();
            textBox1.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = DateTime.Now;// se establece el valor del dateTimePicker a la fecha actual después de limpiar los campos.
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) // evento que se ejecuta al hacer clic en una celda del dataGridView, se encarga de mostrar la información del semillero seleccionado en los campos de texto y el dateTimePicker para poder actualizar o eliminar el semillero.
        {
            if (e.RowIndex >= 0) // se valida que el índice de la fila seleccionada sea mayor o igual a 0 para evitar errores al hacer clic en el encabezado del dataGridView.
            {
                DataGridViewRow fila = dataGridView2.Rows[e.RowIndex]; // se obtiene la fila seleccionada del dataGridView utilizando el índice de la fila proporcionado por el evento CellClick y se guarda en la variable fila.
                textBox1.Text = fila.Cells[0].Value.ToString(); // se asigna el valor de la celda correspondiente al ID del semillero a textBox1 para mostrar el ID del semillero seleccionado, utilizando el índice de la celda para acceder al valor y convertirlo a cadena de texto utilizando ToString().
                textBox2.Text = fila.Cells[1].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(fila.Cells[2].Value);// se convierte el valor de la celda correspondiente a la fecha de creación del semillero a un tipo DateTime utilizando Convert.ToDateTime para asignarlo al dateTimePicker, ya que el dateTimePicker requiere un valor de tipo DateTime para mostrar la fecha correctamente.
                textBox4.Text = fila.Cells[3].Value.ToString();
                textBox5.Text = fila.Cells[4].Value.ToString();

            }
        }
        private void btnBusquedaLineaInv_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)// validación para que no se intente realizar una búsqueda sin seleccionar una línea de investigación, se muestra un mensaje.
            {
                MessageBox.Show("Por favor debe seleccione una línea de investigación.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning); // validación para que no se intente realizar una búsqueda sin seleccionar una línea de investigación, se muestra un mensaje.
                return;
            }

            string lineaInvestigacion = comboBox2.SelectedValue.ToString();// se obtiene el valor seleccionado en el comboBox2, que representa la línea de investigación para la búsqueda, y se guarda en la variable lineaInvestigacion.

            using (SqlConnection con = conexion.Conectar())// se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter( "SELECT * FROM semillero WHERE linea_investigacion = @linea", con);// se crea la consulta SQL para seleccionar los semilleros que tienen la línea de investigación igual a la línea de investigación seleccionada, utilizando un parámetro para la línea de investigación en la consulta SQL para filtrar los resultados por esa línea de investigación.

                da.SelectCommand.Parameters.AddWithValue("@linea", lineaInvestigacion);// se asigna el valor de la línea de investigación seleccionada al parámetro de la consulta SQL para filtrar los semilleros por esa línea de investigación.

                DataTable dt = new DataTable();// se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL.
                da.Fill(dt);// se ejecuta la consulta SQL y se llena el DataTable con los datos obtenidos de la base de datos que cumplen con la condición de la línea de investigación seleccionada.

                dataGridView1.DataSource = dt;// se le asigna al dataGridView1 el DataTable como fuente de datos para mostrar los semilleros que cumplen con la condición de la línea de investigación seleccionada, mostrando así los resultados de la búsqueda por línea de investigación en el dataGridView.
            }
        }
        private void CargarLineasInvestigacion() // Método para cargar las líneas de investigación en el comboBox2 para la búsqueda por línea de investigación.
        {
            using (SqlConnection con = conexion.Conectar()) // se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT linea_investigacion FROM semillero", con); // se crea la consulta SQL para seleccionar las líneas de investigación distintas de los semilleros en la base de datos, utilizando el operador DISTINCT para obtener solo las líneas de investigación únicas y evitar duplicados en el comboBox2.

                DataTable dt = new DataTable(); // se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL, que en este caso serán las líneas de investigación distintas de los semilleros para mostrar en el comboBox2.
                da.Fill(dt);// se ejecuta la consulta SQL y se llena el DataTable con los datos obtenidos de la base de datos que representan las líneas de investigación distintas de los semilleros, para luego asignar ese DataTable como fuente de datos del comboBox2 y mostrar las líneas de investigación disponibles para la búsqueda por línea de investigación.

                comboBox2.DataSource = dt;// se le asigna al comboBox2 el DataTable como fuente de datos para mostrar las líneas de investigación disponibles en la base de datos.
                comboBox2.DisplayMember = "linea_investigacion";// se le asigna al comboBox2 el nombre de la columna que se va a mostrar en el comboBox, en este caso el nombre de la línea de investigación.
                comboBox2.ValueMember = "linea_investigacion";//    se le asigna al comboBox2 el nombre de la columna que se va a utilizar como valor para cada opción del comboBox, en este caso el nombre de la línea de investigación.
            }
        }
        private void btnConsuPorFecha_Click(object sender, EventArgs e) // Método para consultar los semilleros por fecha de creación utilizando el valor seleccionado en el dateTimePicker2.
        {
            DateTime fecha = dateTimePicker2.Value.Date;// se obtiene la fecha seleccionada en el dateTimePicker2 y se guarda en la variable fecha, sin guardar la hora para comparar solo la fecha en la consulta SQL.

            using (SqlConnection con = conexion.Conectar()) // se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM semillero WHERE CAST(fecha_creacion_semillero AS DATE) = @fecha", con); // se crea la consulta SQL para seleccionar los semilleros que tienen la fecha de creación igual a la fecha seleccionada, utilizando el operador CAST para convertir la columna de fecha a solo fecha sin hora y un parámetro para la fecha.

                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);// se asigna el valor de la fecha seleccionada al parámetro de la consulta SQL para filtrar los semilleros por esa fecha de creación, mostrando así los resultados de la búsqueda por fecha en el dataGridView1.
                DataTable dt = new DataTable();// se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL, que en este caso serán los semilleros que tienen la fecha de creación igual a la fecha seleccionada para mostrar en el dataGridView1.
                da.Fill(dt);// se ejecuta la consulta SQL y se llena el DataTable con los datos obtenidos de la base de datos que cumplen con la condición de la fecha de creación seleccionada, para luego asignar ese DataTable como fuente de datos del dataGridView1 y mostrar los semilleros que cumplen con esa condición.

                // validación para mostrar un mensaje si no se encuentran semilleros relacionados con la fecha seleccionada, y opcionalmente limpiar el dataGridView si no hay resultados.
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay semilleros relacionados con esa fecha.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; //s limpia el dataGridView si no hay resultados para mostrar y el null hace que el dataGridView se muestre vacío en lugar de mostrar una tabla vacía con las columnas. Esto mejora la experiencia del usuario al indicar claramente que no hay resultados para la consulta realizada.
                    return;
                }

                dataGridView1.DataSource = dt; // se le asigna al dataGridView1 el DataTable como fuente de datos para mostrar los semilleros que cumplen con la condición de la fecha de creación seleccionada, mostrando así los resultados de la búsqueda por fecha en el dataGridView1.
            }
        }

        private void btnConsultarInv_Click(object sender, EventArgs e)// Método para consultar los investigadores activos de un semillero seleccionado en el comboBoxSemillero, mostrando los resultados en el dataGridView3.
        {
            if (comboBoxSemillero.SelectedIndex == -1) // Se valida que se haya seleccionado un semillero en el comboBoxSemillero antes de realizar la consulta, si no se ha seleccionado ninguno se muestra un mensaje y se detiene la ejecución del método.
            {
                MessageBox.Show("Seleccione un semillero.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSemillero = Convert.ToInt32(comboBoxSemillero.SelectedValue);// El valor obtenido se convierte a entero utilizando Convert.ToInt32 para ser utilizado como parámetro en la consulta SQL, ya que el ID del semillero es un valor numérico que se utiliza para filtrar los investigadores por semillero en la base de datos.

            using (SqlConnection con = conexion.Conectar()) // se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT * 
                    FROM investigadores 
                     WHERE ID_semillero = @id 
                     AND ID_usuario IN 
                     (SELECT ID_usuario FROM usuario WHERE estado_usuario = @estado)", con);// se crea la consulta SQL para seleccionar los investigadores que pertenecen al semillero seleccionado y que tienen un estado de usuario "activo", utilizando parámetros para el ID del semillero y el estado del usuario en la consulta SQL para filtrar los resultados por esos criterios.

                da.SelectCommand.Parameters.AddWithValue("@id", idSemillero);// se asigna el valor del ID del semillero seleccionado al parámetro de la consulta SQL para filtrar los investigadores por ese semillero, mostrando así los resultados de la búsqueda de investigadores activos por semillero en el dataGridView3.
                da.SelectCommand.Parameters.AddWithValue("@estado", "activo");// se asigna el valor "activo" al parámetro de la consulta SQL para filtrar los investigadores por su estado de usuario, mostrando así solo los investigadores que están activos en el semillero seleccionado en el dataGridView3.

                DataTable dt = new DataTable();// se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL, que en este caso serán los investigadores que pertenecen al semillero seleccionado y que tienen un estado de usuario "activo" para mostrar en el dataGridView3.
                da.Fill(dt);

                if (dt.Rows.Count == 0)// validación para mostrar un mensaje si no se encuentran investigadores activos relacionados con el semillero seleccionado, y opcionalmente limpiar el dataGridView si no hay resultados.
                {
                    MessageBox.Show("No hay investigadores activos en este semillero.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView3.DataSource = null;// se limpia el dataGridView3 si no hay investigadores activos para mostrar, y el null hace que el dataGridView se muestre vacío en lugar de mostrar una tabla vacía con las columnas. Esto mejora la experiencia del usuario al indicar claramente que no hay resultados para la consulta realizada.
                    return;
                }

                dataGridView3.DataSource = dt;
            }
        }

        private void btnEliminarInv_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null) // validación para que no se intente desactivar un investigador sin seleccionar uno, se muestra un mensaje.
            {
                MessageBox.Show("Debe seleccionar un investigador.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);// validación para que no se intente desactivar un investigador sin seleccionar uno, se muestra un mensaje.
                return;
            }

            if (MessageBox.Show("¿Desea desactivar este investigador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)// se muestra un mensaje de confirmación para que el usuario confirme si desea desactivar al investigador seleccionado, si el usuario selecciona "No" se detiene la ejecución del método y no se realiza ningún cambio en la base de datos.
                return;

            int idInvestigador = Convert.ToInt32(dataGridView3.CurrentRow.Cells["ID_investigador"].Value); // se obtiene el ID del investigador seleccionado en el dataGridView3 para utilizarlo como parámetro en la consulta SQL para desactivar al investigador, utilizando el nombre de la columna "ID_investigador" para acceder al valor de esa celda y convertirlo a entero utilizando Convert.ToInt32, ya que el ID del investigador es un valor numérico que se utiliza para identificar al investigador en la base de datos.

            using (SqlConnection con = conexion.Conectar()) // se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                string query = @"UPDATE usuario 
                         SET estado_usuario = 'inactivo'
                         WHERE ID_usuario = (
                             SELECT ID_usuario 
                             FROM investigadores 
                             WHERE ID_investigador = @id)"; // se crea la consulta SQL para actualizar el estado del usuario asociado al investigador 

                SqlCommand cmd = new SqlCommand(query, con); // Se crea un comando para ejecutar la consulta de actualización 
                cmd.Parameters.AddWithValue("@id", idInvestigador); // se asigna el valor del ID del investigador seleccionado al parámetro de la consulta SQL para identificar al investigador a desactivar
                cmd.ExecuteNonQuery(); // ejecuta la consulta SQL utilizando este metodo que se utiliza para ejecutar consultas SQL que no devuelven resultados,
            }

            MessageBox.Show("Investigador desactivado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information); // se muestra un mensaje de información al usuario indicando que el investigador se ha desactivado correctamente después de ejecutar la consulta SQL para desactivar al investigador seleccionado en la base de datos, mostrando así una confirmación al usuario sobre la acción realizada.

            if (comboBoxSemillero.SelectedValue == null)// validación para que no se intente cargar los investigadores sin seleccionar un semillero, se muestra un mensaje.
            {
                MessageBox.Show("Seleccione un semillero"); // validación para que no se intente cargar los investigadores sin seleccionar un semillero, se muestra un mensaje.
                return;
            }

            int idSemillero = Convert.ToInt32(comboBoxSemillero.SelectedValue); // se obtiene el ID del semillero seleccionado en el comboBoxSemillero para utilizarlo como parámetro en la consulta SQL para cargar los investigadores del semillero seleccionado, utilizando el valor seleccionado en el comboBoxSemillero y convirtiéndolo a entero utilizando Convert.ToInt32, ya que el ID del semillero es un valor numérico que se utiliza para filtrar los investigadores por semillero en la base de datos.
            string estado = "activo"; // puedes cambiar a "inactivo" si quieres ver los desactivados

            CargarInvestigadores(idSemillero, estado);// se llama al método CargarInvestigadores para cargar los investigadores del semillero seleccionado con el estado "activo" después de desactivar al investigador seleccionado, mostrando así la lista actualizada de investigadores activos en el semillero seleccionado en el dataGridView3.
        }


        private void CargarInvestigadores(int idSemillero, string estado) // Método para cargar los investigadores de un semillero específico con un estado específico (activo o inactivo) en el dataGridView3, utilizando el ID del semillero y el estado del usuario como parámetros para filtrar los resultados en la consulta SQL.
        {
            using (SqlConnection con = conexion.Conectar()) // se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                string query = @"SELECT * FROM investigadores 
                         WHERE ID_semillero = @id 
                         AND ID_usuario IN (
                             SELECT ID_usuario 
                             FROM usuario 
                             WHERE estado_usuario = @estado)"; // se crea la consulta SQL para seleccionar los investigadores que pertenecen al semillero especificado y que tienen un estado de usuario igual al estado especificado, utilizando parámetros para el ID del semillero y el estado del usuario en la consulta SQL para filtrar los resultados por esos criterios, mostrando así la lista de investigadores que cumplen con esos criterios en el dataGridView3.

                SqlDataAdapter da = new SqlDataAdapter(query, con); // se crea un SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados obtenidos de la base de datos, utilizando la consulta SQL creada anteriormente y la conexión activa a la base de datos.
                da.SelectCommand.Parameters.AddWithValue("@id", idSemillero); // se asigna el valor del ID del semillero especificado al parámetro de la consulta SQL para filtrar los investigadores por ese semillero, mostrando así la lista de investigadores que pertenecen al semillero especificado en el dataGridView3.
                da.SelectCommand.Parameters.AddWithValue("@estado", estado); // se asigna el valor del estado del usuario especificado al parámetro de la consulta SQL para filtrar los investigadores por su estado de usuario, mostrando así solo los investigadores que cumplen con el estado especificado en el semillero seleccionado en el dataGridView3.

                DataTable dt = new DataTable(); // se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL, que en este caso serán los investigadores que pertenecen al semillero especificado y que tienen un estado de usuario igual al estado especificado para mostrar en el dataGridView3.
                da.Fill(dt); // se ejecuta la consulta SQL y se llena el DataTable con los datos obtenidos de la base de datos que cumplen con las condiciones del ID del semillero y el estado del usuario especificados, para luego asignar ese DataTable como fuente de datos del dataGridView3 y mostrar los investigadores que cumplen con esos criterios en el dataGridView3.

                dataGridView3.DataSource = dt;
            }
        }

        private void CargarSemillerosComboInvestigadores()// Método para cargar los semilleros en el comboBoxSemillero para la consulta de investigadores, permitiendo seleccionar un semillero para filtrar los investigadores por semillero.
        {
            using (SqlConnection con = conexion.Conectar())// se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_semillero, nombre_semillero FROM semillero", con); // se crea la consulta SQL para seleccionar el ID y el nombre de los semilleros, que se utilizarán para mostrar el nombre en el comboBox y el ID como valor para filtrar los investigadores por semillero.

                DataTable dt = new DataTable();// se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL, que en este caso serán el ID y el nombre de los semilleros para mostrar en el comboBoxSemillero y utilizar el ID como valor para filtrar los investigadores por semillero en la consulta SQL.
                da.Fill(dt);

                comboBoxSemillero.DataSource = dt; // se le asigna al comboBoxSemillero el DataTable como fuente de datos para mostrar los semilleros disponibles en la base de datos para la consulta de investigadores por semillero.
                comboBoxSemillero.DisplayMember = "nombre_semillero";// se le asigna al comboBoxSemillero el nombre de la columna que se va a mostrar en el comboBox, en este caso el nombre del semillero.
                comboBoxSemillero.ValueMember = "ID_semillero";// se le asigna al comboBoxSemillero el nombre de la columna que se va a utilizar como valor para cada opción del comboBox, en este caso el ID del semillero, que se utilizará para filtrar los investigadores por semillero en la consulta SQL.
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e) // Método para habilitar un investigador seleccionado en el dataGridView, cambiando su estado a "activo" en la base de datos y refrescando la lista de investigadores activos.
        {
            if (dataGridView3.CurrentRow == null)// validación para que no se intente habilitar un investigador sin seleccionar uno, se muestra un mensaje.
            {
                MessageBox.Show("Seleccione un investigador.");// validación para que no se intente habilitar un investigador sin seleccionar uno, se muestra un mensaje.
                return;
            }

            int idInvestigador = Convert.ToInt32( dataGridView3.CurrentRow.Cells["ID_investigador"].Value);// se obtiene el ID del investigador seleccionado en el dataGridView3 para utilizarlo como parámetro en la consulta SQL para habilitar al investigador.

            using (SqlConnection con = conexion.Conectar())// se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                string query = @"UPDATE usuario 
                               SET estado_usuario = 'activo'
                               WHERE ID_usuario = (
                               SELECT ID_usuario 
                               FROM investigadores 
                               WHERE ID_investigador = @id)"; 

                SqlCommand cmd = new SqlCommand(query, con);// Se crea un comando para ejecutar la consulta de actualización usando la conexión activa, que cambia el estado del usuario asociado al investigador seleccionado a "activo" en la base de datos, permitiendo así habilitar al investigador seleccionado y mostrar un mensaje de información al usuario indicando que el investigador se ha habilitado correctamente y luego refrescando la lista de investigadores activos para mostrar la lista actualizada después de habilitar al investigador seleccionado.
                cmd.Parameters.AddWithValue("@id", idInvestigador);// se asigna el valor del ID del investigador seleccionado al parámetro de la consulta SQL para identificar el investigador a habilitar, mostrando así un mensaje de información al usuario indicando que el investigador se ha habilitado correctamente y luego refrescando la lista de investigadores activos para mostrar la lista actualizada después de habilitar al investigador seleccionado.
                cmd.ExecuteNonQuery();// se ejecuta la consulta SQL utilizando este metodo que se utiliza para ejecutar consultas SQL que no devuelven resultados, en este caso para actualizar el estado del usuario asociado al investigador seleccionado a "activo" en la base de datos, mostrando así un mensaje de información al usuario indicando que el investigador se ha habilitado correctamente y luego refrescando la lista de investigadores activos para mostrar la lista actualizada después de habilitar al investigador seleccionado.
            }

            MessageBox.Show("Investigador habilitado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);// se muestra un mensaje de información al usuario indicando que el investigador se ha habilitado correctamente y luego refrescando la lista de investigadores activos para mostrar la lista actualizada después de habilitar al investigador seleccionado.

            int idSemillero = Convert.ToInt32(comboBoxSemillero.SelectedValue);
            string estado = "activo"; // puedes cambiar a "inactivo" si quieres ver los desactivados
            CargarInvestigadores(idSemillero, estado);
        }

        private void btnInactivos_Click(object sender, EventArgs e) // Método para consultar los investigadores inactivos de un semillero seleccionado en el comboBoxSemillero, mostrando los resultados en el dataGridView3.
        {
            int idSemillero = Convert.ToInt32(comboBoxSemillero.SelectedValue);// se obtiene el valor seleccionado en el comboBoxSemillero, que representa el ID del semillero para la búsqueda de investigadores inactivos, y se guarda en la variable idSemillero, convirtiéndolo a entero utilizando Convert.ToInt32 para ser utilizado como parámetro en la consulta SQL, ya que el ID del semillero es un valor numérico que se utiliza para filtrar los investigadores por semillero en la base de datos.

            using (SqlConnection con = conexion.Conectar())// se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter( // se crea la consulta SQL para seleccionar los investigadores que pertenecen al semillero seleccionado y que tienen un estado de "inactivo" en la base de datos, utilizando un parámetro para el ID del semillero y una subconsulta para filtrar por el estado del usuario.
                    @"SELECT * FROM investigadores 
                    WHERE ID_semillero = @id 
                    AND ID_usuario IN (
                    SELECT ID_usuario 
                    FROM usuario 
                    WHERE estado_usuario = 'inactivo')", con);

                da.SelectCommand.Parameters.AddWithValue("@id", idSemillero);// se asigna el valor del ID del semillero seleccionado al parámetro de la consulta SQL para filtrar los investigadores por semillero y estado inactivo
                DataTable dt = new DataTable();// se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL, que en este caso serán los investigadores que pertenecen al semillero seleccionado y que tienen un estado de "inactivo" para mostrar en el dataGridView3.
                da.Fill(dt);

                dataGridView3.DataSource = dt;
            }
        }

        

        private void btnRealizarBusquedaSemillero_Click_1(object sender, EventArgs e) // Método para realizar una búsqueda de semilleros por ID utilizando el valor seleccionado en el comboBox1, mostrando los resultados en el dataGridView1.
        {
            if (comboBox1.SelectedIndex == -1)// validación para que no se intente realizar una búsqueda sin seleccionar un ID de semillero, se muestra un mensaje.
            {
                MessageBox.Show("Por favor debe seleccionar una opción.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);// validación para que no se intente realizar una búsqueda sin seleccionar un ID de semillero, se muestra un mensaje.
                return;
            }

            int idSemillero = Convert.ToInt32(comboBox1.SelectedValue);// se obtiene el valor seleccionado en el comboBox1, que representa el ID del semillero para la búsqueda, y se guarda en la variable idSemillero, convirtiéndolo a entero utilizando Convert.ToInt32 para ser utilizado como parámetro en la consulta SQL, ya que el ID del semillero es un valor numérico que se utiliza para filtrar los semilleros por ID en la base de datos./

            using (SqlConnection con = conexion.Conectar()) // se establece la conexion a la base de datos utilizando el método Conectar de la clase Conexion y utilizamos using como estructura de control para abrir y cerrar la conexion automáticamente
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM semillero WHERE ID_semillero = @id", con); // se crea la consulta SQL para seleccionar el semillero que tiene el ID igual al ID seleccionado en el comboBox1, utilizando un parámetro para el ID del semillero en la consulta SQL para filtrar los resultados por ese ID.

                da.SelectCommand.Parameters.AddWithValue("@id", idSemillero); // se asigna el valor del ID del semillero seleccionado al parámetro de la consulta SQL para filtrar los semilleros por ese ID, mostrando así los resultados de la búsqueda por ID en el dataGridView1.
                DataTable dt = new DataTable();// se crea una instancia de la clase DataTable para almacenar los datos obtenidos de la base de datos después de ejecutar la consulta SQL, que en este caso será el semillero que tiene el ID igual al ID seleccionado para mostrar en el dataGridView1.
                da.Fill(dt);
                dataGridView1.DataSource = dt;// se le asigna al dataGridView1 el DataTable como fuente de datos para mostrar el semillero que cumple con la condición de ID seleccionado, mostrando así los resultados de la búsqueda por ID en el dataGridView1.
            }
        }


        private void btnGestionReuniones_Click(object sender, EventArgs e)
        {
            metodo.ReunionLider(); // se llama al método ReunionLider de la clase Metodos para mostrar el formulario de gestión de reuniones para líderes, permitiendo al líder gestionar las reuniones relacionadas con su semillero.
            this.Hide(); // se oculta el formulario actual para mostrar solo el formulario de gestión de reuniones.
        }

        private void btnGestionarSemillero_Click_1(object sender, EventArgs e)
        {
            metodo.menuLider(); // se llama al método menuLider de la clase Metodos para mostrar el formulario de gestión de semilleros para líderes, permitiendo al líder gestionar los semilleros relacionados con su rol.
            this.Hide();
        }

        private void btnRegistrarProyecto_Click_1(object sender, EventArgs e)
        {
            metodo.registrarProyecto(); // se llama al método registrarProyecto de la clase Metodos para mostrar el formulario de registro de proyectos, permitiendo al líder registrar un nuevo proyecto asociado a un semillero.
            this.Hide(); // se oculta el formulario actual para mostrar solo el formulario de registro de proyectos.
        }

        private void btnConsultarEventos_Click_1(object sender, EventArgs e)
        {
            metodo.consultarEventosLider(); // se llama al método consultarEventosLider de la clase Metodos para mostrar el formulario de consulta de eventos para líderes, permitiendo al líder consultar los eventos relacionados con su semillero.
            this.Hide();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // se llama al método sesiónCerrar de la clase Metodos para cerrar la sesión
        }
    } 
}