using System;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class LoginForm : Form
    {
        public UserRole SelectedRole { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SelectedRole = (UserRole)comboBoxRole.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comboBoxRole.SelectedIndex = 0;
        }
    }
}