
using clean_tests_kata_domain.bakerstreet;

public class Invoice {

    public readonly Recipient recipient;
    public readonly InvoiceLines lines;
    public readonly PoundsShillingsPence discount;

    public Invoice(Recipient recipient, InvoiceLines invoiceLines) :
        this(recipient, invoiceLines, PoundsShillingsPence.Zero){ }
    

    public Invoice(Recipient recipient, InvoiceLines lines, PoundsShillingsPence discount) {
        this.recipient = recipient;
        this.lines = lines;
        this.discount = discount;
    }

}
