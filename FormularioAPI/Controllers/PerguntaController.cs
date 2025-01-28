using FormularioAPI.Context;
using FormularioAPI.DTO;
using FormularioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormularioAPI.Controllers;

[Route("api/[controller]")]
public class PerguntaController(AppDbContext context) : ControllerBase
{

    [HttpGet]
    public ActionResult<IEnumerable<Pergunta>> Get()
    {
        var pergunta = context.Perguntas.ToList();

        return pergunta is null || !pergunta.Any() ? NotFound("Não encontrado") : Ok(pergunta);
    }

    [HttpGet("{id}", Name = "ObterPergunta")]
    public ActionResult<Pergunta> Get(int? id)
    {
        var pergunta = context.Perguntas.Include(p => p.Respostas).FirstOrDefault(p => p.PerguntaId == id);

        return pergunta is null ? NotFound("Não encontrado") : Ok(pergunta);
    }

    [HttpPost]
    public ActionResult<Formulario> Post([FromBody] PerguntaInserirDTO perguntaInserirDto)
    {
        var formulario = context.Formularios.FirstOrDefault(f => f.Id == perguntaInserirDto.FormularioId);

        var pergunta = new Pergunta(perguntaInserirDto.Descricao);
      
        formulario.Perguntas ??= new List<Pergunta>(); 
        formulario.Perguntas.Add(pergunta);

        context.SaveChanges();
        return Ok("feito");
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, [FromBody] PerguntaAlterarDTO perguntaAlterarDTO)
    {
        var pergunta = context.Perguntas.FirstOrDefault(p => p.PerguntaId == id);

        pergunta.SetDescricao(perguntaAlterarDTO.Descricao);

        context.SaveChanges();
        return Ok(pergunta);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var pergunta = context.Perguntas.FirstOrDefault(p => p.PerguntaId == id);

        if (pergunta is null)
            return NotFound("ID não encontrado");

        context.Perguntas.Remove(pergunta);
        context.SaveChanges();
        return Ok(pergunta);

    }
}