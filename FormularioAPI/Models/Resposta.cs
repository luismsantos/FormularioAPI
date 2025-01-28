using System.ComponentModel.DataAnnotations;

namespace FormularioAPI.Models;

public class Resposta
{
    [Key]
    public int RespostaId { get; set; }

    [Required(ErrorMessage = "Preencha o campo Nome.")]
    [StringLength(300)]
    public string  Descricao { get; private set; }

    public void SetDescricao(String descricao)
    {
        if(string.IsNullOrEmpty(descricao))
            throw new ArgumentException("Descrição inválida");

        if(descricao.Length > 256)
            throw new ArgumentException("Descrição deve ter no máximo 256 caracteres");

        if(descricao.Length < 5)
            throw new ArgumentException("Descrição deve ter no mínimo 5 caracteres");

        Descricao = descricao;
    }

    public Resposta(string descricao)
    {
        SetDescricao(descricao);
    }
}