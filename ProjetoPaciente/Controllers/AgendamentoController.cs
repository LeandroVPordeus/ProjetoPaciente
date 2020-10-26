using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPaciente.Context;
using ProjetoPaciente.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPaciente.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AgendamentoController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Agendamento>> Get()
        {
            return _context.Agendamentos.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterAgendamento")]
        public ActionResult<Agendamento> Get(int id)
        {
            var agendamento = _context.Agendamentos.AsNoTracking()
                .FirstOrDefault(p => p.AgendamentoId == id);

            if (agendamento == null)
            {
                return NotFound();
            }
            return agendamento;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Agendamento agendamento)
        {

            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterAgendamento",
                new { id = agendamento.AgendamentoId }, agendamento);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Agendamento agendamento)
        {

            if (id != agendamento.AgendamentoId)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Agendamento> Delete(int id)
        {
            var agendamento = _context.Agendamentos.FirstOrDefault(p => p.AgendamentoId == id);

            if (agendamento == null)
            {
                return NotFound();
            }
            _context.Agendamentos.Remove(agendamento);
            _context.SaveChanges();
            return agendamento;
        }
    }
}

