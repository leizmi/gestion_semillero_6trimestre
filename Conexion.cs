using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient; //insertar libreria obligado
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gestión_semillero_6trimestre
{

    internal class Conexion
    {
        SqlConnection con; // creamos la variable con tipo SqlConnection para establecer la conexion a la base de datos

        public SqlConnection Conectar() // creamos el metodo Conectar para establecer la conexion a la base de datos
        {
            try // utilizamos un bloque try-catch para manejar cualquier error que pueda ocurrir al establecer la conexion
            {
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog =GestionSemillero;Integrated Security=True"); // establecemos la conexion a la base de datos utilizando la cadena de conexion
                con.Open(); // abrimos la conexion a la base de datos
            }
            catch (Exception e) // si ocurre un error al establecer la conexion, se muestra un mensaje de error
            {
                MessageBox.Show(e.Message); // mostramos el mensaje de error al usuario
            }
            return con;// retornamos la conexion establecida a la base de datos
        }

        public void cerrar() // creamos el metodo cerrar para cerrar la conexion a la base de datos
        {
            con.Close(); // cerramos la conexion a la base de datos

        }
    }
}
