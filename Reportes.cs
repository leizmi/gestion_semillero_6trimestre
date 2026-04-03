using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gestión_semillero_6trimestre
{
    public partial class Reportes : Form
    {
        Consultas consultas = new Consultas(); // creamos una instancia de la clase Consultas para ejecutar las consultas a la base de datos
        Metodos metodos = new Metodos();    
        public Reportes()
        {
            InitializeComponent();
        }

        // Eventos para navegar entre los formularios del menú del administrador
        private void btnDashboard_Click(object sender, EventArgs e)
        {
           metodos.menuAdmin();
            this.Hide();
        }

        private void btnGestion_de_usuario_Click(object sender, EventArgs e)
        {
           metodos.Admi_GestionUsuario();
            this.Hide();
        }

        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)
        {
            metodos.Admi_GestionSemillero();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
           metodos.Admi_Reportes();
            this.Hide();
        }

        // Eventos para mostrar los datos en los labels al hacer clic en los botones correspondientes
        private void btnMostrarCantidadInvestigadores_Click(object sender, EventArgs e)
        {
            lblCantidadInvestigadores.Text = consultas.ContarInvestigadores().ToString();

        }

        private void btnMostrarCantidadEventos_Click(object sender, EventArgs e)
        {
            lblCantidadEventos.Text = consultas.ContarEventos().ToString();
        }


        // Evento para mostrar la cantidad de semilleros y una gráfica de torta con la distribución de semilleros al hacer clic en el botón correspondiente
        private void btnMostrarCantidadSemileros_Click(object sender, EventArgs e)
        {
            lblCantidadSemi.Text = consultas.ContarSemilleros().ToString();


            // Gráfica de torta para mostrar la distribución de semilleros
            chart1.Series.Clear();

            var s = chart1.Series.Add("Semilleros");// Agregamos una nueva serie a la gráfica con el nombre "Semilleros"
            s.ChartType = SeriesChartType.Pie;// Establecemos el tipo de gráfico como torta (Pie)

            foreach (DataRow r in consultas.MostrarSemilleros().Rows)// Iteramos sobre cada fila del resultado de la consulta MostrarSemilleros() para agregar los datos a la gráfica
            {
                s.Points.AddXY(r["nombre_semillero"].ToString(), 1);// Agregamos un punto a la serie con el nombre del semillero y un valor de 1 para cada semillero (esto hará que cada semillero tenga la misma proporción en la gráfica)
            }

            s.Label = "#VALX (#PERCENT)";// Establecemos la etiqueta de cada porción de la gráfica para mostrar el nombre del semillero y el porcentaje correspondiente
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodos.sesiónCerrar(this); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metodos.admi_GestionEventos();
            this.Hide();
        }
    }
}
