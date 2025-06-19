namespace BackendDelivery.DTOs
{
    public class MaisVendidoResponseDTO
    {
        public int AlimentoId { get; set; }
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
        public double Nota { get; set; }
        public int TempoPreparo { get; set; }
        public string Tipo { get; set; } = "";
        public string? FotoUrl { get; set; }
        public string RestauranteNome { get; set; } = "";
        public int QuantidadeVendida { get; set; }
    }
}
