namespace Leasing.Domain.ValueObjects
{
    public  record Money
    {
        public decimal Amount { get; }
        public string Currency { get; } 

        private Money(decimal amount, string currency)
        {
            if (amount <= 0) throw new Exception("Amount must be positive.");
            if (string.IsNullOrWhiteSpace(currency)) throw new Exception("Currency required.");
            Amount = amount;
            Currency = currency;
        }

        public static Money From(decimal amount, string currency) => new(amount, currency);



    }
}
