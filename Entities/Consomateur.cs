using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Consomateur
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int Age { get; set; }

    public string Adresse { get; set; } = null!;
}
