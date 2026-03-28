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
        public Consultar_eventos_lider()
        {
            InitializeComponent();
        }

        private void btnBuscarEvento_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un criterio de búsqueda");
                return;
            }

            string columna = "";
            string valor = txtBuscar.Text.Trim();

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Nombre de proyecto":
                    columna = "nombre_proyecto";
                    break;

                case "Nombre del semillero":
                    columna = "nombre_semillero";
                    break;

                case "Fecha evento":
                    columna = "fecha_evento";
                    break;
            }

            CargarDatos(columna, valor);
        }

        public void CargarDatos(string columna, string valor)
        {
            string query = "";

            if (string.IsNullOrEmpty(valor))
            {
                query = "SELECT * FROM evento";
            }
            else
            {
                if (columna == "fecha_evento")
                {
                    query = $"SELECT * FROM evento WHERE CONVERT(VARCHAR, fecha_evento, 23) LIKE @valor";
                }
                else
                {
                    query = $"SELECT * FROM evento WHERE {columna} LIKE @valor";
                }
            }

            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog =GestionSemillero;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, conn);

            if (!string.IsNullOrEmpty(valor))
            {
                cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

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

        
    }
}
