using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    class ProyectoDTO
    {
        public Guid ProyId { get; set; }
        public string ProyNom { get; set; }
        public string ProyDesc { get; set; }
        public DateTime? ProyFecha { get; set; }
        public string ProyUrl { get; set; }
    }
}
