using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_24BM.Models
{
    public class Curriculum
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo nombre no debe superar los 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(50, ErrorMessage = "El campo Apellido no debe superar los 50 caracteres")]

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        public string Apellidos { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [FechaNacimientoValida(ErrorMessage = "Debes ser mayor de 18 años para registrarte.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        public string Objetivo { get; set; }

        public string DatosLaboral { get; set; }

        [NotMapped]
        public IFormFile? Foto { get; set; }
        public string? NombreFoto { get; set; }

        [Required(ErrorMessage = "La CURP es obligatoria")]
        [RegularExpression(@"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z\d]\d$", ErrorMessage = "La CURP no es válida.")]
        public string CURP { get; set; }
    }
}
