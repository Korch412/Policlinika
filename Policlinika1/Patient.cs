using System;
using System.Collections.Generic;

namespace Policlinika;

public partial class Patient
{
    public int IdPatient { get; set; }

    public string Fio { get; set; } = null!;

    public int Age { get; set; }

    public string Sex { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Talon> Talons { get; set; } = new List<Talon>();
}
