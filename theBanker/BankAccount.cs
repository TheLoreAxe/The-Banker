/*
 * Author:        Matthew Steffan
 * Date Finished: 4/8/21
 * 
 */
using System;
using System.Text.RegularExpressions;

namespace theBanker
{
    public abstract class BankAccount
    {
        // Required length of account number
        public const int    ACCOUNTNUMBERLENGTH = 6;

        // Account type
        public const string ACCOUNTTYPE = "Bank Account";

        // Variables
        private   int     _accountNumber;
        protected string  _accountType;
        private   string  _firstName,
                          _lastName;
        private   decimal _interestRate,
                          _balance;

        #region Constructors
        // Constructors
        public BankAccount()
        {
            accountNumber = 123456;
            interestRate = .00m;
            firstName = "John";
            lastName = "Doe";
            _accountType = ACCOUNTTYPE;
            _balance = 0.0m;
        }

        // Checking account constructor
        public BankAccount(int accNum, string fName, string lName, string accType)
        {
            accountNumber = accNum;
            firstName = fName;
            lastName = lName;
            _accountType = accType;
            _balance = 0.0m;
        }

        // Savings account constructor (has interest)
        public BankAccount(int accNum, decimal anIntRate, string fName, string lName, string accType)
        {
            accountNumber = accNum;
            interestRate  = anIntRate;
            firstName     = fName;
            lastName      = lName;
            _accountType  = accType;
            _balance      = 0.0m;
        }
        #endregion Constructors

        #region Mutators
        // Gets the balance of the account
        public decimal balance     => _balance;

        // Gets the account type, should be overridden 
        public virtual string getAccountType => ACCOUNTTYPE;

        // Sets the account type
        public string setAccountType 
        {
            set => _accountType = value;
        }
        
        // Sets and gets the First name
        public string firstName
        {
            get => _firstName;
            set 
            {
                if (value == string.Empty)
                    throw new ArgumentException("Please enter a first name");
                if (!Regex.IsMatch(value, @"^[a-z A-Z]+$"))
                    throw new ArgumentException("First name cannot contain numbers or symbols.");
                else
                    _firstName = value;
            }
        }

        // Sets and gets the last name
        public string lastName
        {
            get => _lastName;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Please enter a last name");
                if (!Regex.IsMatch(value, @"^[a-z A-Z]+$"))
                    throw new ArgumentException("Last name cannot contain numbers or symbols.");
                else
                    _lastName = value;
            }
        }
        // Sets and gets the account Number
        public int accountNumber
        {
            get => _accountNumber;
            set
            {
                if (value.ToString().Length != ACCOUNTNUMBERLENGTH)
                    throw new ArgumentException("Account number must be six digets");
                else
                    _accountNumber = value;
            }
        }  

        // Sets and gets the interest rate
        public decimal interestRate 
        {
            get => _interestRate;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Interest rate cannot be negative");
                else
                    _interestRate = value;
            }
        } 

        #endregion Mutators
        
        #region Methods
        // Deposits specified ammount to account balance
        public void makeDeposit(decimal ammount) 
        {
            try
            {
                if (ammount <= 0)
                    throw new ArgumentException("Cannot deposit money that does not exist");
                _balance += ammount;
            }
            // Catches if value is too large for a decimal
            catch (OverflowException)
            {
                throw new ArgumentException("Bank account cannot hold any more money");
            }
        }

        // Withdrawals specified ammount from account balance
        public void makeWithdrawal(decimal ammount) 
        { 
            if(ammount > balance)
                throw new ArgumentException("Cannot withdrawal more money than available");
            if (ammount < 0)
                throw new ArgumentException("Cannot withdrawal negative values");
            _balance -= ammount; 
        }

        // Returns the ammount of interest
        public decimal CalculateInterest() => (this.balance * this.interestRate) / 12;
        
        // Overrides toString and returns a string telling info about account
        public override string ToString()
        { 
            return String.Format("Account Number: {0,-10}\n" +
                                 "First Name:     {1,-10}\n" +
                                 "Last Name:      {2,-10}\n" +
                                 "Balance:        {3,-10:C2}\n",
                                 accountNumber, firstName, 
                                 lastName, balance);
        }
        #endregion Methods
    }
}
