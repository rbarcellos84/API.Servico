namespace ServicoInspecao.API.Model
{
    public class InspecaoLeituraModel
    {
        public string IdInspecao { get; set; }
        public string CodigoEmpresa { get; set; }
        public string CodigoCorretor { get; set; }
        public string CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string NumeroInspecao { get; set; }
        public string DataCadastro { get; set; }
        public string IdUsuario { get; set; }
    }
}
