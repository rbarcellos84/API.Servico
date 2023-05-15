using Microsoft.EntityFrameworkCore;
using ServicoInspecao.Infra.Mappings;
using ServicoInspecao.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Infra.Contexts
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string de conexao com o banco de dados
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BdInspecao;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adiciona cada classe de mapeamento do projeto
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new InspecaoMapping());
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Inspecao> Inspecao { get; set; }

        ///<summary>
        ///PM> Add-Migration Inicial
        ///PM> Build started...
        ///PM> Build succeeded.
        ///PM> To undo this action, use Remove-Migration.
        ///PM> Update-Database
        ///PM> Build started...
        ///PM> Build succeeded.
        ///PM> Applying migration '20230502013507_Inicial'.
        ///PM> Done.
        ///</summary>
    }
}
