using System.ComponentModel.DataAnnotations;

namespace prueba2crud.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }
        [Required (ErrorMessage = "el nombre el obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "el telefono el obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "el correo el obligatorio")]
        public string? Correo { get; set; }
    }
}
