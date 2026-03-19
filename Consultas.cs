using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace gestión_semillero_6trimestre
{

    internal class Consultas
    {

        Conexion conexion = new Conexion();// creamos una instancia de la clase Conexion para establecer la conexion a la base de datos
        DataSet ds = new DataSet(); // (conjunto de datos) creamos la variable dt con tipo DataTable para almacenar los resultados de las consultas a la base de datos
        Boolean Estado_conexion = false; // creamos la variable Estado_conexion para verificar si la conexion a la base de datos se establecio correctamentes

        public Boolean Iniciar_sesion(int ID_usuario, string contraseña_usuario)
        {
            SqlCommand consulta;//creamos un objeto de tipo SqlCommand para ejecutar la consulta SQL
            consulta = new SqlCommand("select ID_usuario,contraseña_usuario,tipo_usuario from usuario where ID_usuario = @ID_usuario and contraseña_usuario = @contraseña_usuario", conexion.Conectar());//establecemos la consulta SQL para verificar el usuario y la contraseña
            consulta.CommandType = CommandType.Text;//establecemos el tipo de comando como texto
            consulta.Parameters.AddWithValue("@ID_usuario", ID_usuario);//agregamos el parametro idusuario a la consulta SQL
            consulta.Parameters.AddWithValue("@contraseña_usuario", contraseña_usuario);//agregamos el parametro passwordusuario a la consulta SQL


            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta);//creamos un objeto de tipo SqlDataAdapter para ejecutar la consulta SQL y almacenar los datos obtenidos en el DataSet
                da.Fill(ds, "usuario");//llenamos el DataSet con los datos obtenidos de la consulta SQL
                DataRow dr;//creamos un objeto de tipo DataRow para almacenar una fila de datos del DataSet
                dr = ds.Tables["usuario"].Rows[0];//obtenemos la primera fila de datos del DataSet// creamos una variable dr con tipo DataRow para almacenar la primera fila de los resultados de la consulta a la base de datos
                if (Convert.ToString(ID_usuario) == dr["ID_usuario"].ToString() && contraseña_usuario == dr["contraseña_usuario"].ToString() && "Administrador" == dr["tipo_usuario"].ToString()) // verificamos si el ID_usuario y el contraseña_usuario ingresados por el usuario coinciden con los resultados de la consulta a la base de datos
                {
                    MessageBox.Show("Bienvenido Administrador"); // si el id_usuario y el **password_usuario*** ingresados por el usuario coinciden con los resultados de la consulta a la base de datos, se muestra un mensaje de bienvenida al usuario
                    Form2 form2 = new Form2(); // creamos una instancia del formulario FormAdmin para mostrarlo al usuario
                    form2.Show(); // mostramos el formulario FormAdmin al usuario
                    Estado_conexion = true; // si la consulta a la base de datos se ejecuto correctamente, se establece el estado de la conexion a true
                }
                else
                {
                    if (Convert.ToString(ID_usuario) == dr["ID_usuario"].ToString() && contraseña_usuario == dr["contraseña_usuario"].ToString() && "Lider" == dr["tipo_usuario"].ToString()) // verificamos si el ID_usuario y el contraseña_usuario ingresados por el usuario coinciden con los resultados de la consulta a la base de datos
                    {
                        MessageBox.Show("Bienvenido Lider");
                        Menu_Lider menu_Lider = new Menu_Lider(); // creamos una instancia del formulario FormLider para mostrarlo al usuari
                        menu_Lider.Show(); // mostramos el formulario FormLider al usuario
                        Estado_conexion = true;
                    }

                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Usuario y/o Contraseña incorrecta");// usuario o contraseña incorrectos, se muestra un mensaje de error al usuario

            }
            finally
            {
                conexion.cerrar(); // cerramos la conexion a la base de datos
            }
            return Estado_conexion; // retornamos el estado de la conexion a la base de datos (true si la consulta a la base de datos se ejecuto correctamente, false si no se ejecuto correctamente)
        }
    }

}