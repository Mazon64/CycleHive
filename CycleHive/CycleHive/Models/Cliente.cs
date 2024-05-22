using System.ComponentModel.DataAnnotations;

namespace CycleHive.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Número inválido")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string? Correo { get; set; }
        public virtual ICollection<Alquiler>? Alquileres { get; set; }
    }
}