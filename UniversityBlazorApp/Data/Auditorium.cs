using System;
using System.Collections.Generic;

namespace UniversityBlazorApp.Data
{
    public partial class Auditorium
    {
        public int Id { get; set; }
        public string Room { get; set; } = null!;
        public int Accommodates { get; set; }
        public int? Type { get; set; }

        public virtual AuditoriumType? TypeNavigation { get; set; }
    }
}
