using System.Data.SqlClient;

public class Banco
{
	public string? mensagem = "Olá Banco!";

	private List<Pessoa> lista = new List<Pessoa>();

	public void carregarBanco()
	{
		try
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
				"User ID=sa;Password=12345;"+
				"Server=localhost\\SQLEXPRESS;"+
				"Database=projetoclientes;"+
				"Trusted_Connection=False;"
				);
			using (SqlConnection conexao = new SqlConnection(builder.ConnectionString))
			{
				string sql = "SELECT * FROM clientes";
				using (SqlCommand comando = new SqlCommand(sql, conexao))
				{
					conexao.Open();
					using (SqlDataReader tabela = comando.ExecuteReader())
					{
						while (tabela.Read())
						{
							//Console.WriteLine(tabela["nome"]);
							lista.Add(
								new Pessoa()
								{
									id = Convert.ToInt32(tabela["id"]),
									nome = tabela["nome"].ToString()
								}
							);
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("Error: " + e.ToString());
		}
	}

	public List<Pessoa> GetLista()
	{
		return lista;
	}
}
