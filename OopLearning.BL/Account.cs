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
                        throw new ArgumentException(nameof(accountNumber), validationResult.errorMessage);
                    }
                    if(value != accountNumber)
                    {
                        accountNumber = value;
                    }
                
            }
        }
        public string DepartmentNumber
        {
            get { return departmentNumber; }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateDepartmentNumber(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(departmentNumber), validationResult.errorMessage);
                }
                if(value != departmentNumber)
                {
                    departmentNumber = value;
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
        public static (bool, string) ValidateDepartmentNumber(string departmentNumber)
        {
            if(departmentNumber is null)
            {
                return (false, "DepartmentNumber er null");
            }
            if(departmentNumber.Length != 4)
            {
                return (false, "DepartmentNumber må kun være på 4 cifre!");
            }
            if(departmentNumber.Substring(0, 1) != "0")
            {
                return (false, "DepartmentNumber skal starte med et 0!");
            }
            else
            {
                return (true, String.Empty);
            }
        }
    }
}