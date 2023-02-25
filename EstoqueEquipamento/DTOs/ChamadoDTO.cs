namespace EstoqueEquipamento.DTOs
{
    public class ChamadoDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool Status { get; set; }
        public int EquipamentoId { get; set; }
        public string Equipamento { get; set; }
    }
}
