using System;
using System.Collections.Generic;

namespace Store_01.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public DateOnly? Date { get; set; }
}
