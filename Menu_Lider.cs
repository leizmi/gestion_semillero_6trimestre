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
        DataSet ds = new DataSet();

        public Menu_Lider()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        private void Menu_Lider_Load(object sender, EventArgs e)
        {
            SqlConnection con = conexion.Conectar();

            SqlDataAdapter da = new SqlDataAdapter("SELECT ID_semillero, nombre_semillero FROM semillero", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nombre_semillero";
            comboBox1.ValueMember = "ID_semillero";

            CargarSemilleros();
            CargarLineasInvestigacion();
            CargarSemillerosComboInvestigadores();

        }

        private void CargarSemilleros()
        {
            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM semillero", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor debe seleccionar una opción.",
                                "ADVERTENCIA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            int idSemillero = Convert.ToInt32(comboBox1.SelectedValue);

            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM semillero WHERE ID_semillero = @id", con);

                da.SelectCommand.Parameters.AddWithValue("@id", idSemillero);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

        }


        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            Registrar_proyecto RegisProyecto = new Registrar_proyecto();
            RegisProyecto.Show();
            this.Hide();
        }

        private void btnGestionarSemillero_Click(object sender, EventArgs e)
        {
            Menu_Lider MLider = new Menu_Lider();
            MLider.Show();
            this.Hide();
        }

        

        private void btnMostraSemiDataGridView_Click(object sender, EventArgs e)
        {
            CargarSemilleros();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se aceptan letras.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregarSemi_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Por favor ingrese la informacion pedida.");
                return;
            }

            using (SqlConnection con = conexion.Conectar())
            {
                string query = "INSERT INTO semillero (ID_semillero, nombre_semillero, fecha_creacion_semillero, descripcion_semillero, linea_investigacion) " +
                               "VALUES (@id, @nombre, @fecha, @desc, @linea)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@desc", textBox4.Text);
                cmd.Parameters.AddWithValue("@linea", textBox5.Text);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
                ;
            }

            MessageBox.Show("Semillero agregado correctamente");

            CargarSemilleros(); // 🔥 refresca el DataGridView
            limpiarCampos();
        }

        private void btnEliminarSemi_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Seleccione un semillero.");
                return;
            }

            using (SqlConnection con = conexion.Conectar())
            {
                // 🔥 VALIDAR RELACIÓN
                string validar = "SELECT COUNT(*) FROM proyecto WHERE ID_semillero = @id";

                SqlCommand cmdValidar = new SqlCommand(validar, con);
                cmdValidar.Parameters.AddWithValue("@id", textBox1.Text);

                int tieneProyectos = (int)cmdValidar.ExecuteScalar();

                if (tieneProyectos > 0)
                {
                    MessageBox.Show("No se puede eliminar porque tiene proyectos asociados.");
                    return;
                }

                // 🔥 ELIMINAR
                string query = "DELETE FROM semillero WHERE ID_semillero = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Semillero eliminado correctamente");

            CargarSemilleros();
            limpiarCampos();
        }

        private void btnActualizarSemi_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Por favor ingrese la informacion pedida.");
                return;
            }

            using (SqlConnection con = conexion.Conectar())
            {
                string query = "UPDATE semillero SET ID_semillero=@id, nombre_semillero=@nombre, fecha_creacion_semillero=@fecha, descripcion_semillero=@desc, linea_investigacion=@linea WHERE ID_semillero=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@desc", textBox4.Text);
                cmd.Parameters.AddWithValue("@linea", textBox5.Text);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                
            }

            MessageBox.Show("Semillero actualizado correctamente");

            CargarSemilleros(); // 🔥 refresca el DataGridView
            limpiarCampos();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se aceptan letras.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se aceptan números.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        private void limpiarCampos()
        {
            textBox2.Clear();
            textBox5.Clear();
            textBox1.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView2.Rows[e.RowIndex];

                textBox1.Text = fila.Cells[0].Value.ToString();
                textBox2.Text = fila.Cells[1].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(fila.Cells[2].Value);
                textBox4.Text = fila.Cells[3].Value.ToString();
                textBox5.Text = fila.Cells[4].Value.ToString();

            }
        }

        private void btnBusquedaLineaInv_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor debe seleccione una línea de investigación.",
                                "ADVERTENCIA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string lineaInvestigacion = comboBox2.SelectedValue.ToString();

            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM semillero WHERE linea_investigacion = @linea", con);

                da.SelectCommand.Parameters.AddWithValue("@linea", lineaInvestigacion);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
        private void CargarLineasInvestigacion()
        {
            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT DISTINCT linea_investigacion FROM semillero", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "linea_investigacion";
                comboBox2.ValueMember = "linea_investigacion";
            }
        }

        private void btnConsuPorFecha_Click(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker2.Value.Date;

            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM semillero WHERE CAST(fecha_creacion_semillero AS DATE) = @fecha", con);

                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // 🔥 VALIDACIÓN
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay semilleros relacionados con esa fecha.",
                                    "Sin resultados",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    dataGridView1.DataSource = null; // opcional: limpia la tabla
                    return;
                }

                dataGridView1.DataSource = dt;
            }
        }

        private void btnConsultarInv_Click(object sender, EventArgs e)
        {
            if (comboBoxSemillero.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un semillero.");
                return;
            }

            int idSemillero = Convert.ToInt32(comboBoxSemillero.SelectedValue);

            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT * 
                    FROM investigadores 
                     WHERE ID_semillero = @id 
                     AND ID_usuario IN 
                     (SELECT ID_usuario FROM usuario WHERE estado_usuario = @estado)", con);

                da.SelectCommand.Parameters.AddWithValue("@id", idSemillero);
                da.SelectCommand.Parameters.AddWithValue("@estado", "activo");

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay investigadores activos en este semillero.");
                    dataGridView3.DataSource = null;
                    return;
                }

                dataGridView3.DataSource = dt;
            }
        }

        private void btnEliminarInv_Click(object sender, EventArgs e)
        {
            // 🔥 VALIDAR SI HAY FILA SELECCIONADA
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un investigador.",
                                "ADVERTENCIA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 🔥 CONFIRMAR
            DialogResult r = MessageBox.Show("¿Desea desactivar este investigador?",
                                            "Confirmar",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (r == DialogResult.No)
                return;

            int idInvestigador = Convert.ToInt32(
                dataGridView3.CurrentRow.Cells["ID_investigador"].Value);

            using (SqlConnection con = conexion.Conectar())
            {
                string query = @"
        UPDATE usuario 
        SET estado_usuario = @estado
        WHERE ID_usuario = (
            SELECT ID_usuario 
            FROM investigadores 
            WHERE ID_investigador = @id
        )";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@estado", "inactivo");
                cmd.Parameters.AddWithValue("@id", idInvestigador);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Investigador desactivado correctamente");

            // 🔥 REFRESCAR
            btnConsultarInv_Click(null, null);
        }


        private void CargarSemillerosComboInvestigadores()
        {
            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT ID_semillero, nombre_semillero FROM semillero", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxSemillero.DataSource = dt;
                comboBoxSemillero.DisplayMember = "nombre_semillero";
                comboBoxSemillero.ValueMember = "ID_semillero";
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un investigador.");
                return;
            }

            int idInvestigador = Convert.ToInt32(
                dataGridView3.CurrentRow.Cells["ID_investigador"].Value);

            using (SqlConnection con = conexion.Conectar())
            {
                string query = @"
        UPDATE usuario 
        SET estado_usuario = 'activo'
        WHERE ID_usuario = (
            SELECT ID_usuario 
            FROM investigadores 
            WHERE ID_investigador = @id
        )";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idInvestigador);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Investigador habilitado correctamente");

            btnConsultarInv_Click(null, null);
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            int idSemillero = Convert.ToInt32(comboBoxSemillero.SelectedValue);

            using (SqlConnection con = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT * 
              FROM investigadores 
              WHERE ID_semillero = @id 
              AND ID_usuario IN (
                  SELECT ID_usuario 
                  FROM usuario 
                  WHERE estado_usuario = 'inactivo'
              )", con);

                da.SelectCommand.Parameters.AddWithValue("@id", idSemillero);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView3.DataSource = dt;
            }
        }

        private void btnConsultarEventos_Click(object sender, EventArgs e)
        {
            Consultar_eventos_lider consuEventosLider = new Consultar_eventos_lider();
            consuEventosLider.Show();
            this.Hide();
        }
    } 
}
