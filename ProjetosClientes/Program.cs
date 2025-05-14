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
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {

                        while (leitor.Read())
                        {
                            //Console.WriteLine("id: {0} ", leitor["id"]);
                            //Console.WriteLine("nome: {0} ", leitor["nome"]);
                            //Console.WriteLine("email: {0} ", leitor["email"]);

                            Console.WriteLine("id: {0} ", leitor.GetSqlInt32(0));
                            Console.WriteLine("nome: {0} ", leitor.GetSqlString(1));
                            Console.WriteLine("email: {0} ", leitor.GetSqlString(2));
                        }

                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error:"+e.ToString());
        }
    }
}
