

namespace CRUD_mvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class datos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
    }
}
