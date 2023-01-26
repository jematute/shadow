using System;
using System.Collections.Generic;

namespace shadow;

public partial class MediaType
{
    public long MediaTypeId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Track> Tracks { get; } = new List<Track>();
}
