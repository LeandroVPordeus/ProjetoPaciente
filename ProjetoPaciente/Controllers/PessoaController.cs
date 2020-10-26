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
    public class PessoaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PessoaController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            
            return _context.Pessoas.ToList();
        }

        [HttpGet("{id}", Name = "ObterPaciente")]
        public ActionResult<Pessoa> Get(int id)
        {
            
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.PacienteId == id);

            if (pessoa == null)
            {
                return NotFound();
            }
            return pessoa;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Pessoa pessoa)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPaciente",
                new { id = pessoa.PacienteId }, pessoa);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
           
            if (id != pessoa.PacienteId)
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Pessoa> Delete(int id)
        {
           
            var pessoa= _context.Pessoas.FirstOrDefault(p => p.PacienteId == id);

            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return pessoa;
        }
    }
}