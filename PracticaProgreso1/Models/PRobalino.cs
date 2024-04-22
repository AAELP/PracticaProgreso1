using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticaProgreso1.Models
{
    public class PRobalini
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Edad es obligatorio.")]
        [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120 años.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El salario es un campo obligatorio.")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es necesario especificar si es activo o no.")]
        public bool EsActivo { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaRegistro { get; set; }

        // Relación uno a uno con Carrera
        public int CarreraId { get; set; }
        [ForeignKey("CarreraId")]
        public Carrera Carrera { get; set; }
    }
}
