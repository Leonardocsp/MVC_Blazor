using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Blazor.Model
{
    public class Inscricao
    {
        [Key]
        public int ID_Inscricao { get; set; }

        [Required(ErrorMessage = "A Data de Inscrição é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime Data_Inscricao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O ID do Usuário é obrigatório.")]
        public int ID_Usuario { get; set; }

        [Required(ErrorMessage = "O ID do Curso é obrigatório.")]
        public int ID_Curso { get; set; }

        public string Status_Inscricao { get; set; } = "Ativa";

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 10, ErrorMessage = "A Nota Final deve estar entre 0 e 10.")]
        public decimal? Nota_Final { get; set; }

        public DateTime? Data_Conclusao { get; set; }

        public Usuario? Usuario { get; set; }
        public Curso? Curso { get; set; }
    }
}
