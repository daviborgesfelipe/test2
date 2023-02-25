using EstoqueEquipamento.Data;
using EstoqueEquipamento.DTOs;
using EstoqueEquipamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueEquipamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentoController : ControllerBase
    {
        public readonly EstoqueEquipamentoDbContext _context;
        public EquipamentoController(EstoqueEquipamentoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<EquipamentoDTO>> Get()
        {
            var objto = _context.Equipamentos.ToList();
            return Ok(objto);
        }
        [HttpPost]
        public ActionResult<Equipamento> Post(
            [FromBody] EquipamentoDTO novoEquipamento
        )
        {
            Equipamento equipamento = new()
            {
                Nome = novoEquipamento.Nome,
                Preco = novoEquipamento.Preco,
                NumeroSerie = novoEquipamento.NumeroSerie,
                DataFabricacao = novoEquipamento.DataFabricacao,
                Fabricante = novoEquipamento.Fabricante
            };
            _context.Equipamentos.Add(equipamento);
            _context.SaveChanges();
            return Created("/api/equipamento", equipamento);
        }
        [HttpPut("{id}")]
        public ActionResult<Equipamento> Put(
            [FromBody] EquipamentoDTO equipamento,
            [FromRoute] int id
        )
        {
            Equipamento query = _context.Equipamentos.Find(id);
            if (query == null) return NotFound();
            query.Nome = equipamento.Nome;
            query.Preco = equipamento.Preco;
            query.NumeroSerie = equipamento.NumeroSerie;
            query.DataFabricacao = equipamento.DataFabricacao;
            query.Fabricante = equipamento.Fabricante;
            _context.SaveChanges();
            return Ok(query);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(
        [FromRoute] int id
        )
        {
            Equipamento query = _context.Equipamentos.Find(id);

            if (query == null) return NotFound();

            _context.Equipamentos.Remove(query);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
