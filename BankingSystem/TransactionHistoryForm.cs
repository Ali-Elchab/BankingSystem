using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class TransactionHistoryForm : Form
    {
        private readonly BankingSystemDBEntities context;
        private NavigationStack navigationStack;
        private int accountId;
        public TransactionHistoryForm(int accountId)
        {
            InitializeComponent();
            context = new BankingSystemDBEntities();
            navigationStack = new NavigationStack();
            this.accountId = accountId;
            decimal TotalDeposits = CalculateTotalDeposit(accountId);
            totalDeposits.Text = TotalDeposits.ToString();
            decimal TtotalWithdrawals = GetTotalWithdrawals(accountId);
            totalWithdrawals.Text = TtotalWithdrawals.ToString();
            LoadDeposits();
            LoadWithdrawals();
        }
        public decimal CalculateTotalDeposit(int accountId)
        {
            var totalDeposits = context.Database.SqlQuery<decimal>(
                "SELECT dbo.CalculateTotalDeposit(@accountId) AS TotalDeposits",
                new SqlParameter("@accountId", accountId)
            ).Single();

            return totalDeposits;
        }

        public decimal GetTotalWithdrawals(int accountId)
        {
            var totalDeposits = context.Database.SqlQuery<decimal>(
                "SELECT dbo.CalculateTotalWithdrawal(@accountId) AS TotalDeposits",
                new SqlParameter("@accountId", accountId)
            ).Single();

            return totalDeposits;
        }
        private void LoadDeposits()
        {
            var deposits = context.Transactions
                .Where(t => t.Type == "deposit" && t.AccountId == accountId)
                .Select(t => new
                {
                    t.TransactionID,
                    t.Date,
                    t.EmployeeID,
                    t.Amount
                })
                .ToList();

            depositsList.DataSource = deposits;
        }

        private void LoadWithdrawals()
        {
            var withdrawals = context.Transactions
                .Where(t => t.Type == "withdrawal" && t.AccountId == accountId)
                .Select(t => new
                {
                    t.TransactionID,
                    t.Date,
                    t.EmployeeID,
                    t.Amount
                })
                .ToList();

            withdrawalsList.DataSource = withdrawals;
        }

    


    }
}
