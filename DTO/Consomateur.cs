using System;
using System.Collections.Generic;

namespace API.DTO;

public partial class ConsomateurDTO
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int Age { get; set; }

    public string Adresse { get; set; } = null!;
}
