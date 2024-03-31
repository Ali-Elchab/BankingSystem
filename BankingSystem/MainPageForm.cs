using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class MainPageForm : Form
    {
        private readonly BankingSystemDBEntities context;
        private NavigationStack navigationStack;

        public MainPageForm()
        {
            InitializeComponent();
            navigationStack = new NavigationStack();
            context = new BankingSystemDBEntities();
            dob.Value = new DateTime(1900, 1, 1);
            UpdateClientsList();
        }

        private void UpdateClientsList()
        {
            var allClients = context.Clients
                .Select(c => new
                {
                    c.ClientID,
                    c.FirstName,
                    c.LastName,
                    c.FatherName,
                    c.MotherName,
                    c.DOB,
                    c.PlaceOfBirth,
                    c.IdNumber
                }).ToList();

            clientsList.DataSource = allClients;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string quick = quickSearch.Text.Trim();
            string first_name = firstName.Text.Trim();
            string last_name = lastName.Text.Trim();
            string fathers_name = fathersName.Text.Trim();
            string mothers_name = mothersName.Text.Trim();
            string place_of_birth = placeOfBirth.Text.Trim();
            string id_num = id.Text.Trim();
            DateTime date_of_birth = dob.Value;

            var query = context.Clients.AsQueryable();

            if (!string.IsNullOrEmpty(quick))
            {
                query = query.Where(
                    c => c.IdNumber.StartsWith(quick) ||
                         c.FirstName.StartsWith(quick) ||
                         c.LastName.StartsWith(quick) ||
                         c.FatherName.StartsWith(quick) ||
                         c.MotherName.StartsWith(quick) ||
                         c.PlaceOfBirth.StartsWith(quick)
                );
            }
            else
            {
                query = query.Where(
                    c => (string.IsNullOrEmpty(id_num) || c.IdNumber == id_num) &&
                         (string.IsNullOrEmpty(mothers_name) || c.MotherName == mothers_name) &&
                         (string.IsNullOrEmpty(first_name) || c.FirstName == first_name) &&
                         (string.IsNullOrEmpty(last_name) || c.LastName == last_name) &&
                         (string.IsNullOrEmpty(fathers_name) || c.FatherName == fathers_name) &&
                         (string.IsNullOrEmpty(place_of_birth) || c.PlaceOfBirth == place_of_birth) &&
                        (date_of_birth.Date == new DateTime(1900, 1, 1) || DbFunctions.TruncateTime(c.DOB) == date_of_birth.Date)
                );
            }

            var searchResult = query.Select(c => new
            {
                c.ClientID,
                c.FirstName,
                c.LastName,
                c.FatherName,
                c.MotherName,
                c.DOB,
                c.PlaceOfBirth,
                c.IdNumber
            }).ToList();

            clientsList.DataSource = searchResult;
        }

        private void clientsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = clientsList.Rows[e.RowIndex];
                int clientId = (int)selectedRow.Cells["ClientID"].Value;
                ClientDetailsForm clientDetailsForm = new ClientDetailsForm(clientId);
                navigationStack.Push(clientDetailsForm);
                clientDetailsForm.ShowDialog();
            }
        }

        private void addClientBtn_Click(object sender, EventArgs e)
        {
            AddClientForm addClient = new AddClientForm();
            addClient.ShowDialog();
            UpdateClientsList();
        }
    }
}
