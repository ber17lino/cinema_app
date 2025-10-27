using System;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class DateRangeForm : Form
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public DateRangeForm()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Дата начала не может быть больше даты окончания!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StartDate = dtpStartDate.Value;
            EndDate = dtpEndDate.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}