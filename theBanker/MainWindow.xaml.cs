/*
 * Author:        Matthew Steffan
 * Date Finished: 4/8/21
 * 
 */
using System;
using System.Windows;
using System.Windows.Controls;

namespace theBanker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creates display accounts
        CheckingAccount checkAcc1 = new CheckingAccount(accNum: 139876, fName: "Cassie", lName: "Brewer");
        CheckingAccount checkAcc2 = new CheckingAccount();
        SavingsAccount  savinAcc1 = new SavingsAccount(accNum: 777777, anIntRate: .1500m, fName: "Michael", lName: "Geary");
        SavingsAccount  savinAcc2 = new SavingsAccount(accNum: 134038, anIntRate: .0525m, fName: "Matthew", lName: "Steffan");

        // Array holding list of accounts
        private BankAccount[] accounts = new BankAccount[4];

        // Remembers which account is selected
        private int currentAccount = -1;

        public MainWindow()
        {
            InitializeComponent();

            // Initiallizes the accounts to have some money
            checkAcc1.makeDeposit(453.22m);
            savinAcc1.makeDeposit(79433.98m);
            savinAcc2.makeDeposit(5.01m);

            // Adds the accounts to an array for storage
            accounts[0] = checkAcc1;
            accounts[1] = checkAcc2;
            accounts[2] = savinAcc1;
            accounts[3] = savinAcc2;

            // Adds Accounts to the list box for display
            refreshAccountList();

            // Updates buttons and fields enabled status
            updateEnabledStatus();
        }

        #region Event Handlers
        // Method called when the account selected changes
        private void listOfAccountsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Sets the current account selected to the one the user chose
            currentAccount = listOfAccountsBox.SelectedIndex;

            // Updates buttons and fields enabled status
            updateEnabledStatus();

            // Resets all fields
            depositBox.Text         = string.Empty;
            withdrawalBox.Text      = string.Empty;
            interestBox.Content     = string.Empty;
            exceptionOutput.Content = string.Empty;
        }

        // Method called when deposit button is clicked
        private void depositButton_Click(object sender, RoutedEventArgs e)
        {
            // Ammount being withdrawn
            decimal ammount;

            try
            {
                // Refreshes error text
                exceptionOutput.Content = string.Empty;

                // Gets ammount in withdrawal text box and changes to int
                ammount = decimal.Parse(depositBox.Text);

                // If an account is selected, withdrawal
                if (currentAccount >= 0)
                {
                    // Withdrawals specified ammount from selected account
                    accounts[currentAccount].makeDeposit(ammount);

                    // Refreshes the account list
                    refreshAccountList();

                    // Resets input
                    depositBox.Text = string.Empty;
                }
            }

            // Catches if value is too large for a decimal
            catch(OverflowException)
            {
                exceptionOutput.Content = "Value too large";
            }

            // Catches the error if it can't parse to int
            catch (FormatException)
            {
                exceptionOutput.Content = "Not a valid deposit";
            }
            // Catches errors thrown from class
            catch (ArgumentException ex)
            {
                exceptionOutput.Content = ex.Message;
            }
        } 

        // Method called when withdrawal button is clicked
        private void withdrawalButton_Click(object sender, RoutedEventArgs e)
        { 
            // ammount being withdrawn
            decimal ammount;

            try
            {
                // Refreshes error text
                exceptionOutput.Content = string.Empty;

                // Gets ammount in withdrawal text box and changes to int
                ammount = decimal.Parse(withdrawalBox.Text);

                // If an account is selected, withdrawal
                if (currentAccount >= 0)
                {
                    // Withdrawals specified ammount from selected account
                    accounts[currentAccount].makeWithdrawal(ammount);

                    // Refreshes the account list
                    refreshAccountList();

                    // Resets input
                    withdrawalBox.Text = string.Empty;
                }
            }

            // Catches the error if it can't parse to int
            catch (FormatException)
            {
                exceptionOutput.Content = "Not a valid withdrawal";
            }
            // Catches errors thrown from class
            catch (ArgumentException ex)
            {
                exceptionOutput.Content = ex.Message;
            }
        }

        // Method called when calculate interest is clicked
        private void calculateInterestClick(object sender, RoutedEventArgs e)
        {
            // Only calculate if it is a Checking account
            if(currentAccount >= 0 && accounts[currentAccount].getAccountType == "Savings")
                interestBox.Content = String.Format("Monthly Interest: {0,0:C2}\n", 
                                                    accounts[currentAccount].CalculateInterest());
        }
        #endregion Event Handlers

        #region Methods
        // Refreshes the list view on the main page 
        private void refreshAccountList()
        {
            // Saves the last selected item before refreshing list
            int saveAccountSelected = currentAccount;

            // Removes old values from list
            listOfAccountsBox.Items.Clear();

            // Populates the list
            for (int i = 0; i < accounts.Length; i++)
            {
                listOfAccountsBox.Items.Add(accounts[i].ToString());
            }
            // Sets which one was selected last
            listOfAccountsBox.SelectedIndex = saveAccountSelected;
        }

        // Changes the status to make items unaccessable
        private void updateEnabledStatus()
        {
            // No item selected so disable buttons
            if (listOfAccountsBox.SelectedIndex < 0)               
            {
                // disable buttons
                depositButton.IsEnabled = false;
                withdrawalButton.IsEnabled = false;
                depositBox.IsEnabled = false;
                withdrawalBox.IsEnabled = false;
            }
            else
            {
                // Enables buttons
                depositButton.IsEnabled = true;
                withdrawalButton.IsEnabled = true;
                depositBox.IsEnabled = true;
                withdrawalBox.IsEnabled = true;
            }

            if (currentAccount >= 0 && accounts[currentAccount].getAccountType == "Savings")
                calculateInterestBtn.IsEnabled = true;
            else
                calculateInterestBtn.IsEnabled = false;
        }
        #endregion Methods
    }
}
