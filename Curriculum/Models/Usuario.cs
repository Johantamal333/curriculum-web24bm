using System.ComponentModel.DataAnnotations;

namespace Curriculum.Models
{
    public class Usuario
    {
        [Key]
       public int Id { get; set; }

        [Required (ErrorMessage = "Campo obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [Required (ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

        [Required (ErrorMessage = "Campo obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
           public string Correo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Experiencia { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Estudios { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Habilidades { get; set; }
        [Required]
        public string CURP { get; set; }
        
        public byte[] ImagenPerfil { get; set; }

    }
}
