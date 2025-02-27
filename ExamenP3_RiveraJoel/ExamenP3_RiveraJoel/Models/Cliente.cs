using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenP3_RiveraJoel.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientED { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
