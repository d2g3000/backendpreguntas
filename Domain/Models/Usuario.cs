using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendpreguntas.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string? usuario { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? password { get; set; }
    }
}
