using ServicoInspecao.Dominio.Entities;
using ServicoInspecao.Dominio.Interfaces.Repositories;
using ServicoInspecao.Dominio.Interfaces.Services;
using ServicoInspecao.Dominio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ServicoInspecao.Dominio.Services
{
    public class UsuarioDominioService : IUsuarioDominioService
    {
        //atributo
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDominioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                var senhaCodificada = MD5Helper.Encrypt(usuario.Senha);
                usuario.IdUsuario = Guid.NewGuid();
                usuario.DataCadastro = DateTime.Now;
                usuario.Senha = senhaCodificada;
                if (_usuarioRepository.GetByLogin(usuario.Login) != null)
                {
                    throw new Exception("Login ja cadastrado no sistema.");
                }
                _usuarioRepository.CreateUsuario(usuario);
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao cadastrar o usuário. - {e.Message}");
            }
        }

        public Usuario ObterAcesso(string login, string senha)
        {
            try
            {
                var senhaCodificada = MD5Helper.Encrypt(senha);
                var usuario = _usuarioRepository.GetByAcesso(login, senhaCodificada);
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao selecionar o login. - {e.Message}");
            }
        }

        public Usuario? ObterUsuario(string login)
        {
            try
            {
                return _usuarioRepository.GetByLogin(login);
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao selecionar o login. - {e.Message}");
            }
        }
    }
}
