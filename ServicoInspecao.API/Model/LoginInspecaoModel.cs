using System.ComponentModel.DataAnnotations;

namespace ServicoInspecao.API.Model
{
    public class LoginInspecaoModel
    {
        //[Required(ErrorMessage = "Por favor, informe o seu login.")]
        //[StringLength(12, ErrorMessage = "Por favor, informe no mínimo {1} caracteres e no maximo {0}.", MinimumLength = 8)]
        //[RegularExpression("^[a-zA-Z0-9]{8,12}$", ErrorMessage = "Por favor, informe no mínimo 8 dígitos no máximo 12 dígitos somente letras e números.")]
        public string Login { get; set; }

        //[StrongPassword(ErrorMessage = "Informe uma senha de 8 a 20 carateres e contenha 1 letra maiúscola, 1 letra minúscola, 1 numero e 1 caracter especial (@!#$%&).")]
        //[Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        //[StringLength(20, ErrorMessage = "Por favor, informe no mínimo {1} caracteres e no maximo {0}.", MinimumLength = 8)]
        public string Senha { get; set; }
    }
}
