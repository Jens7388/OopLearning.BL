using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL
{
    public class Account
    {
        private string accountNumber;
        private string departmentNumber;
        private decimal balance;
        public Account(string accountNumber, string departmentNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            DepartmentNumber = departmentNumber;
            Balance = balance;
        }
        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateAccountNumber(value);
                if(!validationResult.isValid)
                {
                    if(!validationResult.isValid)
                    {
                        throw new ArgumentException(nameof(accountNumber), validationResult.errorMessage);
                    }
                    if(value != accountNumber)
                    {
                        accountNumber = value;
                    }
                }
            }
        }
        public static (bool, string) ValidateAccountNumber(string accountNumber)
        {
            if(accountNumber is null)
            {
                return (false, "AccountNumber er null!");
            }
            if(accountNumber.Length != 10)
            {
                return (false, "AccountNumber må kun være på 10 cifre!");
            }
            else
            {
                return (true, String.Empty);
            }
        }
    }
}