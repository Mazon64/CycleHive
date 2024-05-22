using System.ComponentModel.DataAnnotations;

namespace CycleHive.Models
{
    public class Bicicleta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La marca es requerida")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "El modelo es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "El color es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Color { get; set; }
        [Required(ErrorMessage = "El tamaño es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Tamaño { get; set; }
        [Required(ErrorMessage = "El tipo es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        public double Precio { get; set; }
        public virtual ICollection<Alquiler>? Alquileres { get; set; }
    }
}