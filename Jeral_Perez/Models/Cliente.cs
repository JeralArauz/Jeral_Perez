using System;
using System.ComponentModel.DataAnnotations;

namespace Jeral_Perez.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El campo NOMBRES es requerido")]
        public string Nombres { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "El campo APELLIDOS es requerido")]
        public string Apellidos { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El campo CEDULA es requerido")]
        public string Cedula { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "El campo DIRECCION es requerido")]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string Sexo { get; set; }

        public DateTime FechaReg { get; set; }

        [StringLength(50)]
        public string UserReg { get; set; }
    }
}
