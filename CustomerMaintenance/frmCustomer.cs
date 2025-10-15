namespace CustomerMaintenance
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private List<theCusomer> customers = null;

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            customers = CustomerDB.GetCustomers();
            FillCustomersBox();
        }

        private void FillCustomersBox()
        {
            lstCustomers.Items.Clear();
            foreach (theCusomer c in customers)
            {
                lstCustomers.Items.Add(c.GetDisplayText("\t"));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer newCustomer = new();
            theCusomer customer = newCustomer.GetNewCustomer();
            if (customer != null)
            {
                customers.Add(customer);
                CustomerDB.SaveCustomers(customers);
                FillCustomersBox();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstCustomers.SelectedIndex;
            if (i != -1)
            {
                theCusomer cusomer = customers[i];
                string message = "Are you sure you want to delete " + cusomer.FirstName + "?";
                DialogResult button =
                    MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    customers.Remove(cusomer);
                    CustomerDB.SaveCustomers(customers);
                    FillCustomersBox();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}