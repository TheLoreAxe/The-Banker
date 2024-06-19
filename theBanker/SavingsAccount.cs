/*
 * Author:        Matthew Steffan
 * Date Finished: 4/8/21
 * 
 */
using System;

namespace theBanker
{
    class SavingsAccount : BankAccount
    {
        // Constant declaring what type of account
        public const string ACCOUNTTYPE = "Savings";

        // No args constructor which calls base class no args constructor
        public SavingsAccount() : base() { setAccountType = ACCOUNTTYPE; }

        // Constructor which calls base class constructor initializing everything to values given
        public SavingsAccount(int accNum, decimal anIntRate, string fName, string lName) :
        base(accNum, anIntRate, fName, lName, ACCOUNTTYPE){ }

        // Getter for the type of account
        public sealed override string getAccountType => this._accountType;

        // Overridden ToString returns a string displaying information in account
        public override string ToString()
        {
            return base.ToString() + String.Format("Account type:   {0,-10}\n" +
                                                   "Interest Rate:  {1,-10:P2}\n", 
                                                   getAccountType, interestRate);
        }
    }
}
