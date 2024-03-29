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
    public partial class DepositDialogForm : Form
    {
        int accountId;
        private readonly BankingSystemDBEntities context;
        public DepositDialogForm(int Id)
        {
            InitializeComponent();
            context = new BankingSystemDBEntities();

            accountId = Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int employeeId = context.Employees
                        .Where(employee => employee.Username == AuthenticatedUser.Username)
                        .Select(employee => employee.EmployeeID)
                        .FirstOrDefault();
            int amount = 0;
            try
            {
               amount = int.Parse(txtAmount.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid integer value.");
                return;
            }

            DateTime date = DateTime.Now;

            string type = "deposit";

            CreateTransaction(type, date, employeeId, accountId, amount);

        }

        public void CreateTransaction(string type, DateTime date, int employeeId,int accountId, decimal amount)
        {
            var accountIdParam = new SqlParameter("@AccountId", accountId);
            var amountParam = new SqlParameter("@Amount", amount);
            var typeParam = new SqlParameter("@Type", type);
            var employeeIdParam = new SqlParameter("@EmployeeId", employeeId);
            var dateParam = new SqlParameter("@Date", date);

            context.Database.ExecuteSqlCommand("EXEC CreateTransaction @Type, @Date, @EmployeeId, @AccountId, @Amount",typeParam, dateParam, employeeIdParam, accountIdParam, amountParam);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

     
    }
}
