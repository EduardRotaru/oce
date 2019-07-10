namespace OceBank.Models
{
    public interface IBankAccount
    {
        decimal GetTotalBalance();
    }

    public class BankAccount : IBankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }

        public AccountTypes AccountType { get; set; }

        public decimal GetTotalBalance()
        {
            return Amount * (decimal)4.2;
        }
    }
}
