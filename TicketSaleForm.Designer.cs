namespace Cinema_APP
{
    partial class TicketSaleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblSession = new System.Windows.Forms.Label();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.lblSeat = new System.Windows.Forms.Label();
            this.cmbSeat = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Location = new System.Drawing.Point(25, 25);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(63, 16);
            this.lblSession.TabIndex = 0;
            this.lblSession.Text = "Сеанс:";
            // 
            // cmbSession
            // 
            this.cmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(28, 50);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(444, 24);
            this.cmbSession.TabIndex = 1;
            this.cmbSession.SelectedIndexChanged += new System.EventHandler(this.cmbSession_SelectedIndexChanged);
            this.cmbSession.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSession_KeyDown);
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Location = new System.Drawing.Point(25, 90);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(52, 16);
            this.lblSeat.TabIndex = 2;
            this.lblSeat.Text = "Место:";
            // 
            // cmbSeat
            // 
            this.cmbSeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeat.Enabled = false;
            this.cmbSeat.FormattingEnabled = true;
            this.cmbSeat.Location = new System.Drawing.Point(28, 115);
            this.cmbSeat.Name = "cmbSeat";
            this.cmbSeat.Size = new System.Drawing.Size(444, 24);
            this.cmbSeat.TabIndex = 2;
            this.cmbSeat.SelectedIndexChanged += new System.EventHandler(this.cmbSeat_SelectedIndexChanged);
            this.cmbSeat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSeat_KeyDown);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.ForeColor = System.Drawing.Color.Green;
            this.lblPrice.Location = new System.Drawing.Point(25, 155);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(60, 18);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Цена: —";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(197, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Оформить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(313, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 205);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 65);
            this.panelButtons.TabIndex = 5;
            // 
            // TicketSaleForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbSeat);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.lblSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicketSaleForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оформление билета";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.ComboBox cmbSeat;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
    }
}