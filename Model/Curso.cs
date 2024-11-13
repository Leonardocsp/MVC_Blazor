using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Blazor.Model
{
    public class Curso
    {
        [Key]
        public int ID_Curso { get; set; }

        [Required(ErrorMessage = "O Nome do Curso é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome do Curso não pode exceder 100 caracteres.")]
        public string? Nome_Curso { get; set; }

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A Carga Horária é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A Carga Horária deve ser maior que zero.")]
        public int Carga_Horaria { get; set; }

        [Required(ErrorMessage = "A Data de Início é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime Data_Inicio { get; set; }

        [Required(ErrorMessage = "A Data de Fim é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime Data_Fim { get; set; }

        [Required(ErrorMessage = "O Valor é obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor deve ser maior que zero.")]
        public decimal Valor { get; set; }
    }
}
