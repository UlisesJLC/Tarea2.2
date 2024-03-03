using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tarea2._2
{
    public partial class frmBiblioteca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=DESKTOP-J3RNERL;Initial Catalog=biblioteca;User ID=sa;Password=ServerHtml123";

            string connectionString = "Data Source=WindowsServer;Initial Catalog=biblioteca;User ID=sa;Password=ServerHtml123";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                // Abrir la conexión manualmente
                connection.Open();

                // Realizar una operación en la base de datos (por ejemplo, ejecutar una consulta)
                string query = "SELECT ISBN, TITULO, NUMERO_DE_EDICION, ANO_DE_PUBLICACION, NOMBRE_DE_AUTORES, PAIS_DE_PUBLICACION, SINOPSIS, CARRERA, MATERIA FROM libros";

                SqlCommand command = new SqlCommand(query, connection);

                // Ejecutar la consulta y procesar los resultados
                reader = command.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();

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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string _isbn = isbn.Value.ToString();
            string _titulo = titulo.Value.ToString();
            int numero_edicion = 0;
            int anio_pub = 0;
            try
            {
                numero_edicion = Convert.ToInt32(num_edicion.Value.ToString());
               
            }
            catch(FormatException ex)
            {
                string mensaje = "alert('El campo numero de edicion no es vállido');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                return;
            }
            try
            {
               
                anio_pub = Convert.ToInt32(publicacion.Value.ToString());
            }
            catch (FormatException ex)
            {
                string mensaje = "alert('El campo año de publicación no es vállido');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                return;
            }
            string nombre_autores = autores.Value.ToString();
            string pais_publicacion = pais.Value.ToString();
            string _sinopsis = sinopsis.Value.ToString();
            string _carrera = carrera.Value.ToString();
            string _materia = materia.Value.ToString();


            string insertQuery = @"
                INSERT INTO libros (ISBN, TITULO, NUMERO_DE_EDICION, ANO_DE_PUBLICACION, NOMBRE_DE_AUTORES, PAIS_DE_PUBLICACION, SINOPSIS, CARRERA, MATERIA)
                VALUES 
                (@ISBN, @Titulo, @NumeroEdicion, @AnoPublicacion, @NombreAutores, @PaisPublicacion, @Sinopsis, @Carrera, @Materia);
            ";


            string connectionString = "Data Source=WindowsServer;Initial Catalog=biblioteca;User ID=sa;Password=ServerHtml123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Asignar valores a los parámetros
                    command.Parameters.AddWithValue("@ISBN", _isbn);
                    command.Parameters.AddWithValue("@Titulo", _titulo);
                    command.Parameters.AddWithValue("@NumeroEdicion", numero_edicion);
                    command.Parameters.AddWithValue("@AnoPublicacion", anio_pub);
                    command.Parameters.AddWithValue("@NombreAutores", nombre_autores);
                    command.Parameters.AddWithValue("@PaisPublicacion", pais_publicacion);
                    command.Parameters.AddWithValue("@Sinopsis", _sinopsis);
                    command.Parameters.AddWithValue("@Carrera", _carrera);
                    command.Parameters.AddWithValue("@Materia", _materia);

                    // Abrir conexión
                    connection.Open();

                    // Ejecutar la sentencia SQL de inserción
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertaron {rowsAffected} filas.");
                }
            }
            try
            {

              
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataReader reader = null;
                // Abrir la conexión manualmente
                connection.Open();

                // Realizar una operación en la base de datos (por ejemplo, ejecutar una consulta)
                string query = "SELECT ISBN, TITULO, NUMERO_DE_EDICION, ANO_DE_PUBLICACION, NOMBRE_DE_AUTORES, PAIS_DE_PUBLICACION, SINOPSIS, CARRERA, MATERIA FROM libros";

                SqlCommand command = new SqlCommand(query, connection);

                // Ejecutar la consulta y procesar los resultados
                reader = command.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
        }
    }
}