using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI1.Models
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        public long IdVehiculo { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(100)]
        public string Color { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public long IdVendedor { get; set; }

        [ForeignKey("IdVendedor")]
        public virtual Vendedor Vendedor { get; set; }
    }
}
