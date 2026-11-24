using Microsoft.Data.Sqlite;

string cadena = "Data Source=videojuegos.db";

using (SqliteConnection conexion = new SqliteConnection(cadena))
{
    conexion.Open();
    Console.WriteLine("Conexion abierta correctamente.");

    using (SqliteCommand crear = conexion.CreateCommand())
    {
        crear.CommandText =
            "CREATE TABLE IF NOT EXISTS videojuegos (" +
            "id INTEGER PRIMARY KEY, " +
            "titulo TEXT, " +
            "genero TEXT, " +
            "anio INTEGER)";
        crear.ExecuteNonQuery();
    }

    using (SqliteCommand limpiar = conexion.CreateCommand())
    {
        limpiar.CommandText = "DELETE FROM videojuegos";
        limpiar.ExecuteNonQuery();
    }

    string[] titulos = { "The Legend of Zelda", "Hollow Knight", "Minecraft" };
    string[] generos = { "Aventura", "Metroidvania", "Sandbox" };
    int[] anios = { 2017, 2017, 2011 };

    for (int i = 0; i < titulos.Length; i++)
    {
        using (SqliteCommand insertar = conexion.CreateCommand())
        {
            insertar.CommandText =
                "INSERT INTO videojuegos (titulo, genero, anio) " +
                "VALUES ($titulo, $genero, $anio)";
            insertar.Parameters.AddWithValue("$titulo", titulos[i]);
            insertar.Parameters.AddWithValue("$genero", generos[i]);
            insertar.Parameters.AddWithValue("$anio", anios[i]);
            insertar.ExecuteNonQuery();
            Console.WriteLine("Registro insertado: " + titulos[i]);
        }
    }

    using (SqliteCommand consultar = conexion.CreateCommand())
    {
        consultar.CommandText = "SELECT id, titulo, genero, anio FROM videojuegos";

        using (SqliteDataReader lector = consultar.ExecuteReader())
        {
            Console.WriteLine();
            Console.WriteLine("Videojuegos almacenados:");
            while (lector.Read())
            {
                int id = lector.GetInt32(0);
                string titulo = lector.GetString(1);
                string genero = lector.GetString(2);
                int anio = lector.GetInt32(3);
                Console.WriteLine(id + " | " + titulo + " | " + genero + " | " + anio);
            }
        }
    }
}
