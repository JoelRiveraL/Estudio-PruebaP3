using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace ExamenP3_RiveraJoel.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductD { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }
    }
}
