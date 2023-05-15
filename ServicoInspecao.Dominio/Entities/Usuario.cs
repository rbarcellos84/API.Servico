using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Dominio.Entities
{
    public class Usuario
    {
        //atributos
        public Guid  IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }

        //relacionamento / associacao
        public List<Inspecao> Inspecoes { get; set; }
    }
}
