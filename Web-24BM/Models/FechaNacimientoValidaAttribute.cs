using System.ComponentModel.DataAnnotations;

namespace Web_24BM.Models
{
    public class FechaNacimientoValidaAttribute : ValidationAttribute
    {
        public FechaNacimientoValidaAttribute()
        {
            ErrorMessage = "Debes ser mayor de 18 años para registrarte.";
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime fechaNacimiento)
            {
                int edad = DateTime.Now.Year - fechaNacimiento.Year;

                if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
                {
                    edad--;
                }

                return edad >= 18;
            }

            return false;
        }

    }
}
