﻿using System;
using System.Collections.Generic;

namespace EF7_vs_World.ModelsEF7;

public partial class VProductAndDescription
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string ProductModel { get; set; } = null!;

    public string CultureId { get; set; } = null!;

    public string Description { get; set; } = null!;
}
