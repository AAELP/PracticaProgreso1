using System.ComponentModel.DataAnnotations;

namespace PracticaProgreso1.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }

        [Required(ErrorMessage = "El nombre de la carrera es obligatorio.")]
        [StringLength(200, ErrorMessage = "El nombre de la carrera no puede exceder los 200 caracteres.")]
        public string NombreCarrera { get; set; }

        [Required(ErrorMessage = "El campus es un campo obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del campus no puede exceder los 100 caracteres.")]
        public string Campus { get; set; }

        [Required(ErrorMessage = "El número de semestres es obligatorio.")]
        [Range(1, 12, ErrorMessage = "El número de semestres debe estar entre 1 y 12.")]
        public int NumeroSemestres { get; set; }

    }
}
