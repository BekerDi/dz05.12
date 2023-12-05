using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace bank
{
    class BankAccount : IDisposable
    {
        private static int accountNumberCounter = 1000;

        public int AccountNumber { get; private set; }
        public string AccountHolder { get; set; }
        public string AccountType { get; }
        private decimal balance;
        private readonly Queue<BankTransaction> transactions;
        private bool disposed = false;

        public BankAccount()
        {
            GenerateAccountNumber();
            transactions = new Queue<BankTransaction>();
        }

        public BankAccount(string accountType) : this()
        {
            this.AccountType = accountType;
        }

        public BankAccount(decimal balance) : this()
        {
            this.balance = balance;
        }

        public BankAccount(string accountType, decimal balance) : this()
        {
            this.AccountType = accountType;
            this.balance = balance;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    SaveTransactionDataToFile("transactions.txt");
                }
                disposed = true;
            }
        }

        private void SaveTransactionDataToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"{transaction.Date},{transaction.Amount}");
                }
            }
        }

        private void GenerateAccountNumber()
        {
            AccountNumber = accountNumberCounter++;
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("Тип аккаунта: " + AccountType);
            Console.WriteLine("Баланс: " + balance);
            Console.WriteLine("Держатель банковского счета: " + AccountHolder);
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                var transaction = new BankTransaction(amount);
                transactions.Enqueue(transaction);
                Console.WriteLine("Успешно зачислено " + amount + " на счет");
                Console.WriteLine("Время операции: " + transaction.Date);
            }
            else
            {
                Console.WriteLine("Некорректная сумма");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    var transaction = new BankTransaction(-amount);
                    transactions.Enqueue(transaction);
                    Console.WriteLine("Успешно снято " + amount + " со счета");
                    Console.WriteLine("Время операции: " + transaction.Date);
                }
                else
                {
                    Console.WriteLine("Недостаточно средств на счете.");
                }
            }
            else
            {
                Console.WriteLine("Некорректная сумма");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            BankAccount otherAccount = (BankAccount)obj;
            return (AccountNumber == otherAccount.AccountNumber) && (AccountType == otherAccount.AccountType) && (balance == otherAccount.balance);
        }

        public override int GetHashCode()
        {
            return AccountNumber.GetHashCode() ^ AccountType.GetHashCode() ^ balance.GetHashCode();
        }

        public override string ToString()
        {
            return $"Номер счета: {AccountNumber}, Тип аккаунта: {AccountType}, Баланс: {balance}";
        }

        public static bool operator ==(BankAccount account1, BankAccount account2)
        {
            if (ReferenceEquals(account1, account2))
            {
                return true;
            }

            if (((object)account1 == null) || ((object)account2 == null))
            {
                return false;
            }

            return account1.Equals(account2);
        }

        public static bool operator !=(BankAccount account1, BankAccount account2)
        {
            return !(account1 == account2);
        }
        [Conditional("DEBUG_ACCOUNT")]
        public void DumpToScreen()
        {
            Console.WriteLine($"Номер аккаунта: {AccountNumber}");
            Console.WriteLine($"Владелец аккаунта: {AccountHolder}");
            Console.WriteLine($"Тип аккаунта: {AccountType}");
            Console.WriteLine($"Баланс: {balance}");

            Console.WriteLine("история операций:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"{transaction.Date} - {transaction.Amount}");
            }
        }
    }
}
