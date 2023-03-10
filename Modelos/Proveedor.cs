using System.ComponentModel.DataAnnotations;

namespace APIClientes.Modelos
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        [StringLength(150)]
        public string? RazonSocial { get; set; }
        [Required]
        [StringLength(50)]
        public string? SectorComercial { get; set; }
        [Required]
        [StringLength(20)]
        public string? TipoDocumento { get; set; }
        [Required]
        [StringLength(20)]
        public string? NumeroDocumento { get; set; }
        [StringLength(100)]
        public string? Direccion { get; set; }
        [StringLength(20)]
        public string? Telefono { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(100)]
        public string? Url { get; set; }
    }
}
