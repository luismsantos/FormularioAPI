using System.ComponentModel.DataAnnotations;

namespace FormularioAPI.Models
{
    public class Formulario
    {
        [Key]
        public int Id { get; private set; }
        public String Nome { get; private set; }
        public String Descricao { get; private set; }
        public List<Pergunta>? Perguntas { get; set; }

        public void SetNome(String nome)
        {
            if(string.IsNullOrEmpty(nome))
               throw new ArgumentException("O nome não pode ser nulo");

            if(nome.Length > 100)
                throw new ArgumentException("Nome deve ter no máximo 100 caracteres");

            if(nome.Length < 5)
                throw new ArgumentException("Nome deve ter no mínimo 5 caracteres");

            Nome = nome;
        }

         public void SetDescricao(String descricao)
        {
            if(string.IsNullOrEmpty(descricao))
                throw new ArgumentException("A descrição não pode ser nula");

            if(descricao.Length > 256)
                throw new ArgumentException("Descrição deve ter no máximo 256 caracteres");

            if(descricao.Length < 10)
                throw new ArgumentException("Descrição deve ter no mínimo 10 caracteres");

            Descricao = descricao;
        }

        public Formulario(String nome, String descricao)
        {
            SetDescricao(descricao);
            SetNome(nome);
        }

    }
}