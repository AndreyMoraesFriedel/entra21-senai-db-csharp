using System.Runtime.Serialization;

namespace ProjetoWeb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseStaticFiles();

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/produtos", (HttpContext contexto) =>
            {
                contexto.Response.Redirect("produtos.html", false);
            }
        );

        app.MapGet("/clientes", (string nome, string email) =>
        $"O nome do cliente escolhido é {nome} \n O email é {email}");

        Pessoa p1 = new Pessoa() { id = 1, nome = "Andrey" };

        //text/plain
        //app.MapGet("/fornecedores", () =>
        //    $"O fornenecedor é {p1.id} - {p1.nome}"
        //);

        app.MapGet("/fornecedores", (HttpContext contexto) =>
        {
            string pagina = "<h1>Fornecedores</h1>";
            pagina += $"<h2>ID: {p1.id} - Nome: {p1.nome}</h2>";
            contexto.Response.WriteAsync(pagina);
        });

        app.MapGet("/fornecedoresEnviarDados", (int id, string nome) => 
        {
            p1.id = id;
            p1.nome = nome;
            return "Dados Inseridos com Sucesso!";
        });

        app.MapGet("/api", (Func<object>)(() =>
        {
            return new
            {
                id = p1.id,
                nome = p1.nome
            };
        }));

        app.Run();
    }
}
