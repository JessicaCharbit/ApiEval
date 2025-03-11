using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Article
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public float Prix { get; set; }
}
