using ServicoInspecao.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Dominio.Interfaces.Services
{
    public interface IInspecaoDominioService
    {
        void CadastrarInspecao(Inspecao inspecao, string login);
        List<Inspecao> ConsultarTodasInspecoes(Guid idUsuario);
        //Usuario ObterUsuario(string login);
    }
}
