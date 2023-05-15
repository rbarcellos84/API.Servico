using ServicoInspecao.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Dominio.Interfaces.Repositories
{
    public interface IInspecaoRepository
    {
        void CreateInspecao(Inspecao inspecao);
        List<Inspecao> GetAllInspecao(Guid idUsuario);
        //Usuario GetByLogin(string login);
    }
}
