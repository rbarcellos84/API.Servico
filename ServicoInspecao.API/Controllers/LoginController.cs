using Microsoft.AspNetCore.Mvc;
using ServicoInspecao.API.Model;
using ServicoInspecao.API.Security;
using ServicoInspecao.Dominio.Entities;
using ServicoInspecao.Dominio.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoInspecao.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioDominioService _usuarioDominioService;

        public LoginController(IUsuarioDominioService usuarioDominioService)
        {
            _usuarioDominioService = usuarioDominioService;
        }

        [HttpPost]
        [Route("RegistrarConta")] //definição do nome do metodo - POST
        public async Task<IActionResult> RegistrarConta(LoginRegistrarModel model)
        {
            try
            {
                var usuario = _usuarioDominioService.ObterUsuario(model.Login);
                if (usuario != null) 
                    return StatusCode(400, new { mensagem = $"Login {model.Login} já existente no sistema, entre com outro login." });

                var cadastro = new Usuario();
                cadastro.Nome = model.Nome;
                cadastro.Login = model.Login;
                cadastro.Senha = model.Senha;
                _usuarioDominioService.CadastrarUsuario(cadastro);

                return StatusCode(201, new { mensagem = $"Login {model.Login} cadastrado com sucesso." });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha {e.Message}." });
            }
        }


        //POST: api/<LoginController>
        [HttpPost]
        [Route("Login")] //definição do nome do metodo - POST
        public async Task<IActionResult> Login(LoginInspecaoModel model) 
        {
            try
            {
                var usuario = _usuarioDominioService.ObterUsuario(model.Login);
                if (usuario != null)
                {
                    if (_usuarioDominioService.ObterAcesso(model.Login, model.Senha) != null)
                    {
                        //gravar token
                        var token = JwtSecurity.GenerateToken(model.Login);
                        var login = model.Login;
                        return StatusCode(200, new { mensagem = $"Autenticação realizada com sucesso.", login, token });
                    }
                    else
                    {
                        return StatusCode(401, new { mensagem = $"Senha inválido." });
                    }
                }
                else
                {
                    return StatusCode(401, new { mensagem = $"Acesso negado login inválido." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha {e.Message}." });
            }
        }
    }
}
