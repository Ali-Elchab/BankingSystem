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
    public partial class AddClientForm : Form
    {
        private readonly BankingSystemDBEntities context;

        public AddClientForm()
        {
            InitializeComponent();
            context = new BankingSystemDBEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string first_name = firstName.Text.Trim();
            string last_name = lastName.Text.Trim();
            string fathers_name = fathersName.Text.Trim();
            string mothers_name = mothersName.Text.Trim();
            string place_of_birth = placeOfBirth.Text.Trim();
            string id_num = id.Text.Trim();
            DateTime date_of_birth = dob.Value;

            if (string.IsNullOrEmpty(first_name) ||
                string.IsNullOrEmpty(last_name) ||
                string.IsNullOrEmpty(fathers_name) ||
                string.IsNullOrEmpty(mothers_name) ||
                string.IsNullOrEmpty(place_of_birth) ||
                string.IsNullOrEmpty(id_num))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var fName = new SqlParameter("@FirstName", first_name);
                var lName = new SqlParameter("@LastName", last_name);
                var fathersNameParam = new SqlParameter("@FathersName", fathers_name);
                var mothersNameParam = new SqlParameter("@MothersName", mothers_name);
                var placeOfBirthParam = new SqlParameter("@PlaceOfBirth", place_of_birth);
                var idParam = new SqlParameter("@ID", id_num);
                var dobParam = new SqlParameter("@DOB", date_of_birth);

                context.Database.ExecuteSqlCommand("EXEC CreateClient @FirstName, @LastName, @FathersName, @MothersName, @PlaceOfBirth, @ID, @DOB",
                                                    fName, lName, fathersNameParam, mothersNameParam, placeOfBirthParam, idParam, dobParam);

                MessageBox.Show("Client created successfully.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
