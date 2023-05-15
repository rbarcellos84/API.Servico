using ServicoInspecao.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Dominio.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        //atributos
        void CreateUsuario(Usuario usuario);
        Usuario GetByLogin(string login);
        Usuario GetByAcesso(string login, string senha);
    }
}
