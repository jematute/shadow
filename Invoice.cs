using System;
using System.Collections.Generic;

namespace shadow;

public partial class Invoice
{
    public long InvoiceId { get; set; }

    public long CustomerId { get; set; }

    public byte[] InvoiceDate { get; set; }

    public string BillingAddress { get; set; }

    public string BillingCity { get; set; }

    public string BillingState { get; set; }

    public string BillingCountry { get; set; }

    public string BillingPostalCode { get; set; }

    public byte[] Total { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();
}
