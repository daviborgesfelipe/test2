using EstoqueEquipamento.Data;
using EstoqueEquipamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueEquipamento.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadoController : ControllerBase
    {
        private readonly EstoqueEquipamentoDbContext _context;
        public ChamadoController(EstoqueEquipamentoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<Chamado> Post(
            [FromBody] Chamado novoChamado
        )
        {
            Chamado chamado = new()
            {
                Titulo = novoChamado.Titulo,
                Descricao = novoChamado.Descricao,
                DataAbertura = novoChamado.DataAbertura,
                Status = novoChamado.Status,
                EquipamentoId = novoChamado.EquipamentoId,
            };

            _context.Chamados.Add(chamado);
            _context.SaveChanges();

            return Created("api/chamado", chamado.Id);
        }
        [HttpGet]
        public ActionResult<List<Chamado>> Get(
            [FromQuery] string tituloChamado
        )
        {
            var query = _context.Chamados.AsQueryable();

            if (!string.IsNullOrEmpty(tituloChamado))
            {
                query = query.Where(m => m.Titulo.Contains(tituloChamado));
            }

            return Ok(query.ToList());
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(
            [FromRoute] int id
        )
        {
            Chamado chamado = _context.Chamados.Find(id);

            if (chamado == null) return NotFound();

            _context.Chamados.Remove(chamado);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
