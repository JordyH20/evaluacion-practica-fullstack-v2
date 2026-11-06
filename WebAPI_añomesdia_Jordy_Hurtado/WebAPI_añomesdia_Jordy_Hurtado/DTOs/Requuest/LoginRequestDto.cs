using System.ComponentModel.DataAnnotations;

namespace WebAPI_añomesdia_Jordy_Hurtado.DTOs.Requuest
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Digite el formato correcto de un correo")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; } = string.Empty;
    }
}
