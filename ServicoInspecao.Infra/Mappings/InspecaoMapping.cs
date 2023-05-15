using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoInspecao.Dominio.Entities;
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
    public class InspecaoMapping : IEntityTypeConfiguration<Inspecao>
    {
        //metodo para realizar o mapeamento da entidade
        public void Configure(EntityTypeBuilder<Inspecao> builder)
        {
            //criando o nome da tabela ou acessando o nome da tabela
            builder.ToTable("INSPECAO");

            //chave primaria da tabela
            builder.HasKey(i => i.IdInspecao);

            //mapeamento dos campos da tabela
            builder.Property(i => i.CodigoEmpresa).HasColumnName("CODIGOEMPRESA").HasMaxLength(12).IsRequired();
            builder.Property(i => i.CodigoCorretor).HasColumnName("CODIGOCORRETOR").HasMaxLength(12).IsRequired();
            builder.Property(i => i.CodigoProduto).HasColumnName("CODIGOPRODUTO").HasMaxLength(12).IsRequired();
            builder.Property(i => i.NomeProduto).HasColumnName("NOMEPRODUTO").HasMaxLength(50).IsRequired();
            builder.Property(i => i.NumeroInspecao).HasColumnName("NUMEROINSPECAO").HasMaxLength(12).IsRequired();
            builder.Property(i => i.DataCadastro).HasColumnName("DATACADASTRO").IsRequired();

            //mapear a chave estrangeira (chave de 1 para muitos)
            builder.HasOne(i => i.Usuario).WithMany(u => u.Inspecoes).HasForeignKey(i => i.IdUsuario);

            //exemplo de mapeamento de chave de 1 para 1 - no caso não iremos utilizar.
            //builder.HasOne(i => i.Usuario).WithOne(u => u.Inspecoes).HasForeignKey<Inspeção>(i => i.IdUsuario);
        }
    }
}
