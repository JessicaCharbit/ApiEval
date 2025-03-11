using System;
using System.Collections.Generic;

namespace API.DTO;

public partial class ArticleDTO
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public float Prix { get; set; }
}
