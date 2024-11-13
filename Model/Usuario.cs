using System.ComponentModel.DataAnnotations;

namespace MVC_Blazor.Model
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória.")]
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public DateTime Data_Criacao { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true; 
    }
}
