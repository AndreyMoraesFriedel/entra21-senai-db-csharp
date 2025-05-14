using System.Data.SqlClient;

namespace ProjetosClientes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
                "User Id=sa;Password=12345;" +
                "Server=localhost\\SQLEXPRESS;" +
                "Database=projetoclientes;" +
                "Trusted_Connection=False;"
                );

            using (SqlConnection conexao = new SqlConnection(builder.ConnectionString))
            {
                string sql = "SELECT * FROM clientes;";

                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    conexao.Open();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error:"+e.ToString());
        }
    }
}
