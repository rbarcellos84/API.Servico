using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicoInspecao.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServicoInspecao.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        //metodo para realizar o mapeamento da entidade
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //criando o nome da tabela ou acessando o nome da tabela
            builder.ToTable("USUARIO");

            //chave primaria da tabela
            builder.HasKey(u => u.IdUsuario);

            //mapeamento dos campos da tabela
            builder.Property(u => u.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();
            builder.Property(u => u.Login).HasColumnName("LOGIN").HasMaxLength(12).IsRequired().IsUnicode();
            builder.Property(u => u.Senha).HasColumnName("SENHA").HasMaxLength(50).IsRequired();
            builder.Property(u => u.DataCadastro).HasColumnName("DATACADASTRO").IsRequired();
        }
    }
}
