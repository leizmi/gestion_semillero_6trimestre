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

        
        private void btnMostrarCantidadInvestigadores_Click(object sender, EventArgs e)
        {
            lblCantidadInvestigadores.Text = consultas.ContarInvestigadores().ToString();

        }

        private void btnMostrarCantidadEventos_Click(object sender, EventArgs e)
        {
            lblCantidadEventos.Text = consultas.ContarEventos().ToString();
        }

        private void btnMostrarCantidadReuniones_Click(object sender, EventArgs e)
        {
            lblCantidadReuniones.Text = consultas.ContarReuniones().ToString();
        }

        private void btnMostrarCantidadSemileros_Click(object sender, EventArgs e)
        {
            lblCantidadSemi.Text = consultas.ContarSemilleros().ToString();

            // Gráfica
            // Gráfica
            chart1.Series.Clear();

            var s = chart1.Series.Add("Semilleros");
            s.ChartType = SeriesChartType.Pie;

            foreach (DataRow r in consultas.MostrarSemilleros().Rows)
            {
                s.Points.AddXY(r["nombre_semillero"].ToString(), 1);
            }

            s.Label = "#VALX (#PERCENT)";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            metodos.sesiónCerrar(this); // 🔥 le pasas el formulario actual
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            metodos.admi_GestionEventos();
            this.Hide();
        }
    }
}
