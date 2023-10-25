using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI1.Models
{
    [Table("Vendedores")]
    public class Vendedor
    {
        [Key]
        public long IdVendedor { get; set; }

        [Required]
        [StringLength(50)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public bool Estado { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
