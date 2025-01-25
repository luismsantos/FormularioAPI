using FormularioAPI.Context;
using FormularioAPI.DTO;
using FormularioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormularioAPI.Controllers;

[Route("api/[controller]")]
public class RespostaController(AppDbContext context) : ControllerBase
{
   
    [HttpGet]
    public ActionResult<IEnumerable<Resposta>> Get()
    {
        var resposta = context.Respostas.ToList();
        return resposta is null || !resposta.Any() ? NotFound("Não encontrado") : Ok(resposta);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Resposta> Get(int id)
    {
        var resposta = context.Respostas.FirstOrDefault(r => r.RespostaId == id);
        return resposta is null ? NotFound("ID não encontrado") : Ok(resposta);
    }

    [HttpPost]
    public ActionResult<Pergunta> Post(RespostaInserirDTO respostaInserirDto)
    {
        var pergunta = context.Perguntas.FirstOrDefault(p => p.PerguntaId == respostaInserirDto.PerguntaId);

        var resposta = new Resposta()
        {
            Descricao = respostaInserirDto.Descricao
        };

        if (string.IsNullOrEmpty(resposta.Descricao))
            return BadRequest("Valor invalido");

        pergunta.Respostas ??= new List<Resposta>();
        pergunta.Respostas.Add(resposta);

        context.SaveChanges();
        return pergunta;
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, [FromBody] RespostaInserirDTO respostaInserirDTO)
    {
        var resposta = context.Respostas.FirstOrDefault(r => r.RespostaId == id);

        if (resposta is null)
            return NotFound("ID não encontrado");

        resposta.Descricao = respostaInserirDTO.Descricao;
        context.Entry(resposta).State = EntityState.Modified;
        context.SaveChanges();
        return Ok(resposta);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var resposta = context.Respostas.FirstOrDefault(r => r.RespostaId == id);

        if (resposta is null)
            return NotFound("ID não encontrado");

        context.Respostas.Remove(resposta);
        context.SaveChanges();
        return Ok();
    }




}