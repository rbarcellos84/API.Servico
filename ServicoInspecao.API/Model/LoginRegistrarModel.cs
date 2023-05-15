using System.ComponentModel.DataAnnotations;

namespace ServicoInspecao.API.Model
{
    public class LoginRegistrarModel
    {
        [Required(ErrorMessage = "Por favor, informe seu nome.")]
        [StringLength(150, ErrorMessage = "Por favor, informe no mínimo {1} caracteres e no maximo {0}.", MinimumLength = 4)]
        [RegularExpression("^[a-zA-Z0-9 ]{4,150}$", ErrorMessage = "Por favor, informe no mínimo 4 dígitos no máximo 150 dígitos somente letras e números.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o seu login.")]
        [StringLength(12, ErrorMessage = "Por favor, informe no mínimo {1} caracteres e no maximo {0}.", MinimumLength = 8)]
        [RegularExpression("^[a-zA-Z0-9]{8,12}$", ErrorMessage = "Por favor, informe no mínimo 8 dígitos no máximo 12 dígitos somente letras e números.")]
        public string Login { get; set; }

        [StrongPassword(ErrorMessage = "Informe uma senha de 8 a 20 carateres e contenha 1 letra maiúscola, 1 letra minúscola, 1 numero e 1 caracter especial (@!#$%&).")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        [StringLength(20, ErrorMessage = "Por favor, informe no mínimo {1} caracteres e no maximo {0}.", MinimumLength = 8)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, confirme a senha do usuário.")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        public string ConfirmeSenha { get; set; }
    }

    public class StrongPassword : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Boolean validacao;

            validacao = false;
            if (value != null)
            {
                var senha = value.ToString();
                validacao = senha.Length >= 8 && senha.Length <= 20
                    && senha.Any(char.IsUpper) //pelo menos 1 caracter em caixa alta 
                    && senha.Any(char.IsLower) //pelo menos 1 caracter em caixa baixa
                    && senha.Any(char.IsDigit) //pelo menos 1 digito
                    && (
                        senha.Contains("@") ||
                        senha.Contains("#") ||
                        senha.Contains("!") ||
                        senha.Contains("$") ||
                        senha.Contains("%") ||
                        senha.Contains("&")
                    );
                return validacao;
            }
            return validacao;
        }
    }
}
