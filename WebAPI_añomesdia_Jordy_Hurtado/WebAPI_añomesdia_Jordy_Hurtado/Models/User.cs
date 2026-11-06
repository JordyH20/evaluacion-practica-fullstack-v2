namespace WebAPI_añomesdia_Jordy_Hurtado.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? PasswordHash { get; set; }
        public RolUsuario Rol { get; set; } = new RolUsuario();

        public ICollection<Curso> Cursos { get; set; } = [];
    }
}
