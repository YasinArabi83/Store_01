using System;
using System.Collections.Generic;

namespace Store_01.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Image { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }
}
