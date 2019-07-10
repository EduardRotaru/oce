using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OceBank.Models
{
    public class Bank
    {
        public const int INTEREST = 1;

        public string BankCode { get; set; }
        public List<Client> ClientsList { get; set; }

        public string AddNewClient(Client client)
        {
            if (!ClientsList.Any(c => c.Name == client.Name) && ClientsList.Count < 5)
            {
                ClientsList.Add(client);
                return $"Client {client.Name} has been added";
            }

            return $"Client {client.Name} couldn't be added\n";
        }

        public string DisplayClientInfo()
        {
            return GetClientInfo();
        }

        public string DisplayClientAccounts()
        {
            return GetClientAccounts();
        }

        public string MoneyTransfer(string accountNumberReceiver, string accountNumberSender, decimal amount)
        {
            return MoneyTransferOperation(accountNumberReceiver, accountNumberSender, amount);
        }

        private string GetClientInfo()
        {
            var str = new StringBuilder();

            str.AppendLine("CNP\tnume\tadresa");

            foreach (var clientInfo in ClientsList)
            {
                str.AppendLine($"{clientInfo.CNP}\t{clientInfo.Name}\t{clientInfo.Address}");
            }

            return str.ToString();
        }

        private string GetClientAccounts()
        {
            var str = new StringBuilder();

            str.AppendLine("id_cont\t\t\t\t[tip_cont]\tsuma totala\t\tdobanda_zilnica\t\t\ttotal amount RON");

            foreach (var client in ClientsList)
            {
                foreach (var account in client.AccountsList)
                {
                    string acc_type = Enum.GetName(typeof(AccountTypes), account.AccountType);

                    var interestRate = account.Amount >= 500 && account.AccountType == (AccountTypes)1 ? 1 : 0;
                    var total = account.AccountType == (AccountTypes)1 ? account.GetTotalBalance() : account.Amount;

                    str.AppendLine($"{account.AccountNumber}\t\t\t{acc_type}\t\t{account.Amount}\t\t\t{interestRate}%\t\t\t\t{total}");
                }
            }

            return str.ToString();
        }

        private string MoneyTransferOperation(string accountNumberReceiver, string accountNumberSender, decimal amount)
        {
            var clientAccounts = ClientsList.SelectMany(x => x.AccountsList);

            var bankAccountReceiver = clientAccounts.FirstOrDefault(c => c.AccountNumber == accountNumberReceiver);
            var bankAccountSender = clientAccounts.FirstOrDefault(c => c.AccountNumber == accountNumberSender);

            if (bankAccountReceiver != null && bankAccountSender != null)
            {
                if (bankAccountReceiver.AccountType == bankAccountSender.AccountType)
                {
                    if (bankAccountReceiver.AccountType == (AccountTypes)1 && amount >= 500)
                    {
                        var interest = GetTransferWithInterest(amount);

                        bankAccountReceiver.Amount += amount + interest;
                        bankAccountSender.Amount -= amount;
                        return $"{amount} with interest of {interest} have been successfully added to account {bankAccountReceiver.AccountNumber}";
                    }
                    else
                    {
                        bankAccountReceiver.Amount += amount;
                        bankAccountSender.Amount -= amount;
                        return $"{amount} have been successfully added to account {bankAccountReceiver.AccountNumber}";
                    }
                }
            }
            else
            {
                throw new Exception($"One of the accounts haven't been found");
            }

            return $"We couldn't make the transfer to the account {bankAccountReceiver.AccountNumber} with the amount of {amount}";
        }

        private decimal GetTransferWithInterest(decimal amount)
        {
            return amount / (INTEREST * 100);
        }
    }
}
