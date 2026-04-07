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
    public partial class Form3 : Form
    {
        Metodos metodo = new Metodos();// Se crea una instancia de la clase Metodos para poder acceder a sus métodos y mostrar los formularios correspondientes a las funciones del administrador.
        Conexion Conexion = new Conexion();// Se crea una instancia de la clase Conexion para poder establecer la conexión a la base de datos y ejecutar las consultas SQL necesarias para cargar los datos de los investigadores y semilleros en el formulario.

        public Form3()
        {
            InitializeComponent();
        }

        // Botones para navegar entre formularios del administrador, cada uno llama a un método específico de la clase Metodos para mostrar el formulario correspondiente y luego cierra o oculta el formulario actual.
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            metodo.menuAdmin();// Se llama al método menuAdmin() de la clase Metodos para mostrar el formulario del menú principal del administrador.
            this.Close();// Se cierra el formulario actual para volver al menú principal del administrador.
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        { }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero();// Se llama al método Admi_GestionSemillero() de la clase Metodos para mostrar el formulario de gestión de semilleros del administrador.
            this.Close();//Se cierra el formulario actual para mostrar el formulario de gestión de semilleros del administrador. 
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            metodo.Admi_Reportes();// Se llama al método Admi_Reportes() de la clase Metodos para mostrar el formulario de reportes del administrador.
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // Se llama al método sesiónCerrar() de la clase Metodos para mostrar un mensaje de confirmación antes de cerrar la sesión y volver al formulario de inicio de sesión. Se pasa el formulario actual como argumento para que pueda ser cerrado si el usuario confirma que desea salir.
        }

        private void btnGestionEventos_Click(object sender, EventArgs e)
        {
            metodo.admi_GestionEventos(); // Se llama al método admi_GestionEventos() de la clase Metodos para mostrar el formulario de gestión de eventos del administrador.
            this.Hide();
        }

        void CargarUsuarios() // Metodo para cargar los usuarios en el DataGridView, se conecta a la base de datos, ejecuta una consulta SQL para obtener los datos de los investigadores y sus usuarios relacionados, y luego llena un DataTable con esos datos para mostrarlo en el DataGridView.
        {
            SqlConnection con = Conexion.Conectar();// Se establece la conexión a la base de datos utilizando el método Conectar() de la clase Conexion.
            string query = @"SELECT 
                             i.ID_investigador,
                             i.nombre_investigador,
                             i.apellido_investigador,
                             i.tipo_documento,
                             i.edad_investigador,
                             i.telefono_investigador,
                             (SELECT u.correo_usuario 
                             FROM usuario u 
                             WHERE u.ID_usuario = i.ID_usuario) AS correo_usuario,
                             (SELECT u.contraseña_usuario 
                             FROM usuario u 
                             WHERE u.ID_usuario = i.ID_usuario) AS contraseña_usuario,
                             (SELECT u.tipo_usuario 
                             FROM usuario u 
                             WHERE u.ID_usuario = i.ID_usuario) AS tipo_usuario,
                             (SELECT u.estado_usuario 
                             FROM usuario u 
                             WHERE u.ID_usuario = i.ID_usuario) AS estado_usuario
                             FROM investigadores i";// Consulta SQL para obtener los datos de los investigadores y sus usuarios relacionados, se utilizan subconsultas para obtener los datos del usuario asociado a cada investigador.

            SqlDataAdapter da = new SqlDataAdapter(query, con);// Se crea un SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados.
            DataTable dt = new DataTable();// Se crea un DataTable para almacenar los datos obtenidos de la consulta SQL.
            da.Fill(dt);// Se llena el DataTable con los datos obtenidos de la consulta SQL.

            dataGridView1.DataSource = dt;// Se asigna el DataTable como fuente de datos del DataGridView para mostrar los datos de los investigadores y sus usuarios relacionados en el formulario.
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarUsuarios(); // Se llama al método CargarUsuarios() para cargar los datos de los investigadores y sus usuarios relacionados en el DataGridView cuando se carga el formulario.
            CargarSemilleros();// Se llama al método CargarSemilleros() para cargar los semilleros disponibles en el ComboBox cuando se carga el formulario.
        }

        private void btnBuscarFiltro_Click(object sender, EventArgs e)
        {

            // Validacion de filtro seleccionado y valor ingresado, si no se cumple alguna de las condiciones, se muestra un mensaje de error y se detiene la ejecución del método.
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de filtro", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFiltro.Text))// Se verifica si el campo de texto para ingresar el valor del filtro está vacío o contiene solo espacios en blanco, si es así, se muestra un mensaje de error y se detiene la ejecución del método.
            {
                MessageBox.Show("Debe ingresar un valor para buscar", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filtro = comboBox1.SelectedItem.ToString();// Se obtiene el tipo de filtro seleccionado en el ComboBox y se guarda en la variable filtro para usarlo en la construcción de la consulta SQL.
            string valor = textBoxFiltro.Text.Trim();// Se obtiene el valor ingresado en el campo de texto para el filtro, se elimina cualquier espacio en blanco al inicio o al final del texto y se guarda en la variable valor para usarlo en la construcción de la consulta SQL.

            SqlConnection con = Conexion.Conectar();// Se establece la conexión a la base de datos utilizando el método Conectar() de la clase Conexion.

            string query = @"SELECT 
                i.ID_investigador,
                i.nombre_investigador,
                i.apellido_investigador,
                i.tipo_documento,
                i.edad_investigador,
                i.telefono_investigador,

                (SELECT u.correo_usuario 
                FROM usuario u 
                WHERE u.ID_usuario = i.ID_usuario) AS correo_usuario,

                (SELECT u.contraseña_usuario 
                FROM usuario u 
                WHERE u.ID_usuario = i.ID_usuario) AS contraseña_usuario,

                (SELECT u.tipo_usuario 
                FROM usuario u 
                WHERE u.ID_usuario = i.ID_usuario) AS tipo_usuario,

                (SELECT u.estado_usuario 
                FROM usuario u 
                WHERE u.ID_usuario = i.ID_usuario) AS estado_usuario

                FROM investigadores i
                WHERE ";// Se construye la consulta SQL para buscar los investigadores y sus usuarios relacionados según el filtro seleccionado y el valor ingresado. Se utiliza una cláusula WHERE para filtrar los resultados según el tipo de filtro seleccionado, y se agregan condiciones dinámicamente a la consulta SQL según el filtro ingresado por el usuario.

            // Busca registros que contengan el texto ingresado
            if (filtro == "ID investigador")// Si el filtro seleccionado es "ID investigador", se agrega una condición a la consulta SQL para buscar registros donde el ID del investigador sea igual al valor ingresado.
                query += "i.ID_investigador = @valor"; //se usa query += para agregar condiciones a la consulta SQL de forma dinámica según el filtro ingresado por el usuario.
            else if (filtro == "Nombre investigador")// Si el filtro seleccionado es "Nombre investigador", se agrega una condición a la consulta SQL para buscar registros donde el nombre del investigador contenga el valor ingresado, utilizando el operador LIKE para realizar una búsqueda de texto parcial.
                query += "i.nombre_investigador LIKE '%' + @valor + '%'";// El operador LIKE se utiliza para buscar registros que contengan el texto ingresado en cualquier parte del campo nombre_investigador, y se utilizan los caracteres comodín '%' para indicar que puede haber cualquier texto antes o después del valor ingresado.
            else if (filtro == "Apellido investigador")// Si el filtro seleccionado es "Apellido investigador", se agrega una condición a la consulta SQL para buscar registros donde el apellido del investigador contenga el valor ingresado, utilizando el operador LIKE para realizar una búsqueda de texto parcial.
                query += "i.apellido_investigador LIKE '%' + @valor + '%'";// El operador LIKE se utiliza para buscar registros que contengan el texto ingresado en cualquier parte del campo apellido_investigador, y se utilizan los caracteres comodín '%' para indicar que puede haber cualquier texto antes o después del valor ingresado.
            else if (filtro == "Tipo de documento")// Si el filtro seleccionado es "Tipo de documento", se agrega una condición a la consulta SQL para buscar registros donde el tipo de documento del investigador contenga el valor ingresado, utilizando el operador LIKE para realizar una búsqueda de texto parcial.
                query += "i.tipo_documento LIKE '%' + @valor + '%'";// El operador LIKE se utiliza para buscar registros que contengan el texto ingresado en cualquier parte del campo tipo_documento, y se utilizan los caracteres comodín '%' para indicar que puede haber cualquier texto antes o después del valor ingresado.
            else if (filtro == "Tipo de usuario")// Si el filtro seleccionado es "Tipo de usuario", se agrega una condición a la consulta SQL para buscar registros donde el tipo de usuario asociado al investigador contenga el valor ingresado, utilizando el operador LIKE para realizar una búsqueda de texto parcial. Se utiliza una subconsulta para obtener el tipo de usuario del investigador desde la tabla usuario.
                query += @"(SELECT u.tipo_usuario 
                    FROM usuario u 
                    WHERE u.ID_usuario = i.ID_usuario) LIKE '%' + @valor + '%'";// El operador LIKE se utiliza para buscar registros que contengan el texto ingresado en cualquier parte del campo tipo_usuario, y se utilizan los caracteres comodín '%' para indicar que puede haber cualquier texto antes o después del valor ingresado.

            SqlDataAdapter da = new SqlDataAdapter(query, con);// Se crea un SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados. Se pasa la consulta SQL construida dinámicamente y la conexión a la base de datos como argumentos al constructor del SqlDataAdapter.
            da.SelectCommand.Parameters.AddWithValue("@valor", valor);// Se agrega el valor del filtro como parámetro a la consulta SQL para evitar problemas de inyección SQL y asegurar que el valor se maneje correctamente en la consulta.

            DataTable dt = new DataTable();// Se crea un DataTable para almacenar los datos obtenidos de la consulta SQL.
            da.Fill(dt);// Se llena el DataTable con los datos obtenidos de la consulta SQL.

            // Se valida si la consulta devolvió resultados, si no se encontraron registros que coincidan con el filtro ingresado, se muestra un mensaje de información y se limpia el DataGridView.
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Se muestra un mensaje de información al usuario indicando que no se encontraron resultados que coincidan con el filtro ingresado.
                dataGridView1.DataSource = null;// Se limpia el DataGridView estableciendo su fuente de datos a null para mostrar que no hay resultados.
                return;
            }

            dataGridView1.DataSource = dt;// Si se encontraron resultados, se asigna el DataTable como fuente de datos del DataGridView para mostrar los resultados de la búsqueda en el formulario
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // 🔴 VALIDAR SELECCIÓN
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario del listado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 🔴 VALIDAR CAMPOS
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
                string.IsNullOrWhiteSpace(txtapellido.Text) ||
                string.IsNullOrWhiteSpace(txtedad.Text) ||
                string.IsNullOrWhiteSpace(txttelefono.Text) ||
                string.IsNullOrWhiteSpace(txtcorreo.Text) ||
                string.IsNullOrWhiteSpace(txtcontraseña.Text) ||
                comboBox4.SelectedIndex == -1 || // rol
                comboBox3.SelectedIndex == -1 || // estado
                comboBoxSemillero.SelectedIndex == -1 ||
                comboBox_TipoDocumento.SelectedIndex == -1) // tipo documento
            {
                MessageBox.Show("Debe completar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔴 VALIDAR NUMÉRICOS
            if (!int.TryParse(txtedad.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido");
                return;
            }

            try
            {
                SqlConnection con = Conexion.Conectar();
                int idInv = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_investigador"].Value);

                // 🔍 Obtener ID_usuario
                SqlCommand getIdUser = new SqlCommand("SELECT ID_usuario FROM investigadores WHERE ID_investigador = @id", con);
                getIdUser.Parameters.AddWithValue("@id", idInv);
                int idUsuario = Convert.ToInt32(getIdUser.ExecuteScalar());

                // 🔄 ACTUALIZAR INVESTIGADOR
                string updateInv = @"UPDATE investigadores SET
                            nombre_investigador = @nombre,
                            apellido_investigador = @apellido,
                            tipo_documento = @doc,
                            edad_investigador = @edad,
                            telefono_investigador = @telefono,
                            ID_semillero = @semillero
                            WHERE ID_investigador = @id";

                SqlCommand cmdInv = new SqlCommand(updateInv, con);
                cmdInv.Parameters.AddWithValue("@nombre", txtnombre.Text);
                cmdInv.Parameters.AddWithValue("@apellido", txtapellido.Text);
                cmdInv.Parameters.AddWithValue("@edad", edad);
                cmdInv.Parameters.AddWithValue("@telefono", txttelefono.Text);
                cmdInv.Parameters.AddWithValue("@semillero", comboBoxSemillero.SelectedValue);
                cmdInv.Parameters.AddWithValue("@id", idInv);
                cmdInv.Parameters.AddWithValue("@doc", comboBox_TipoDocumento.Text);
                cmdInv.ExecuteNonQuery();

                // 🔄 ACTUALIZAR USUARIO
                string updateUser = @"UPDATE usuario SET
                            correo_usuario = @correo,
                            contraseña_usuario = @contra,
                            tipo_usuario = @rol,
                            estado_usuario = @estado
                            WHERE ID_usuario = @idUser";

                SqlCommand cmdUser = new SqlCommand(updateUser, con);
                cmdUser.Parameters.AddWithValue("@correo", txtcorreo.Text);
                cmdUser.Parameters.AddWithValue("@contra", txtcontraseña.Text);
                cmdUser.Parameters.AddWithValue("@rol", comboBox4.Text);
                cmdUser.Parameters.AddWithValue("@estado", comboBox3.Text);
                cmdUser.Parameters.AddWithValue("@idUser", idUsuario);
                cmdUser.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Usuario actualizado correctamente", "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];// Obtener los valores de la fila seleccionada y asignarlos a los campos correspondientes para su edición

                txtnombre.Text = fila.Cells["nombre_investigador"].Value.ToString();// Se asigna el valor del campo nombre_investigador de la fila seleccionada en el DataGridView al campo de texto txtnombre para mostrarlo en el formulario y permitir su edición.
                txtapellido.Text = fila.Cells["apellido_investigador"].Value.ToString();

                txtedad.Text = fila.Cells["edad_investigador"].Value.ToString();
                txttelefono.Text = fila.Cells["telefono_investigador"].Value.ToString();
                txtcorreo.Text = fila.Cells["correo_usuario"].Value.ToString();
                txtcontraseña.Text = fila.Cells["contraseña_usuario"].Value.ToString();

                             comboBox4.Text = fila.Cells["tipo_usuario"].Value.ToString();
                             comboBox3.Text = fila.Cells["estado_usuario"].Value.ToString();
                comboBox_TipoDocumento.Text = fila.Cells["tipo_documento"].Value.ToString();
            }
        }

        void LimpiarCampos()// Método para limpiar los campos de texto y restablecer los ComboBox después de realizar una acción como agregar o actualizar un usuario, se borra el contenido de los campos de texto y se restablecen los ComboBox a su estado inicial, además de quitar la selección del DataGridView para mostrar que no hay ningún registro seleccionado.
        {
            // TextBox
            txtnombre.Clear();
            txtapellido.Clear();
            txtedad.Clear();
            txttelefono.Clear();
            txtcorreo.Clear();
            txtcontraseña.Clear();

            // ComboBox
            comboBox4.SelectedIndex = -1; // tipo usuario
            comboBox3.SelectedIndex = -1; // estado
            comboBox_TipoDocumento.SelectedIndex = -1; // tipo documento

            // Quitar selección del DataGridView
            dataGridView1.ClearSelection();
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios, se verifica que todos los campos necesarios para crear una nueva cuenta de investigador estén completos, si alguno de los campos está vacío o no se ha seleccionado un valor en los ComboBox, se muestra un mensaje de error y se detiene la ejecución del método.
            if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtapellido.Text) || comboBox_TipoDocumento.SelectedIndex == -1  ||
                string.IsNullOrWhiteSpace(txtedad.Text) || string.IsNullOrWhiteSpace(txttelefono.Text) || string.IsNullOrWhiteSpace(txtcorreo.Text) ||
                string.IsNullOrWhiteSpace(txtcontraseña.Text) || comboBox4.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);// Se muestra un mensaje de información al usuario indicando que debe completar todos los campos necesarios para crear una nueva cuenta de investigador.
                return;
            }

            SqlConnection con = Conexion.Conectar();// Se establece la conexión a la base de datos utilizando el método Conectar() de la clase Conexion para realizar las operaciones necesarias para agregar una nueva cuenta de investigador, como generar un nuevo ID de usuario, insertar los datos en las tablas usuario e investigadores, y manejar cualquier error que pueda ocurrir durante el proceso.

            try
            {
                //  Generar ID usuario automáticamente
                SqlCommand cmdIdUsuario = new SqlCommand("SELECT ISNULL(MAX(ID_usuario),0)+1 FROM usuario", con);
                int nuevoIdUsuario = Convert.ToInt32(cmdIdUsuario.ExecuteScalar());

                //  Insertar en usuario
                string insertUsuario = @"INSERT INTO usuario 
                                (ID_usuario, estado_usuario, correo_usuario, contraseña_usuario, tipo_usuario)
                                VALUES (@id, @estado, @correo, @contra, @tipo)";

                SqlCommand cmdUsuario = new SqlCommand(insertUsuario, con);// Se crea un SqlCommand para ejecutar la consulta SQL de inserción en la tabla usuario. Se pasa la consulta SQL y la conexión a la base de datos como argumentos al constructor del SqlCommand.
                cmdUsuario.Parameters.AddWithValue("@id", nuevoIdUsuario);
                cmdUsuario.Parameters.AddWithValue("@estado", comboBox3.Text);
                cmdUsuario.Parameters.AddWithValue("@correo", txtcorreo.Text);
                cmdUsuario.Parameters.AddWithValue("@contra", txtcontraseña.Text);
                cmdUsuario.Parameters.AddWithValue("@tipo", comboBox4.Text);
                cmdUsuario.ExecuteNonQuery();

                // Se mira en la base de datos los ID maximos, despues se añade el siguiente ID disponible para insertar un nuevo investigador
                SqlCommand cmdIdInv = new SqlCommand("SELECT ISNULL(MAX(ID_investigador),0)+1 FROM investigadores", con);
                int nuevoIdInv = Convert.ToInt32(cmdIdInv.ExecuteScalar());

                //  Insertar en investigadores
                string insertInvestigador = @"INSERT INTO investigadores
                                    (ID_investigador, nombre_investigador, apellido_investigador, tipo_documento,
                                     edad_investigador, telefono_investigador, ID_usuario, ID_semillero)
                                    VALUES (@idInv, @nombre, @apellido, @doc, @edad, @telefono, @idUsuario, @semillero)";

                SqlCommand cmdInv = new SqlCommand(insertInvestigador, con);// Se crea un SqlCommand para ejecutar la consulta SQL de inserción en la tabla investigadores. Se pasa la consulta SQL y la conexión a la base de datos como argumentos al constructor del SqlCommand.
                cmdInv.Parameters.AddWithValue("@idInv", nuevoIdInv);
                cmdInv.Parameters.AddWithValue("@nombre", txtnombre.Text);
                cmdInv.Parameters.AddWithValue("@apellido", txtapellido.Text);
                cmdInv.Parameters.AddWithValue("@doc", comboBox_TipoDocumento.Text);
                cmdInv.Parameters.AddWithValue("@edad", Convert.ToInt32(txtedad.Text));
                cmdInv.Parameters.AddWithValue("@telefono", txttelefono.Text);
                cmdInv.Parameters.AddWithValue("@idUsuario", nuevoIdUsuario);
                cmdInv.Parameters.AddWithValue("@semillero", comboBoxSemillero.SelectedValue);
                cmdInv.ExecuteNonQuery();// Se ejecuta la consulta SQL de inserción en la tabla investigadores utilizando el método ExecuteNonQuery() del SqlCommand, que se utiliza para ejecutar consultas SQL que no devuelven resultados, como las consultas de inserción.

                MessageBox.Show("Investigador agregado correctamente");// Se muestra un mensaje de información al usuario indicando que el investigador se ha agregado correctamente a la base de datos.
                CargarUsuarios();// Se recarga el DataGridView para mostrar el nuevo investigador agregado a la base de datos.
                LimpiarCampos();// Se limpian los campos de texto y se restablecen los ComboBox para permitir la entrada de una nueva cuenta de investigador si el usuario desea agregar otro investigador después de agregar el primero.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);// Si ocurre algún error durante el proceso de agregar una nueva cuenta de investigador, se muestra un mensaje de error al usuario con la información del error.
            }

            con.Close();// Se cierra la conexión a la base de datos después de completar el proceso de agregar una nueva cuenta de investigador, independientemente de si el proceso fue exitoso o si ocurrió un error.
        }

        void CargarSemilleros() // Método para cargar los semilleros en el ComboBox, se conecta a la base de datos, ejecuta una consulta SQL para obtener los semilleros disponibles y luego llena un DataTable con esos datos para mostrarlo en el ComboBox.
        {
            SqlConnection con = Conexion.Conectar();// Se establece la conexión a la base de datos utilizando el método Conectar() de la clase Conexion para realizar la consulta SQL necesaria para obtener los semilleros disponibles y mostrarlo en el ComboBox.

            string query = "SELECT ID_semillero, nombre_semillero FROM semillero WHERE ID_semillero >= 2001";// Consulta SQL para obtener los semilleros disponibles, se seleccionan los campos ID_semillero y nombre_semillero de la tabla semillero, y se filtran los resultados para incluir solo aquellos semilleros cuyo ID sea mayor o igual a 2001, lo que indica que son semilleros activos o disponibles para asignar a los investigadores.

            SqlDataAdapter da = new SqlDataAdapter(query, con);// Se crea un SqlDataAdapter para ejecutar la consulta SQL y llenar un DataTable con los resultados. Se pasa la consulta SQL y la conexión a la base de datos como argumentos al constructor del SqlDataAdapter.
            DataTable dt = new DataTable();// Se crea un DataTable para almacenar los datos obtenidos de la consulta SQL.
            da.Fill(dt);// Se llena el DataTable con los datos obtenidos de la consulta SQL.

            comboBoxSemillero.DataSource = dt;// Se asigna el DataTable como fuente de datos del ComboBox para mostrar los semilleros disponibles en el formulario. El ComboBox se llenará con los nombres de los semilleros obtenidos de la consulta SQL, y cada elemento del ComboBox tendrá un valor asociado que corresponde al ID del semillero.
            comboBoxSemillero.DisplayMember = "nombre_semillero"; // lo que ve el usuario
            comboBoxSemillero.ValueMember = "ID_semillero"; // lo que se guarda
        }

        private void btn_ver_Inactivos_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.Conectar();// Se establece la conexión a la base de datos utilizando el método Conectar() de la clase Conexion para realizar la consulta SQL necesaria para obtener los investigadores y sus usuarios relacionados que tienen cuentas inactivas, y luego llenar un DataTable con esos datos para mostrarlo en el DataGridView.

            string query = @"SELECT 
                    i.ID_investigador,
                    i.nombre_investigador,
                    i.apellido_investigador,
                    i.tipo_documento,
                    i.edad_investigador,
                    i.telefono_investigador,

                    u.correo_usuario,
                    u.contraseña_usuario,
                    u.tipo_usuario,
                    u.estado_usuario

                    FROM investigadores i
                    INNER JOIN usuario u ON i.ID_usuario = u.ID_usuario
                    WHERE u.estado_usuario = 'Inactivo'";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay cuentas deshabilitadas", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                return;
            }

            dataGridView1.DataSource = dt;
        }

        private void Btn_habilitar_cuenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string estadoActual = dataGridView1.CurrentRow.Cells["estado_usuario"].Value.ToString();

            if (estadoActual == "Activo")
            {
                MessageBox.Show("La cuenta ya está habilitada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_investigador"].Value);

            SqlConnection con = Conexion.Conectar();// Se establece la conexión a la base de datos utilizando el método Conectar() de la clase Conex

            string query = @"UPDATE usuario 
                     SET estado_usuario = 'Activo'
                     WHERE ID_usuario = 
                     (SELECT ID_usuario FROM investigadores WHERE ID_investigador = @id)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Cuenta habilitada correctamente");
            CargarUsuarios();
        }

        private void btnDeshabilitar_Cuenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string estadoActual = dataGridView1.CurrentRow.Cells["estado_usuario"].Value.ToString();

            if (estadoActual == "Inactivo")
            {
                MessageBox.Show("La cuenta ya está deshabilitada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que desea deshabilitar esta cuenta?",
                "CONFIRMAR",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.No)
                return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_investigador"].Value);

            SqlConnection con = Conexion.Conectar();// Se establece la conexión a la base de datos utilizando el método Conectar() de la clase Conexion.


            string query = @"UPDATE usuario 
                     SET estado_usuario = 'Inactivo'
                     WHERE ID_usuario = 
                     (SELECT ID_usuario FROM investigadores WHERE ID_investigador = @id)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Cuenta deshabilitada correctamente");
            CargarUsuarios();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloLetras(e);// Se llama al método SoloLetras() de la clase Metodos para validar que solo se ingresen letras en el campo de texto txtnombre, evitando que se ingresen números u otros caracteres no permitidos.
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloLetras(e);// Se llama al método SoloLetras() de la clase Metodos para validar que solo se ingresen letras en el campo de texto txtapellido, evitando que se ingresen números u otros caracteres no permitidos.
        }

        private void txtedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);// Se llama al método SoloNumeros() de la clase Metodos para validar que solo se ingresen números en el campo de texto txtedad, evitando que se ingresen letras u otros caracteres no permitidos.
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);// Se llama al método SoloNumeros() de la clase Metodos para validar que solo se ingresen números en el campo de texto txttelefono, evitando que se ingresen letras u otros caracteres no permitidos.
        }

        private void btn_Reunion_Click(object sender, EventArgs e)
        {
            metodo.reunionesAdmin(); // se llama al método Reuniones() para mostrar el formulario de reuniones
            this.Hide();
        }
    }
}
