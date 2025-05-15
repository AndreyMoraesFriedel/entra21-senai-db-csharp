namespace ProjetoListas;

class Program
{
    static void Main(string[] args)
    {
        ClientesPF cl1 = new ClientesPF();
        cl1.id = 1;
        cl1.name = "Andrey";

        List <ClientesPF> lista_clientes = new List<ClientesPF> ();

        lista_clientes.Add(new ClientesPF());
        lista_clientes.Add (cl1);
        lista_clientes.Add(new ClientesPF() { id = 3, name = "Bruno" });

        foreach(ClientesPF aux in lista_clientes)
        {
            Console.WriteLine("Cliente: {0} ", aux.name);
        }
    }
}
