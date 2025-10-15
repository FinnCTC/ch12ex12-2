using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private theCusomer customer;

        public theCusomer GetNewCustomer()
        {
            this.ShowDialog();
            return customer;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                customer = new()
                {
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text
                };
                this.Close();
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtEmail.Text, nameof(theCusomer.Email));
            errorMessage += Validator.IsPresent(txtEmail.Text, nameof(theCusomer.FirstName));
            errorMessage += Validator.IsPresent(txtEmail.Text, nameof(theCusomer.LastName));

            errorMessage += Validator.IsValidEmail(txtEmail.Text, "Email");

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
