using System.ComponentModel.DataAnnotations;

namespace FormularioAPI.Models;

public class Resposta
{
    [Key]
    public int RespostaId { get; set; }

    [Required(ErrorMessage = "Preencha o campo Nome.")]
    [StringLength(300)]
    public string  Descricao { get; set; }
}