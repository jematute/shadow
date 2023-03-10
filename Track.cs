using System;
using System.Collections.Generic;

namespace shadow;

public partial class Track
{
    public long TrackId { get; set; }

    public string Name { get; set; }

    public long? AlbumId { get; set; }

    public long MediaTypeId { get; set; }

    public long? GenreId { get; set; }

    public string Composer { get; set; }

    public long Milliseconds { get; set; }

    public long? Bytes { get; set; }

    public byte[] UnitPrice { get; set; }

    public virtual Album Album { get; set; }

    public virtual Genre Genre { get; set; }

    public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();

    public virtual MediaType MediaType { get; set; }

    public virtual ICollection<Playlist> Playlists { get; } = new List<Playlist>();
}
