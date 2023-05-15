using ServicoInspecao.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Dominio.Interfaces.Services
{
    public interface IUsuarioDominioService
    {
        //atributos
        void CadastrarUsuario(Usuario usuario);
        Usuario ObterUsuario(string login);
        Usuario ObterAcesso(string login, string senha);
    }
}
