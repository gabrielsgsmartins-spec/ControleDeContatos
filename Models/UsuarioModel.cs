using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório")]

        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo é obrigatório")]

        public string Login { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo é obrigatório")]

        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo informado não é um e-mail válido")]

        public string Senha { get; set; } = string.Empty;

        public PerfilEnum Perfil { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }

    }
}
