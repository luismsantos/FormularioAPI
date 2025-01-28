using FormularioAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FormularioAPI.Models;
using FormularioAPI.DTO;

namespace FormularioAPI.Controllers
{
    [Route("api/[controller]")]
    public class FormularioController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Formulario>> Get()
        {
            var formulario = context.Formularios.ToList();
            return formulario is null || !formulario.Any() ? NotFound("Não encontrado") : Ok(formulario);
        }

        [HttpGet("{id}")]
        public ActionResult<Formulario> Get(int id)
        {
            var formulario = context.Formularios.Include(p => p.Perguntas)
                .ThenInclude(r => r.Respostas)
                .FirstOrDefault(p => p.Id == id);
            return formulario is null ? NotFound("ID não encontrado") : Ok(formulario);
        }

        [HttpPost]
        public ActionResult<Pergunta> Post([FromBody] FormularioInserirDTO formularioInserirDTO)
        {
            var formulario = new Formulario(formularioInserirDTO.Nome, formularioInserirDTO.Descricao);

            context.Formularios.Add(formulario);
            context.SaveChanges();
            return Ok(formulario);
        }







    }
}
