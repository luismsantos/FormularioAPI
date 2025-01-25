using System.ComponentModel.DataAnnotations;

namespace FormularioAPI.Models;

public class Pergunta
{
    [Key]
    public int PerguntaId { get; set; }

    [Required(ErrorMessage = "É necessário a descrição da pergunta")]
    [StringLength(300)]
    public string Descricao { get;  private set; }
    
    public ICollection<Resposta> Respostas { get; set; }



    public void SetDescricao(string descricao)
    {
     if (string.IsNullOrEmpty(descricao))
            throw new ArgumentException("Descrição inválida");

     if (descricao.Length > 300 || descricao.Length < 50)
            throw new ArgumentException("Descrição deve ter no máximo 300 caracteres");

        Descricao = descricao;
    }

    public Pergunta(string descricao)
    {
        SetDescricao(descricao);
    }
}
