using System;
using System.Collections.Generic;

namespace shadow;

public partial class Album
{
    public long AlbumId { get; set; }

    public string Title { get; set; }

    public long ArtistId { get; set; }

    public virtual Artist Artist { get; set; }

    public virtual ICollection<Track> Tracks { get; } = new List<Track>();
}
