using System.ComponentModel.DataAnnotations;

namespace FormularioAPI.Models
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public List<Pergunta>? Perguntas { get; set; }
    }
}