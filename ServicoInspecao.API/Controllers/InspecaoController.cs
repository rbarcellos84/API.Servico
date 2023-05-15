using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicoInspecao.API.Model;
using ServicoInspecao.Dominio.Entities;
using ServicoInspecao.Dominio.Interfaces.Services;
using ServicoInspecao.Dominio.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoInspecao.API.Controllers
{
    //validãcao de autenticacao
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class InspecaoController : ControllerBase
    {
        private readonly IInspecaoDominioService _inspecaoDominioService;
        private readonly IUsuarioDominioService _usuarioDominioService;

        public InspecaoController(IInspecaoDominioService inspecaoDominioService, IUsuarioDominioService usuarioDominioService)
        {
            _inspecaoDominioService = inspecaoDominioService;
            _usuarioDominioService = usuarioDominioService;
        }

        // POST: api/<InspecaoController>
        [HttpPost]
        [Route("RegistrarInspecao")]
        public async Task<IActionResult> RegistrarInspecao(InspecaoCadastroModel model)
        {
            try
            {
                var inspecao = new Inspecao();

                //obterndo dados do usuario
                inspecao.CodigoEmpresa = model.CodigoEmpresa;
                inspecao.CodigoCorretor = model.CodigoCorretor;
                inspecao.CodigoProduto = model.CodigoProduto;
                inspecao.NomeProduto = model.NomeProduto;
                inspecao.NumeroInspecao = model.NumeroInspecao;
                _inspecaoDominioService.CadastrarInspecao(inspecao, model.Login);

                return StatusCode(201, new { mensagem = $"Produto {inspecao.NomeProduto} cadastrado com sucesso!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha {e.Message}." });
            }
        }

        // GET: api/<InspecaoController>
        [Route("SelecionarInspecao")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InspecaoLeituraModel))]
        public async Task<IActionResult> SelecionarInspecao(string login)
        {
            try
            {
                //obterndo dados do usuario
                var usuario = _usuarioDominioService.ObterUsuario(login);
                if (usuario == null)
                    return StatusCode(401, new { mensagem = $"Login não existente ou inválido." });

                List<InspecaoLeituraModel> lista = new List<InspecaoLeituraModel>();
                foreach (var item in _inspecaoDominioService.ConsultarTodasInspecoes(usuario.IdUsuario))
                {
                    InspecaoLeituraModel model = new InspecaoLeituraModel();
                    model.IdInspecao = item.IdInspecao.ToString();
                    model.CodigoEmpresa = item.CodigoEmpresa;
                    model.CodigoCorretor = item.CodigoCorretor;
                    model.CodigoProduto = item.CodigoProduto;
                    model.NomeProduto = item.NomeProduto;
                    model.NumeroInspecao = item.NumeroInspecao;
                    model.DataCadastro = item.DataCadastro.ToString();
                    model.IdUsuario = item.IdUsuario.ToString();
                    lista.Add(model);
                }

                return StatusCode(200, lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha {e.Message}." });
            }
        }
    }
}
