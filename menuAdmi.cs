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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace gestión_semillero_6trimestre
{   
    public partial class Form2 : Form
    {
        Conexion Conexion = new Conexion(); // creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        DataSet ds = new DataSet(); // (conjunto de datos) creamos la variable dt con tipo DataTable para almacenar los resultados de las consultas a la base de datos
        Metodos metodo = new Metodos();

        public Form2()
        {
            InitializeComponent();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
            metodo.Admi_GestionUsuario();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click_1(object sender, EventArgs e)
        {
            metodo.Admi_GestionSemillero();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
          metodo.Admi_Reportes();
            this.Hide();
        }

        

        private void btnDashboard_Click(object sender, EventArgs e)
        {
           metodo.menuAdmin();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.Conectar();
            SqlDataAdapter da = new SqlDataAdapter("SELECT semillero.ID_semillero, nombre_semillero, fecha_creacion_semillero, linea_investigacion, nombre_investigador AS Nombre_Lider, descripcion_semillero FROM semillero, investigadores, usuario WHERE semillero.ID_semillero = investigadores.ID_semillero AND investigadores.ID_usuario = usuario.ID_usuario  AND usuario.tipo_usuario = 'Lider';", con);
            da.Fill(ds, "semilleros"); // le das nombre a la tabla
            dataGridView1.DataSource = ds.Tables["semilleros"];
        }
        

        private void btnGestionEventos_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCerrar_sesión_Click(object sender, EventArgs e)
        {
            metodo.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }
    }
   
}
