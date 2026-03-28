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
           metodo.sesiónCerrar();
           this.Hide();
        }

        private void Menu_Lider_Load(object sender, EventArgs e)
        {
            SqlConnection con = conexion.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("SELECT semillero.ID_semillero, nombre_semillero, fecha_creacion_semillero, linea_investigacion, nombre_investigador AS Nombre_Lider, descripcion_semillero FROM semillero, investigadores, usuario WHERE semillero.ID_semillero = investigadores.ID_semillero AND investigadores.ID_usuario = usuario.ID_usuario  AND usuario.tipo_usuario = 'Lider';", con);
            da.Fill(ds, "semilleros"); // le das nombre a la tabla
            dataGridView1.DataSource = ds.Tables["semilleros"];
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            int idSemillero = Convert.ToInt32(comboBox1.SelectedValue);

            SqlConnection con = conexion.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM semillero WHERE ID_semillero = @id", con);

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

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Consultar_eventos_lider consuEventosLider = new Consultar_eventos_lider();
            consuEventosLider.Show();
            this.Hide();
        }
    } 
}
