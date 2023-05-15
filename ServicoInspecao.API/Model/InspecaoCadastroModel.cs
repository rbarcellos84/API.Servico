using System.ComponentModel.DataAnnotations;

namespace ServicoInspecao.API.Model
{
    public class InspecaoCadastroModel
    {
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe o codigo da empresa com letras e números.")]
        [MaxLength(12, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [RegularExpression("^[a-zA-Z0-9]{8,12}$", ErrorMessage = "Por favor, informe no maximo 12 digitos alfanumerico.")]
        public string CodigoEmpresa { get; set; }

        [Required(ErrorMessage = "Por favor, informe o codigo do corretor com letras e números.")]
        [MaxLength(12, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [RegularExpression("^[a-zA-Z0-9]{8,12}$", ErrorMessage = "Por favor, informe no maximo 12 digitos alfanumerico.")]
        public string CodigoCorretor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o codigo do produto com letras e números.")]
        [MaxLength(12, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [RegularExpression("^[a-zA-Z0-9]{8,12}$", ErrorMessage = "Por favor, informe no maximo 12 digitos alfanumerico.")]
        public string CodigoProduto { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do produto com letras e números.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [RegularExpression("^[a-zA-Z0-9 ]{3,50}$", ErrorMessage = "Por favor, informe no maximo 50 digitos alfanumerico.")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Por favor, informe o numero da inspecao com apenas números.")]
        [MaxLength(12, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [RegularExpression("^[0-9]{8,12}$", ErrorMessage = "Por favor, informe no maximo 12 digitos numéricos.")]
        public string NumeroInspecao { get; set; }
    }
}
