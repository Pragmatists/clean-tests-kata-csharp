

using System.Collections.Generic;

public class InvoiceLines {

    public readonly List<InvoiceLine> invoiceLines;

    public InvoiceLines(params InvoiceLine[] invoiceLines) {
        this.invoiceLines = new List<InvoiceLine>(invoiceLines);
    }

}
