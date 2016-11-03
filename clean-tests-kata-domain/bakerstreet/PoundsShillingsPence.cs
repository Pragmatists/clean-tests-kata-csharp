namespace clean_tests_kata_domain.bakerstreet
{
    public class PoundsShillingsPence
    {
        public static readonly PoundsShillingsPence Zero = new PoundsShillingsPence(0, 0, 0);
        public readonly int Pence;
        public readonly int Pound;
        public readonly int Shilling;

        public PoundsShillingsPence(int pound, int shilling, int pence)
        {
            this.Pound = pound;
            this.Shilling = shilling;
            this.Pence = pence;
        }
    }
}