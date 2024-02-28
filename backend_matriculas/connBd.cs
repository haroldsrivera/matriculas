namespace backend_matriculas
{
    using MySql.Data.MySqlClient;
    using Microsoft.Extensions.Configuration;

    public class connBd
    {
        static void Main(string[] args)
        {
            // Cargar la configuración desde el archivo appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Obtener la cadena de conexión de la configuración
            string connectionString = configuration.GetConnectionString("CadenaConexionMySQL");

            // Crear una instancia de la clase MySqlConnection usando la cadena de conexión
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // Abrir la conexión con la base de datos
                connection.Open();
                Console.WriteLine("Conexión exitosa");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al conectar: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
