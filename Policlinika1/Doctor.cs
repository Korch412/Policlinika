using System;
using System.Collections.Generic;

namespace Policlinika;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public string Fio { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Talon> Talons { get; set; } = new List<Talon>();
}
