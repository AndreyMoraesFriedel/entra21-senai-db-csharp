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

        app.Run();
    }
}
