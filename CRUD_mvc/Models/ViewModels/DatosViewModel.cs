using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_mvc.Models.ViewModels
{
    public class DatosViewModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre")]
        public String nombre { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public String correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fecha_nacimiento { get; set; }

    }
}