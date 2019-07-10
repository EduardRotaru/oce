using System;
using System.Collections.Generic;
using System.Linq;

namespace OceBank.Models
{
    public class Client
    {
        private string _cnp;

        public string CNP
        {
            get
            {
                return _cnp;
            }
            set
            {
                if (value.Length == 13 
                    && value.Substring(0, 7).All(c => char.IsLetter(c)) 
                    && value.Substring(9).All(c => char.IsDigit(c)))
                {
                    _cnp = value;
                }
                else
                {
                    throw new Exception("CNP is not valid");
                }
            }
        }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<BankAccount> AccountsList { get; set; }

        public string AddNewAccount(BankAccount account)
        {
            if (!AccountsList.Any(c => c.AccountNumber == account.AccountNumber) && AccountsList.Count < 5)
            {
                AccountsList.Add(account);
                return $"Client {account.AccountNumber} has been added";
            }

            return $"Client {account.AccountNumber} couldn't be added\n";
        }


    }
}
