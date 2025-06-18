namespace ProjetoDelivery.DTOs
{
    public class CarrinhoHistoricoDTO
    {
        public string NomeAlimento     { get; set; } = "";
        public string NomeRestaurante  { get; set; } = "";
        public DateTime DataCompra     { get; set; }
        public int Quantidade          { get; set; }
        public decimal Total           { get; set; }
    }
}
