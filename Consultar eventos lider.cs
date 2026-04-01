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
    public partial class Consultar_eventos_lider : Form
    {   
        Metodos metodos = new Metodos();
        public Consultar_eventos_lider()
        {
            InitializeComponent();
        }

        private void btnBuscarEvento_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un criterio de búsqueda.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese un valor para buscar.");
                return;
            }

            string columna = "";
            string valor = txtBuscar.Text.Trim();

            string opcion = comboBox1.SelectedItem.ToString();

            // 🔥 CORREGIDO: texto correcto del ComboBox
            if (opcion == "ID del evento")
            {
                columna = "ID_evento";

                if (!int.TryParse(valor, out _))
                {
                    MessageBox.Show("El ID debe ser numérico.");
                    return;
                }
            }
            else if (opcion == "Nombre del evento")
            {
                columna = "nombre_evento";
            }
            else if (opcion == "Fecha evento")
            {
                columna = "fecha_evento";

                if (!DateTime.TryParseExact(valor, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out _))
                {
                    MessageBox.Show("La fecha debe tener formato: yyyy-MM-dd");
                    return;
                }
            }

            // 🔥 VALIDACIÓN ARREGLADA
            if (columna == "")
            {
                MessageBox.Show("Opción no válida.");
                return;
            }

            CargarDatos(columna, valor);
        }

        public void CargarDatos(string columna, string valor)
        {
            string query = "";

            if (string.IsNullOrEmpty(columna) || string.IsNullOrEmpty(valor))
            {
                query = "SELECT * FROM evento";
            }
            else
            {
                if (columna == "ID_evento")
                {
                    query = "SELECT * FROM evento WHERE ID_evento = @valor";
                }
                else
                {
                    query = $"SELECT * FROM evento WHERE {columna} LIKE @valor";
                }
            }

            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GestionSemillero;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, conn);

            if (!string.IsNullOrEmpty(columna) && !string.IsNullOrEmpty(valor))
            {
                if (columna == "ID_evento")
                    cmd.Parameters.Add("@valor", SqlDbType.Int).Value = Convert.ToInt32(valor); // 🔥 mejor tipo
                else if (columna == "fecha_evento")
                    cmd.Parameters.AddWithValue("@valor", valor);
                else
                    cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                if (columna == "nombre_evento")
                    MessageBox.Show("No existe ningún evento con ese nombre.");
                else if (columna == "fecha_evento")
                    MessageBox.Show("No hay eventos en esa fecha.");
                else if (columna == "ID_evento")
                    MessageBox.Show("No existe ningún evento con ese ID.");

                dataGridView1.DataSource = null;
                return;
            }

            dataGridView1.DataSource = dt;
        }

        private void Consultar_eventos_lider_Load(object sender, EventArgs e)
        {
            CargarDatos("", "");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Consultar_eventos_lider consuEventosLider = new Consultar_eventos_lider();
            consuEventosLider.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            metodos.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        private void btnRegistrarProyecto_Click(object sender, EventArgs e)
        {
            metodos.registrarProyecto();
            this.Hide();
        }

        private void btnGestionarSemillero_Click(object sender, EventArgs e)
        {
            metodos.menuLider();
            this.Hide();
        }
    }
}
