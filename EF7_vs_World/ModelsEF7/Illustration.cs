using System;
using System.Collections.Generic;

namespace EF7_vs_World.ModelsEF7;

/// <summary>
/// Bicycle assembly diagrams.
/// </summary>
public partial class Illustration
{
    /// <summary>
    /// Primary key for Illustration records.
    /// </summary>
    public int IllustrationId { get; set; }

    /// <summary>
    /// Illustrations used in manufacturing instructions. Stored as XML.
    /// </summary>
    public string? Diagram { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; } = new List<ProductModelIllustration>();
}
