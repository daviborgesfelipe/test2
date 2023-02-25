namespace EstoqueEquipamento.DTOs
{
    public class EquipamentoDTO
    {
        public string Nome { get; set; }
        public int Preco { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Fabricante { get; set; }
    }
}
