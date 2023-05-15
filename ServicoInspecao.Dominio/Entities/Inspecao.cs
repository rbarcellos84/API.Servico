using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Dominio.Entities
{
    public class Inspecao
    {
        //atributos
        public Guid IdInspecao { get; set; }
        public string CodigoEmpresa { get; set; }
        public string CodigoCorretor { get; set; }
        public string CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string NumeroInspecao { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdUsuario { get; set; }

        //relacionamento / associacao
        public Usuario Usuario { get; set; }
    }
}
