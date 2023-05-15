using ServicoInspecao.Dominio.Entities;
using ServicoInspecao.Dominio.Interfaces.Repositories;
using ServicoInspecao.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoInspecao.Dominio.Services
{
    public class InspecaoDominioService : IInspecaoDominioService
    {
        //atributo
        private readonly IInspecaoRepository _inspecaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public InspecaoDominioService(IInspecaoRepository inspecaoRepository, IUsuarioRepository usuarioRepository)
        {
            _inspecaoRepository = inspecaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public void CadastrarInspecao(Inspecao inspecao, string login)
        {
            try
            {
                inspecao.IdInspecao = Guid.NewGuid();
                inspecao.DataCadastro = DateTime.Now;
                var usuario = _usuarioRepository.GetByLogin(login);
                if (usuario == null)
                {
                    throw new Exception("Login não encontrado.");
                }
                inspecao.IdUsuario = usuario.IdUsuario;
                _inspecaoRepository.CreateInspecao(inspecao);
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao cadatrar uma inspeção. - {e.Message}");
            }
        }

        public List<Inspecao> ConsultarTodasInspecoes(Guid idUsuario)
        {
            try
            {
                return _inspecaoRepository.GetAllInspecao(idUsuario);
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao selecionar as inspeção. - {e.Message}");
            }
            
        }
    }
}
