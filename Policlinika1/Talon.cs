using System;
using System.Collections.Generic;

namespace Policlinika;

public partial class Talon
{
    public int IdTalon { get; set; }

    public int? IdPatient { get; set; }

    public int? IdDoctor { get; set; }

    public DateTime DateTime { get; set; }

    public string Number { get; set; } = null!;

    public virtual Doctor? IdDoctorNavigation { get; set; }

    public virtual Patient? IdPatientNavigation { get; set; }
}
