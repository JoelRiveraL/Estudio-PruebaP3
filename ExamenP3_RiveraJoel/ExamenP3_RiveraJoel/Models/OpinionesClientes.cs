using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenP3_RiveraJoel.Models
{
    public class OpinionesClientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OpinionID { get; set; }

        [Required]
        public int ClientED { get; set; }

        public int? ProductD { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Calificacion { get; set; }

        [StringLength(500, ErrorMessage = "El comentario no puede exceder los 500 caracteres.")]
        public string Comentario { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [ForeignKey("ClientED")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("ProductD")]
        public virtual Producto Producto { get; set; }
    }

}