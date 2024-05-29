using System.ComponentModel.DataAnnotations;

namespace CycleHive.Models
{
    public class Alquiler : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = "La bicicleta es requerida")]
        public int BicicletaId { get; set; }

        public Bicicleta? Bicicleta { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        
        public int PrecioTotal { get; set;  }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var minFecha = DateTime.Now.Date;
            var maxFecha = DateTime.Now.Date.AddDays(30);

            if (FechaInicio < minFecha || FechaInicio > maxFecha)
            {
                yield return new ValidationResult($"La fecha de inicio debe estar entre {minFecha:dd-MM-dd} y {maxFecha:dd-MM-yyyy}", new[] { nameof(FechaInicio) });
            }

            if (FechaFin < minFecha || FechaFin > maxFecha)
            {
                yield return new ValidationResult($"La fecha de fin debe estar entre {minFecha:dd-MM-yyyy} y {maxFecha:dd-MM-yyyy}", new[] { nameof(FechaFin) });
            }

            if (FechaInicio > FechaFin)
            {
                yield return new ValidationResult("La fecha de inicio no puede ser mayor que la fecha de fin", new[] { nameof(FechaInicio), nameof(FechaFin) });
            }

            if (ClienteId <= 0)
            {
                yield return new ValidationResult("Debe seleccionar un cliente válido", new[] { nameof(ClienteId) });
            }

            if (BicicletaId <= 0)
            {
                yield return new ValidationResult("Debe seleccionar una bicicleta válida", new[] { nameof(BicicletaId) });
            }
        }
    }
}