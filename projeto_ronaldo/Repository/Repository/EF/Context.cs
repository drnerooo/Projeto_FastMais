using Business;
using Microsoft.EntityFrameworkCore;
using System.Formats.Tar;

namespace Repository.EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {}

        public DbSet<Conferente> Conferentes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Produto> Produtos { get; set; } 
        public DbSet<ProdutoEntrega> ProdutoEntrega { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conferente>( 
               t =>
               {
                   t.ToTable("Conferente");
                   t.HasKey(t => t.id);
                   t.Property(t => t.id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                   t.Property(t => t.nome).HasColumnType("varchar(128)").IsRequired();
                   t.HasMany(t => t.entrega_conf)
                       .WithOne(t => t.conferente)
                       .HasForeignKey(t => t.id)
                       .OnDelete(DeleteBehavior.NoAction)
                       .IsRequired();
               }
            );
            modelBuilder.Entity<Entregador>(
               t =>
               {
                   t.ToTable("Entregador");
                   t.HasKey(t => t.id);
                   t.Property(t => t.id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                   t.Property(t => t.nome).HasColumnType("varchar(128)").IsRequired();
                   t.HasMany(t => t.entrega_ent)
                       .WithOne(t => t.entregador)
                       .HasForeignKey(t => t.id)
                       .OnDelete(DeleteBehavior.NoAction)
                       .IsRequired();
               }
           );

            modelBuilder.Entity<Produto>(
                t =>
                {
                    t.ToTable("Produto");
                    t.HasKey(t => t.id);
                    t.Property(t => t.id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                    t.Property(t => t.nome).HasColumnType("varchar(128)").IsRequired();
                    t.Property(t => t.valor).HasColumnType("float").IsRequired();
                    t.HasOne(t => t.produtoentrega)
                        .WithMany(t => t.produtos)
                        .HasForeignKey(t => t.id)
                        .OnDelete(DeleteBehavior.NoAction) .IsRequired();
                }
           );
            modelBuilder.Entity <Entrega>(
                t =>
                {
                    t.ToTable("Entrega");
                    t.HasKey(t => t.id);
                    t.Property(t => t.id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                    t.Property(t => t.endereco).HasColumnType("varchar(128)").IsRequired();
                    t.Property(t => t.valor).HasColumnType("float").IsRequired();
                    t.Property(t => t.descricao).HasColumnType("varchar(128)").IsRequired();
                    t.Property(t => t.inicio).HasColumnType("datetime").IsRequired();
                    t.Property(t => t.fim).HasColumnType("datetime").IsRequired();
                    t.HasOne(t => t.conferente)
                        .WithMany(t => t.entrega_conf)
                        .HasForeignKey(t => t.conferenteID)
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                    t.HasOne(t => t.produtoentrega)
                        .WithMany(t => t.entregas)
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                    t.HasOne(t => t.entregador)
                        .WithMany(t => t.entrega_ent)
                        .HasForeignKey(t => t.entregadorID)
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                }
           );
            modelBuilder.Entity<ProdutoEntrega>(
                t =>
                {
                    t.ToTable("ProdutoEntrega");
                    t.Property(t => t.quantidade).HasColumnType("int").IsRequired();
                    t.HasMany(t => t.produtos)
                        .WithOne(t => t.produtoentrega)
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                    t.HasMany(t => t.entregas)
                        .WithOne(t => t.produtoentrega)
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();


                }
           );
        }
    }
}
