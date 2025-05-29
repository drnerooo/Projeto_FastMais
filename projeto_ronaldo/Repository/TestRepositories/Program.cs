using Business;
//using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.EF;
using Repository.Repositories;

public class Program
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
                Conferente();
            }
            else if (opc.ToString().Equals("2"))
            {
                Entrega();
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
    static void Conferente()
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
                Console.WriteLine("informe o id a pesquisar");
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
                        Console.WriteLine("ID :" + conferente.id.ToString());
                        Console.WriteLine("Nome :" + conferente.nome);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Conferente Inexistente");
                        Console.ReadLine();
                    }
                }
            }
            else if (opc.ToString().Equals("3"))
            {
                List<Conferente> lista = repository.GetAll();
                foreach(Conferente conf in lista)
                {
                    Console.WriteLine("ID :" + conf.id.ToString());
                    Console.WriteLine("Nome :" + conf.nome);
                    Console.WriteLine("");
                }
                Console.ReadLine();
            }
            else if (opc.ToString().Equals("4"))
            {
                List<Conferente> lista = repository.GetAll();
                foreach (Conferente conf in lista)
                {
                    Console.WriteLine("ID :" + conf.id.ToString());
                    Console.WriteLine("Nome :" + conf.nome);
                    Console.WriteLine("");
                }
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
                        Console.WriteLine("Conferente removido com sucesso");
                        Console.ReadLine();
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
                List<Conferente> lista = repository.GetAll();
                foreach (Conferente conf in lista)
                {
                    Console.WriteLine("ID :" + conf.id.ToString());
                    Console.WriteLine("Nome :" + conf.nome);
                    Console.WriteLine("");
                }
                Console.WriteLine("Informe o Id que deseja alterar");
                var Id = Console.ReadLine();

                int? idConvertido = null;
                try
                {
                    idConvertido = Convert.ToInt32(Id);
                    Console.ReadLine();
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
                        Console.WriteLine("Informe o novo nome do conferente");
                        var nome = Console.ReadLine();
                        conferente.nome = nome;
                        repository.Update(conferente);
                        repository.Persist();
                        Console.WriteLine("Conferente alterado com sucesso");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Conferente Inexistente");
                        Console.ReadLine();
                    }
                }

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

    static void Entrega()
    {
        var dateTime = DateTime.Now;
        bool continuar = true;
        while (continuar)
        {
            DbContextOptionsBuilder<Context> optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-CNONP28\\sqlexpress09;database=FastPlus;trusted_connection=true;Encrypt=False");
            Context context = new Context(optionsBuilder.Options);
            context.Database.EnsureCreated();
            EntregaRepository repository = new EntregaRepository(context);
            Console.Clear();
            Console.WriteLine("Teste do Repositório de Entrega\n" +
               "1 - cadastrar\n" +
               "2 - recuperar pelo id\n" +
               "3 - recuperar tudo\n" +
               "4 - remover pelo id\n" +
               "5 - alterar pelo id\n" +
               "6 - voltar ao menu\n");
            var opc = Console.ReadLine();

            if (opc.ToString().Equals("1"))
            {
                Entrega entrega = new Entrega();;
                entrega.inicio = dateTime;
                Console.WriteLine("Digite a Rua da Entrega");
                var endereco = Console.ReadLine();
                Console.WriteLine("Digite a Descrição da Entrega (Caso não tenha, aperte enter)");
                var descricao = Console.ReadLine();
                Console.WriteLine("Digite o Valor da Entrega");
                float valor = Convert.ToSingle(Console.ReadLine());
                entrega.endereco = endereco;
                entrega.descricao = descricao;
                entrega.valor = valor;
                repository.Insert(entrega);
                repository.Persist();
                Console.WriteLine("Entrega cadastrada com sucesso");
                Console.ReadLine();
            }
            else if (opc.ToString().Equals("2"))
            {
                Console.WriteLine("informe o id a pesquisar");
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
                    Entrega entrega = repository.GetById(idConvertido.Value);
                    if (entrega != null)
                    {
                        Console.WriteLine("ID :" + entrega.id.ToString());
                        Console.WriteLine("Rua :" + entrega.endereco);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Entrega Inexistente");
                        Console.ReadLine();
                    }
                }
            }
            else if (opc.ToString().Equals("3"))
            {
                List<Entrega> lista = repository.GetAll();
                foreach (Entrega ent in lista)
                {
                    Console.WriteLine("ID :" + ent.id.ToString());
                    Console.WriteLine("Rua :" + ent.endereco);
                    Console.WriteLine("");
                }
                Console.ReadLine();
            }
            else if (opc.ToString().Equals("4"))
            {
                List<Entrega> lista = repository.GetAll();
                foreach (Entrega ent in lista)
                {
                    Console.WriteLine("ID :" + ent.id.ToString());
                    Console.WriteLine("Nome :" + ent.endereco);
                    Console.WriteLine("");
                }
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
                    Entrega entrega = repository.GetById(idConvertido.Value);
                    if (entrega != null)
                    {
                        repository.Delete(entrega);
                        repository.Persist();
                        Console.WriteLine("Conferente removido com sucesso");
                        Console.ReadLine();
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
                List<Entrega> lista = repository.GetAll();
                foreach (Entrega ent in lista)
                {
                    Console.WriteLine("ID :" + ent.id.ToString());
                    Console.WriteLine("Rua :" + ent.endereco);
                    Console.WriteLine("");
                }
                Console.WriteLine("Informe o Id que deseja alterar");
                var Id = Console.ReadLine();

                int? idConvertido = null;
                try
                {
                    idConvertido = Convert.ToInt32(Id);
                    Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Valor de id inválido");
                    Console.ReadLine();
                }
                if (idConvertido != null)
                {
                    Entrega entrega = repository.GetById(idConvertido.Value);
                    if (entrega != null)
                    {
                        Console.WriteLine("Informe a nova rua do conferente");
                        var rua = Console.ReadLine();
                        entrega.endereco = rua;
                        repository.Update(entrega);
                        repository.Persist();
                        Console.WriteLine("Conferente alterado com sucesso");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Conferente Inexistente");
                        Console.ReadLine();
                    }
                }

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