namespace EstoqueEquipamento.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Fabricante { get; set; }
        public virtual List<Chamado> Chamados { internal get; set; }
    }
}
