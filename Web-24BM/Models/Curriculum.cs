using System.ComponentModel.DataAnnotations;

namespace Web_24BM.Models
{
    public class Curriculum
    {
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(50,ErrorMessage = "El nombre no debe superar los 50 caracteres")]

        public int Nombre { get; set; }

        [StringLength(50, ErrorMessage = "El apellido no debe superar los 50 caracteres")]
        public string Apellido { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es un campo obligatorio")]
        public string Direccion { get; set; }


        public string Objetivo { get; set; }

        public IFormFile Foto { get; set; }

        public List<DatoLaboral> DatosLaborales { get; set; }

    }
}
