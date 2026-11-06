using System.ComponentModel.DataAnnotations;
using WebAPI_añomesdia_Jordy_Hurtado.Models;

namespace WebAPI_añomesdia_Jordy_Hurtado.DTOs.Requuest
{
    public class RegistroUsuarioRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(RolUsuario))]
        public RolUsuario Rol { get; set; }
    }
}
