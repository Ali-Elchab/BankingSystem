using System;
using System.Linq;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class LoginForm : Form
    {
        BankingSystemDBEntities context;

        public LoginForm()
        {
            InitializeComponent();
            context = new BankingSystemDBEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;

            using (context)
            {
                var employee = context.Employees.FirstOrDefault(emp => emp.Username == username && emp.Password == password);
                if (employee != null)
                {
                    AuthenticatedUser.Username = username;

                    MainPageForm mainForm = new MainPageForm();
                    mainForm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

    }
}
public static class AuthenticatedUser
{
    public static string Username { get; set; }
}