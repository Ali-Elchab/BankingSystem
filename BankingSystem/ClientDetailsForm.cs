using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class ClientDetailsForm : Form
    {
        private readonly BankingSystemDBEntities context;
        private NavigationStack navigationStack;
        int clientId;
        public ClientDetailsForm(int clientId)
        {
            InitializeComponent();
            navigationStack = new NavigationStack();
            context = new BankingSystemDBEntities();
            this.clientId = clientId;
            fillData();
        }

        public void fillData()
        {
            Client client = context.Clients.Find(clientId);

            accounts.DataSource = context.Accounts
                .Where(e => e.ClientID == clientId)
                .Select(e => new
                {
                    e.AccountID,
                    e.CurrentAmount
                })
                .ToList();

            txtClientId.ReadOnly = true;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtIdNumber.ReadOnly = true;

            txtClientId.Text = client.ClientID.ToString();
            txtFirstName.Text = client.FirstName;
            txtLastName.Text = client.LastName;
            txtIdNumber.Text = client.IdNumber;

            ContextMenuStrip deleteMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += DeleteMenuItem_Click;
            deleteMenuStrip.Items.Add(deleteMenuItem);
            accounts.ContextMenuStrip = deleteMenuStrip;
        }

        private void RefreshGridView()
        {
            accounts.DataSource = context.Accounts
                .Where(e => e.ClientID == clientId)
                .Select(e => new
                {
                    e.AccountID,
                    e.CurrentAmount
                })
                .ToList();
        }
        private void depositBtn_Click(object sender, EventArgs e)
        {
            if (accounts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = accounts.SelectedRows[0];
                int accountId = (int)selectedRow.Cells["AccountID"].Value;

                DepositDialogForm depositForm = new DepositDialogForm(accountId);
                depositForm.ShowDialog();
                if (depositForm.DialogResult == DialogResult.OK)
                {
                    RefreshGridView();
                }
            }
        }

        private void withdrawBtn_Click(object sender, EventArgs e)
        {
            if (accounts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = accounts.SelectedRows[0];
                int accountId = (int)selectedRow.Cells["AccountID"].Value;

                WithdrawDialogForm withdrawFrom = new WithdrawDialogForm(accountId);
                withdrawFrom.ShowDialog();
                if (withdrawFrom.DialogResult == DialogResult.OK)
                {
                    RefreshGridView();
                }
            }
        }

        private void addAccoutnBtn_Click(object sender, EventArgs e)
        {
            double initialAmount = 0;
            var clientIdParam = new SqlParameter("@ClientID", clientId);
            var intitialAmountParam = new SqlParameter("@InitialAmount", initialAmount);
            context.Database.ExecuteSqlCommand("EXEC CreateAccount @ClientID , @InitialAmount", clientIdParam, intitialAmountParam);
            RefreshGridView();
        }

        private void accounts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the row under the mouse pointer
                DataGridView.HitTestInfo hitTestInfo = accounts.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    accounts.Rows[hitTestInfo.RowIndex].Selected = true;

                    // Display the ContextMenuStrip at the clicked location
                    accounts.ContextMenuStrip.Show(accounts, e.Location);
                }
            }
        }
        

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (accounts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = accounts.SelectedRows[0];
                int accountId = (int)selectedRow.Cells["AccountID"].Value;

                DeleteAccount(accountId);
            }
        }

        private void DeleteAccount(int accountId)
        {
            try
            {
                var accountToDelete = context.Accounts.Find(accountId);
                if (accountToDelete != null)
                {
                    context.Accounts.Remove(accountToDelete);
                    context.SaveChanges();
                    RefreshGridView();
                }
                else
                {
                    MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = accounts.SelectedRows[0];
            int accountId = (int)selectedRow.Cells["AccountID"].Value;

            TransactionHistoryForm transactionsForm = new TransactionHistoryForm(accountId);
            navigationStack.Push(this); 
            transactionsForm.ShowDialog();
        }

    }
}
