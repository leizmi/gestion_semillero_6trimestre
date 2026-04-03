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

        Metodos metodo = new Metodos();

        public Form3()
        {
            InitializeComponent();
        }

        // Botones para navegar entre formularios del administrador, cada uno llama a un método específico de la clase Metodos para mostrar el formulario correspondiente y luego cierra o oculta el formulario actual.
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            metodo.menuAdmin();
            this.Close();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionUsuario();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero();
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            metodo.Admi_Reportes();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        private void btnGestionEventos_Click(object sender, EventArgs e)
        {
            metodo.admi_GestionEventos();
            this.Hide();
        }

        void CargarUsuarios() // Metodo para cargar los usuarios en el DataGridView, se conecta a la base de datos, ejecuta una consulta SQL para obtener los datos de los investigadores y sus usuarios relacionados, y luego llena un DataTable con esos datos para mostrarlo en el DataGridView.
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog =GestionSemillero;Integrated Security=True");
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

                             FROM investigadores i";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }


        // Al cargar el formulario, se llama a los métodos CargarUsuarios() y CargarSemilleros() para mostrar los datos de los investigadores y llenar el ComboBox con los semilleros disponibles.
        private void Form3_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarSemilleros();
        }

        private void btnBuscarFiltro_Click(object sender, EventArgs e)
        {

            // Validacion de filtro seleccionado y valor ingresado, si no se cumple alguna de las condiciones, se muestra un mensaje de error y se detiene la ejecución del método.
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de filtro","INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFiltro.Text))
            {
                MessageBox.Show("Debe ingresar un valor para buscar","INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filtro = comboBox1.SelectedItem.ToString();
            string valor = textBoxFiltro.Text.Trim();

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog =GestionSemillero;Integrated Security=True");

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
                WHERE ";

            // Busca registros que contengan el texto ingresado
            if (filtro == "ID investigador")
                query += "i.ID_investigador = @valor"; //se usa query += para agregar condiciones a la consulta SQL de forma dinámica según el filtro ingresado por el usuario.
            else if (filtro == "Nombre investigador")
                query += "i.nombre_investigador LIKE '%' + @valor + '%'";
            else if (filtro == "Apellido investigador")
                query += "i.apellido_investigador LIKE '%' + @valor + '%'";
            else if (filtro == "Tipo de documento")
                query += "i.tipo_documento LIKE '%' + @valor + '%'";
            else if (filtro == "Tipo de usuario")
                query += @"(SELECT u.tipo_usuario 
                    FROM usuario u 
                    WHERE u.ID_usuario = i.ID_usuario) LIKE '%' + @valor + '%'";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@valor", valor);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // Se valida si la consulta devolvió resultados, si no se encontraron registros que coincidan con el filtro ingresado, se muestra un mensaje de información y se limpia el DataGridView.
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                return;
            }

            dataGridView1.DataSource = dt;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog =GestionSemillero;Integrated Security=True");
            con.Open();

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_investigador"].Value);

            // actualizar los investigadores
            string query1 = @"UPDATE investigadores SET 
                            nombre_investigador = @nombre,
                            apellido_investigador = @apellido,
                            tipo_documento = @doc
                            WHERE ID_investigador = @id";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@nombre", txtnombre.Text);
            cmd1.Parameters.AddWithValue("@apellido", txtapellido.Text);
            cmd1.Parameters.AddWithValue("@doc", txtdocumento.Text);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.ExecuteNonQuery();

            // actualizar usuario (subconsulta)
            string query2 = @"UPDATE usuario SET 
                            tipo_usuario = @tipo,
                            estado_usuario = @estado
                            WHERE ID_usuario = 
                           (SELECT ID_usuario FROM investigadores WHERE ID_investigador = @id)";

            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@tipo", comboBox4.Text);
            cmd2.Parameters.AddWithValue("@estado", comboBox3.Text);
            cmd2.Parameters.AddWithValue("@id", id);
            cmd2.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Usuario actualizado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();// Recargar el DataGridView para mostrar los cambios realizados
            LimpiarCampos();// Limpiar los campos de texto y restablecer los ComboBox después de la actualización
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];// Obtener los valores de la fila seleccionada y asignarlos a los campos correspondientes para su edición

                txtnombre.Text = fila.Cells["nombre_investigador"].Value.ToString();
                txtapellido.Text = fila.Cells["apellido_investigador"].Value.ToString();
                txtdocumento.Text = fila.Cells["tipo_documento"].Value.ToString();

                txtedad.Text = fila.Cells["edad_investigador"].Value.ToString();
                txttelefono.Text = fila.Cells["telefono_investigador"].Value.ToString();
                txtcorreo.Text = fila.Cells["correo_usuario"].Value.ToString();
                txtcontraseña.Text = fila.Cells["contraseña_usuario"].Value.ToString();

                comboBox4.Text = fila.Cells["tipo_usuario"].Value.ToString();
                comboBox3.Text = fila.Cells["estado_usuario"].Value.ToString();
            }
        }

        void LimpiarCampos()
        {
            // TextBox
            txtnombre.Clear();
            txtapellido.Clear();
            txtdocumento.Clear();
            txtedad.Clear();
            txttelefono.Clear();
            txtcorreo.Clear();
            txtcontraseña.Clear();

            // ComboBox
            comboBox4.SelectedIndex = -1; // tipo usuario
            comboBox3.SelectedIndex = -1; // estado

            // Quitar selección del DataGridView
            dataGridView1.ClearSelection();
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios, se verifica que todos los campos necesarios para crear una nueva cuenta de investigador estén completos, si alguno de los campos está vacío o no se ha seleccionado un valor en los ComboBox, se muestra un mensaje de error y se detiene la ejecución del método.
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
                string.IsNullOrWhiteSpace(txtapellido.Text) ||
                string.IsNullOrWhiteSpace(txtdocumento.Text) ||
                string.IsNullOrWhiteSpace(txtedad.Text) ||
                string.IsNullOrWhiteSpace(txttelefono.Text) ||
                string.IsNullOrWhiteSpace(txtcorreo.Text) ||
                string.IsNullOrWhiteSpace(txtcontraseña.Text) ||
                comboBox4.SelectedIndex == -1 ||
                comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar todos los campos", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GestionSemillero;Integrated Security=True");
            con.Open();

            try
            {
                //  Generar ID usuario automáticamente
                SqlCommand cmdIdUsuario = new SqlCommand("SELECT ISNULL(MAX(ID_usuario),0)+1 FROM usuario", con);
                int nuevoIdUsuario = Convert.ToInt32(cmdIdUsuario.ExecuteScalar());

                //  Insertar en usuario
                string insertUsuario = @"INSERT INTO usuario 
                                (ID_usuario, estado_usuario, correo_usuario, contraseña_usuario, tipo_usuario)
                                VALUES (@id, @estado, @correo, @contra, @tipo)";

                SqlCommand cmdUsuario = new SqlCommand(insertUsuario, con);
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

                SqlCommand cmdInv = new SqlCommand(insertInvestigador, con);
                cmdInv.Parameters.AddWithValue("@idInv", nuevoIdInv);
                cmdInv.Parameters.AddWithValue("@nombre", txtnombre.Text);
                cmdInv.Parameters.AddWithValue("@apellido", txtapellido.Text);
                cmdInv.Parameters.AddWithValue("@doc", txtdocumento.Text);
                cmdInv.Parameters.AddWithValue("@edad", Convert.ToInt32(txtedad.Text));
                cmdInv.Parameters.AddWithValue("@telefono", txttelefono.Text);
                cmdInv.Parameters.AddWithValue("@idUsuario", nuevoIdUsuario);

              
                cmdInv.Parameters.AddWithValue("@semillero", comboBoxSemillero.SelectedValue); 

                cmdInv.ExecuteNonQuery();

                MessageBox.Show("Investigador agregado correctamente");

                // 🔄 Recargar y limpiar
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            con.Close();
        }

        void CargarSemilleros() // Método para cargar los semilleros en el ComboBox, se conecta a la base de datos, ejecuta una consulta SQL para obtener los semilleros disponibles y luego llena un DataTable con esos datos para mostrarlo en el ComboBox.
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GestionSemillero;Integrated Security=True");

            string query = "SELECT ID_semillero, nombre_semillero FROM semillero WHERE ID_semillero >= 2001";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBoxSemillero.DataSource = dt;
            comboBoxSemillero.DisplayMember = "nombre_semillero"; // lo que ve el usuario
            comboBoxSemillero.ValueMember = "ID_semillero"; // lo que se guarda
        }
    }

}
