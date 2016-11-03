using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clean_tests_kata_domain.bakerstreet;
using NUnit.Framework;

namespace clean_tests_kata._4_TestObjectsCreation
{
    public class Builders
    {
        [Test]
        public void build_invoice()
        {
            Invoice invoice1 = new Invoice(
                new Recipient("Sherlock Holmes",
                    new Address("222b Baker Street",
                        "London",
                        new PostCode("NW1", "3RX"))),
                new InvoiceLines(
                    new InvoiceLine("Deerstalker Hat",
                        new PoundsShillingsPence(0, 3, 10)),
                    new InvoiceLine("Tweed Cape",
                        new PoundsShillingsPence(0, 4, 12))));
            Invoice invoice2 = TestInvoices.NewDeerstalkerAndCapeAndSwordstickInvoice();
            Invoice invoice3 = TestInvoices.NewDeerstalkerAndBootsInvoice();
        }

        [Test]
        public void build_default_invoice()
        {
            Invoice anInvoice = new InvoiceBuilder().Build();
            Assert.That(anInvoice.lines.invoiceLines, Is.Not.Empty);
        }

        [Test]
        public void build_invoice_with_no_postcode()
        {
            Invoice invoiceWithNoPostcode = InvoiceBuilder.AnInvoice()
                .WithRecipient(new RecipientBuilder()
                    .WithAddress(new AddressBuilder()
                        .WithNoPostcode()
                        .Build())
                    .Build())
                .Build();

            Assert.That(invoiceWithNoPostcode.recipient.address.postCode, Is.Null);
        }

        [Test]
        public void build_invoice_with_nested_builders()
        {
            Invoice invoice = InvoiceBuilder.AnInvoice()
                .WithRecipient(RecipientBuilder.ARecipient().WithAddress(AddressBuilder.AnAddress().WithCity("London")))
                .WithInvoiceLines(InvoiceLineBuilder.AnInvoiceLine().WithProduct("Boots"),
                    InvoiceLineBuilder.AnInvoiceLine().WithProduct("Cape"))
                .Build();

            Assert.That(invoice.recipient.address.city, Is.EqualTo("London"));
            Assert.That(invoice.lines.invoiceLines[1].product, Is.EqualTo("Cape"));
        }

        // Object Mother pattern
        public static class TestInvoices
        {
            public static Invoice NewDeerstalkerAndCapeAndSwordstickInvoice()
            {
                return new Invoice(
                    new Recipient("Sherlock Holmes",
                        new Address("222b Baker Street",
                            "London",
                            new PostCode("NW1", "3RX"))),
                    new InvoiceLines(
                        new InvoiceLine("Deerstalker Hat",
                            new PoundsShillingsPence(0, 3, 10)),
                        new InvoiceLine("Tweed Cape",
                            new PoundsShillingsPence(0, 4, 12)),
                        new InvoiceLine("Sword Stick",
                            new PoundsShillingsPence(0, 6, 9))));
            }

            public static Invoice NewDeerstalkerAndBootsInvoice()
            {
                return new Invoice(
                    new Recipient("Sherlock Holmes",
                        new Address("222b Baker Street",
                            "London",
                            new PostCode("NW1", "3RX"))),
                    new InvoiceLines(
                        new InvoiceLine("Deerstalker Hat",
                            new PoundsShillingsPence(0, 3, 10)),
                        new InvoiceLine("Boots",
                            new PoundsShillingsPence(0, 5, 0))));
            }
        }

        public class InvoiceBuilder
        {
            private Recipient recipient = RecipientBuilder.ARecipient().Build();

            private InvoiceLines lines = new InvoiceLines(InvoiceLineBuilder.AnInvoiceLine().Build());

            private PoundsShillingsPence discount = PoundsShillingsPence.Zero;

            public static InvoiceBuilder AnInvoice()
            {
                return new InvoiceBuilder();
            }

            public InvoiceBuilder WithRecipient(Recipient recipient)
            {
                this.recipient = recipient;
                return this;
            }

            public InvoiceBuilder WithInvoiceLines(params InvoiceLineBuilder[] lines)
            {
                this.lines = new InvoiceLines(lines.Select(l => l.Build()).ToArray());
                return this;
            }

            public InvoiceBuilder WithDiscount(PoundsShillingsPence discount)
            {
                this.discount = discount;
                return this;
            }

            public Invoice Build()
            {
                return new Invoice(recipient, lines, discount);
            }

            public InvoiceBuilder WithRecipient(RecipientBuilder recipientBuilder)
            {
                recipient = recipientBuilder.Build();
                return this;
            }
        }

        public class RecipientBuilder
        {
            private Address address = AddressBuilder.AnAddress().Build();

            private String name = "John H. Watson";

            public static RecipientBuilder ARecipient()
            {
                return new RecipientBuilder();
            }

            public Recipient Build()
            {
                return new Recipient(name, address);
            }

            public RecipientBuilder WithAddress(Address address)
            {
                this.address = address;
                return this;
            }

            public RecipientBuilder WithAddress(AddressBuilder addressBuilder)
            {
                address = addressBuilder.Build();
                return this;
            }
        }

        public class AddressBuilder
        {
            private PostCode postCode = new PostCode("P1R", "0AX");

            private String street = "Larch Avenue";

            private String city = "Preston";

            public static AddressBuilder AnAddress()
            {
                return new AddressBuilder();
            }

            public AddressBuilder WithNoPostcode()
            {
                postCode = null;
                return this;
            }

            public AddressBuilder WithCity(String city)
            {
                this.city = city;
                return this;
            }

            public Address Build()
            {
                return new Address(street, city, postCode);
            }
        }

        public class InvoiceLineBuilder
        {
            private String product = "Default widget";

            private PoundsShillingsPence value = new PoundsShillingsPence(1, 0, 0);

            public static InvoiceLineBuilder AnInvoiceLine()
            {
                return new InvoiceLineBuilder();
            }

            public InvoiceLineBuilder WithProduct(String product)
            {
                this.product = product;
                return this;
            }

            public InvoiceLine Build()
            {
                return new InvoiceLine(product, value);
            }
        }
    }
}