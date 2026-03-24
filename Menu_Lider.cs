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
        public Menu_Lider()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 menu = new Form1();
                menu.Show();
                this.Hide(); 
            }
        }

        private void Menu_Lider_Load(object sender, EventArgs e)
        {
            CargarSemilleros();
        }

        private void CargarSemilleros()
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-HPRJHVG;Initial Catalog =GestionSemillero;Integrated Security=True");

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT ID_semillero, nombre_semillero FROM semillero", conexion);

            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nombre_semillero";      // lo que ve el usuario
            comboBox1.ValueMember = "ID_semillero";   // el ID real
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idSemillero = Convert.ToInt32(comboBox1.SelectedValue);

            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-HPRJHVG;Initial Catalog =GestionSemillero;Integrated Security=True");

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM semillero WHERE ID_semillero = @id", conexion);

            da.SelectCommand.Parameters.AddWithValue("@id", idSemillero);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
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
    } 
}
