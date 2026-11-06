namespace WebAPI_añomesdia_Jordy_Hurtado.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string? titulo;
        public string? descripcion;
        public int duracion;

        public string? materiales;
        public string? cronograma;

        public int InstructorId { get; set; }

        public User Instructor { get; set; }
    }
}
