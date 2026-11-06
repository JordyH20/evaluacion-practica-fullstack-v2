using System.ComponentModel.DataAnnotations;
using WebAPI_añomesdia_Jordy_Hurtado.Models;

namespace WebAPI_añomesdia_Jordy_Hurtado.DTOs.Requuest
{
    public class UserRequest
     {

       [Required]
       [StringLength(100, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public string Password { get; set; } = string.Empty;

       [Required]
       [EnumDataType(typeof(RolUsuario))]
       public RolUsuario Rol { get; set; }
     

}
}
