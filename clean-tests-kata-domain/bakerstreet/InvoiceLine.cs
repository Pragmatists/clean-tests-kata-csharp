using System;
using clean_tests_kata_domain.bakerstreet;

public class InvoiceLine {

    public readonly String product;
    public readonly PoundsShillingsPence value;

    public InvoiceLine(String product, PoundsShillingsPence value) {
        this.product = product;
        this.value = value;
    }

}
