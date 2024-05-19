using System.ComponentModel.DataAnnotations;

namespace CycleHive.Models
{
    public class Alquiler
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El cliente es requerido")]
        public int ClienteId { get; set; }
        virtual public Cliente? Cliente { get; set; }
        [Required(ErrorMessage = "La bicicleta es requerida")]
        public int BicicletaId { get; set; }
        virtual public Bicicleta? Bicicleta { get; set; }
        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha de fin es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
    }
}
