using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;


namespace tarea2._2
{
    public class libroDAO
    {

        public SqlDataReader conectar()
        {
            string connectionString = "Data Source=DESKTOP-J3RNERL;Initial Catalog=biblioteca;User ID=sa;Password=root";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader reader=null;
            try
            {
                // Abrir la conexión manualmente
                connection.Open();

                // Realizar una operación en la base de datos (por ejemplo, ejecutar una consulta)
                string query = "SELECT * FROM libros";
                SqlCommand command = new SqlCommand(query, connection);

                // Ejecutar la consulta y procesar los resultados
                reader = command.ExecuteReader();
                
                // return reader;
                /* while (reader.Read())
                 {
                     // Aquí puedes procesar los resultados obtenidos
                     Console.WriteLine($"{reader["id"].ToString()}, {reader["isbn"].ToString()}");
                 }*/

                // Cerrar la conexión manualmente
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                
            }
            finally
            {
                // Asegurarse de cerrar la conexión en el bloque finally si aún está abierta
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
               
            }
            return reader;
        }
        
    }
}