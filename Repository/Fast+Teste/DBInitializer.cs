using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF
{
    public class DBInitializer
    {
        public static void Initialize(Context context){ 
            if (context.Database.EnsureCreated())
            {

                context.Conferentes.Add(
                    new Conferente("Conferente_Chefe", "admin", "admin"));

                context.Entregadores.Add(
                    new Entregador("Entregador_Chefe", "admin", "admin"));
                context.Entregas.Add(
                    new Entrega("rua dos pinheiros azedos", 50, DateTime.Now, 1, 1));

                    Produto lamp15w = new Produto("Lampada 15 Watts", 10.00f);
                    context.Produtos.Add(lamp15w);
                    Produto lamp20w = new Produto("Lampada 20 Watts", 20.00f);
                    context.Produtos.Add(lamp20w);
                    Produto caboflex15 = new Produto("Rolo de Cabo 1.5 Flexível", 3.00f);
                    context.Produtos.Add(caboflex15);

                context.SaveChanges();


            }
        }
    }
}
