using System;
using System.Collections.Generic;

namespace GalaxyNews.Database.Models;

public partial class Article
{
    public long Id { get; set; }

    public DateOnly Date { get; set; }

    public string Title { get; set; } = null!;

    public string Announce { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Image { get; set; } = null!;
}
