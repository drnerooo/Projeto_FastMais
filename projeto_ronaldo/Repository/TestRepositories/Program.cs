using Business;
//using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.EF;
using Repository.Repositories;

class Program
{

    static void Main(string[] args)
    {

        
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma das opções:\n" +
                "1 - Testar Repositório de CONFERENTE\n" +
                "2 - Testar Repositório de ENTREGA\n" +
                "3 - Testar Repositório de ENTREGADOR\n" +
                "4 - Testar Repositório de PRODUTO\n" +
                "4 - Testar Repositório de PRODUTOENTREGA\n" +
                "5 - CRIAR BANCO DE DADOS\n" +
                "6 - Sair");
            var opc = Console.ReadLine();
            if (opc.ToString().Equals("1"))
            {
                testeConferente();
            }
            else if (opc.ToString().Equals("2"))
            {

            }
            else if (opc.ToString().Equals("3"))
            {

            }
            else if (opc.ToString().Equals("4"))
            {

            }
            else if (opc.ToString().Equals("5"))
            {

            }
            else if (opc.ToString().Equals("6"))
            {
                continuar = false;
            }
            else
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
            }
        }
    }
    static void testeConferente()
    {
        bool continuar = true;
        while (continuar)
        {
            DbContextOptionsBuilder<Context> optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-CNONP28\\sqlexpress09;database=FastPlus;trusted_connection=true;Encrypt=False");
            Context context = new Context(optionsBuilder.Options);
            context.Database.EnsureCreated();
            ConferenteRepository repository = new ConferenteRepository(context);
            Console.Clear();
            Console.WriteLine("Teste do Repositório de Conferente\n" +
               "1 - cadastrar\n" +
               "2 - recuperar pelo id\n" +
               "3 - recuperar tudo\n" +
               "4 - remover pelo id\n" +
               "5 - alterar pelo id\n" +
               "6 - voltar ao menu\n");
            var opc = Console.ReadLine();

            if (opc.ToString().Equals("1"))
            {
                Console.WriteLine("Digite o nome do conferente");
                var nome = Console.ReadLine();
                Conferente conferente = new Conferente();
                conferente.nome = nome;
                repository.Insert(conferente);  
                repository.Persist();
                Console.WriteLine("Conferente cadastrado com sucesso");
                Console.ReadLine();
            }
            else if (opc.ToString().Equals("2"))
            {
            }
            else if (opc.ToString().Equals("3"))
            {
                List<Conferente> lista = repository.GetAll();
                foreach(Conferente conf in lista)
                {
                    Console.WriteLine("ID :" + conf.id.ToString());
                    Console.WriteLine("Nome :" + conf.nome);
                    Console.WriteLine("");
                    Console.ReadLine();

                }
            }
            else if (opc.ToString().Equals("4"))
            {
                Console.WriteLine("informe o id a deletar");
                var Id = Console.ReadLine();

                int? idConvertido = null;
                try
                {
                    idConvertido = Convert.ToInt32(Id);
                }
                catch
                {
                    Console.WriteLine("Valor de id inválido");
                    Console.ReadLine();
                }
                if (idConvertido != null)
                {
                    Conferente conferente = repository.GetById(idConvertido.Value);
                    if (conferente != null)
                    {
                        repository.Delete(conferente);
                        repository.Persist();
                    }
                    else
                    {
                        Console.WriteLine("Conferente Inexistente");
                        Console.ReadLine();
                    }
                }
            }
            else if (opc.ToString().Equals("5"))
            {
            }
            else if (opc.ToString().Equals("6"))
            {
                continuar = false;
            }
            else
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
            }
        }
    }
}