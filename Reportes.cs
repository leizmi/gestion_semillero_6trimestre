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
        Metodos metodos = new Metodos();// creamos una instancia de la clase Metodos para utilizar los métodos que se usan repetitivamente en el menú del administrador
        public Reportes()
        {
            InitializeComponent();
        }
        // Eventos para navegar entre los formularios del menú del administrador
        private void btnDashboard_Click(object sender, EventArgs e)
        {
           metodos.menuAdmin(); // se llama al método menuAdmin() para mostrar el formulario del menú del administrador
            this.Hide();
        }
        private void btnGestion_de_usuario_Click(object sender, EventArgs e)// se llama al método Admi_GestionUsuario() para mostrar el formulario de gestión de usuarios
        {
           metodos.Admi_GestionUsuario();// se llama al método Admi_GestionUsuario() para mostrar el formulario de gestión de usuarios
            this.Hide();
        }
        private void btnGestion_de_Semilleros_Click(object sender, EventArgs e)// se llama al método Admi_GestionSemillero() para mostrar el formulario de gestión de semilleros
        {
            metodos.Admi_GestionSemillero();// se llama al método Admi_GestionSemillero() para mostrar el formulario de gestión de semilleros
            this.Hide();
        }
        private void btnReportes_Click(object sender, EventArgs e)// se llama al método Admi_Reportes() para mostrar el formulario de reportes
        {}

        private void btnMostrarCantidadInvestigadores_Click(object sender, EventArgs e)// se ejecuta el método ContarInvestigadores() para obtener la cantidad de investigadores registrados en la base de datos y se muestra el resultado en el label lblCantidadInvestigadores
        {
            lblCantidadInvestigadores.Text = consultas.ContarInvestigadores().ToString();// se ejecuta el método ContarInvestigadores() para obtener la cantidad de investigadores registrados en la base de datos y se muestra el resultado en el label lblCantidadInvestigadores
        }

        private void btnMostrarCantidadEventos_Click(object sender, EventArgs e)// se ejecuta el método ContarEventos() para obtener la cantidad de eventos registrados en la base de datos y se muestra el resultado en el label lblCantidadEventos
        {
            lblCantidadEventos.Text = consultas.ContarEventos().ToString();// se ejecuta el método ContarEventos() para obtener la cantidad de eventos registrados en la base de datos y se muestra el resultado en el label lblCantidadEventos
        }

        private void btnMostrarCantidadSemileros_Click(object sender, EventArgs e)// se ejecuta el método ContarSemilleros() para obtener la cantidad de semilleros registrados en la base de datos y se muestra el resultado en el label lblCantidadSemi
        {
            lblCantidadSemi.Text = consultas.ContarSemilleros().ToString();// se ejecuta el método ContarSemilleros() para obtener la cantidad de semilleros registrados en la base de datos y se muestra el resultado en el label lblCantidadSem
            chart1.Series.Clear();// Limpiamos cualquier serie existente en la gráfica para evitar que se acumulen los datos cada vez que se hace clic en el botón

            var s = chart1.Series.Add("Semilleros");// Agregamos una nueva serie a la gráfica con el nombre "Semilleros"
            s.ChartType = SeriesChartType.Pie;// Establecemos el tipo de gráfico como torta (Pie)

            foreach (DataRow r in consultas.MostrarSemilleros().Rows)// Iteramos sobre cada fila del resultado de la consulta MostrarSemilleros() para agregar los datos a la gráfica
            {
                s.Points.AddXY(r["nombre_semillero"].ToString(), 1);// Agregamos un punto a la serie con el nombre del semillero y un valor de 1 para cada semillero (esto hará que cada semillero tenga la misma proporción en la gráfica)
            }
            s.Label = "#VALX (#PERCENT)";// Establecemos la etiqueta de cada porción de la gráfica para mostrar el nombre del semillero y el porcentaje correspondiente
        }

        private void btnSalir_Click(object sender, EventArgs e)// se llama al método sesiónCerrar() para mostrar un mensaje de confirmación antes de cerrar la sesión y volver al formulario de inicio de sesión
        {
            metodos.sesiónCerrar(this);//se llama al método sesiónCerrar() para mostrar un mensaje de confirmación antes de cerrar la sesión y volver al formulario de inicio de sesión 
        }
        private void button1_Click(object sender, EventArgs e) // se llama al método admi_GestionEventos() para mostrar el formulario de gestión de eventos
        {
            metodos.admi_GestionEventos();// se llama al método admi_GestionEventos() para mostrar el formulario de gestión de eventos
            this.Hide();
        }

        private void btn_Reunion_Click(object sender, EventArgs e)
        {
            metodos.reunionesAdmin();// se llama al método reunionesAdmin() para mostrar el formulario de reuniones
            this.Hide();
        }
    }
}