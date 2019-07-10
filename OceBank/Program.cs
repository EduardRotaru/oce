using OceBank.Models;
using System;
using System.Collections.Generic;

namespace OceBank
{
    class Program
    {
        static Bank _bank = new Bank();
        static BankAccount _bankAccount = new BankAccount();
        static Client _client = new Client();

        static List<BankAccount> BankAccounts = new List<BankAccount>()
        {
            new BankAccount { AccountNumber = "Account11", AccountType = (AccountTypes)1, Amount = 100000},
            new BankAccount { AccountNumber = "Account22", AccountType = (AccountTypes)0, Amount = 10000},
            //new BankAccount { AccountNumber = "vvvvv", AccountType = (AccountTypes)1, Amount = 1000},
            //new BankAccount { AccountNumber = "nnnn", AccountType = (AccountTypes)1, Amount = 100},
        };

        static List<BankAccount> BankAccounts2 = new List<BankAccount>()
        {
            new BankAccount { AccountNumber = "Account1", AccountType = (AccountTypes)1, Amount = 200000},
            new BankAccount { AccountNumber = "Account2", AccountType = (AccountTypes)1, Amount = 20000},
            //new BankAccount { AccountNumber = "vvvvv2", AccountType = (AccountTypes)1, Amount = 2000},
            //new BankAccount { AccountNumber = "nnnn2", AccountType = (AccountTypes)0, Amount = 200},
        };

        static List<Client> Clients = new List<Client>()
        {
            new Client { Name = "Client1", Address = "Address1", CNP = "SAALLZZJJ7779", AccountsList = BankAccounts },
            new Client { Name = "Client2", Address = "Address2", CNP = "SAALLZZJJ7778", AccountsList = BankAccounts2 },
        };

        static List<Bank> Banks = new List<Bank>()
        {
             new Bank { BankCode = "Bank1", ClientsList = Clients },
             new Bank { BankCode = "Bank2", ClientsList = Clients },
        };

        static void Main(string[] args)
        {
            TestedWithoutDataInsertion();
        }

        static void TestedWithoutDataInsertion()
        {
            _client = Clients[0];
            _bankAccount = BankAccounts2[1];

            Test_Add_New_Client();
            Test_Money_Transfer();
            Test_Money_Transfer_Without_Interest();
            Test_Display_Data();
        }

        static void Test_Money_Transfer()
        {
            var moneyToTransfer = 4500;
            Console.WriteLine(_bank.MoneyTransfer("Account1", "Account2", moneyToTransfer));
            Console.WriteLine();
        }

        static void Test_Money_Transfer_Without_Interest()
        {
            var moneyToTransfer = 499;
            Console.WriteLine(_bank.MoneyTransfer("Account1", "Account2", moneyToTransfer));
            Console.WriteLine();
        }

        static void Test_Add_New_Client()
        {
            _bank = Banks[0];

            var client3 = new Client { Name = "Client3", Address = "Address3", CNP = "SAALLZZJJ1111", AccountsList = BankAccounts };
            var client4 = new Client { Name = "Client4", Address = "Address4", CNP = "SAALLZZJJ2222", AccountsList = BankAccounts };
            var client5 = new Client { Name = "Client5", Address = "Address5", CNP = "SAALLZZJJ3333", AccountsList = BankAccounts };
            var client6 = new Client { Name = "Client6", Address = "Address6", CNP = "SAALLZZJJ4444", AccountsList = BankAccounts };

            Console.WriteLine(_bank.AddNewClient(client3));
            Console.WriteLine(_bank.AddNewClient(client4));
            Console.WriteLine(_bank.AddNewClient(client5));
            Console.WriteLine(_bank.AddNewClient(client5));
            Console.WriteLine(_bank.AddNewClient(client6));

            var client_info = _bank.DisplayClientInfo();
            Console.WriteLine(client_info);
            Console.WriteLine();
        }

        static void Test_Add_New_Account()
        {
            _bank = Banks[0];

            var client3 = new Client { Name = "Client3", Address = "Address3", CNP = "SAALLZZJJ5555", AccountsList = BankAccounts };
            var client4 = new Client { Name = "Client4", Address = "Address4", CNP = "SAALLZZJJ6666", AccountsList = BankAccounts };
            var client5 = new Client { Name = "Client5", Address = "Address5", CNP = "SAALLZZJJ7777", AccountsList = BankAccounts };
            var client6 = new Client { Name = "Client6", Address = "Address6", CNP = "SAALLZZJJ8888", AccountsList = BankAccounts };

            Console.WriteLine(_bank.AddNewClient(client3));
            Console.WriteLine(_bank.AddNewClient(client4));
            Console.WriteLine(_bank.AddNewClient(client5));
            Console.WriteLine(_bank.AddNewClient(client5));
            Console.WriteLine(_bank.AddNewClient(client6));

            var client_info = _bank.DisplayClientInfo();
            Console.WriteLine(client_info);
            Console.WriteLine();
        }

        static void Test_Display_Data()
        {
            var client_account_info2 = _bank.DisplayClientAccounts();
            Console.WriteLine(client_account_info2);
        }
    }
}
