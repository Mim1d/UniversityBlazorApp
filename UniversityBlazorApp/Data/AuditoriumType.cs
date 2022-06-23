using System;
using System.Collections.Generic;

namespace UniversityBlazorApp.Data
{
    public partial class AuditoriumType
    {
        public AuditoriumType()
        {
            Auditoria = new HashSet<Auditorium>();
        }

        public int Id { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<Auditorium> Auditoria { get; set; }
    }
}
