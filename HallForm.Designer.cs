namespace Cinema_APP
{
    partial class HallForm
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

        private void InitializeComponent()
        {
            this.lblHallName = new System.Windows.Forms.Label();
            this.txtHallName = new System.Windows.Forms.TextBox();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.numTotalRows = new System.Windows.Forms.NumericUpDown();
            this.lblSeatsPerRow = new System.Windows.Forms.Label();
            this.numSeatsPerRow = new System.Windows.Forms.NumericUpDown();
            this.lblScreenType = new System.Windows.Forms.Label();
            this.cmbScreenType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeatsPerRow)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // lblHallName
            this.lblHallName.AutoSize = true;
            this.lblHallName.Location = new System.Drawing.Point(25, 25);
            this.lblHallName.Name = "lblHallName";
            this.lblHallName.Size = new System.Drawing.Size(99, 16);
            this.lblHallName.TabIndex = 0;
            this.lblHallName.Text = "Название зала:";

            // txtHallName
            this.txtHallName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHallName.Location = new System.Drawing.Point(28, 50);
            this.txtHallName.Name = "txtHallName";
            this.txtHallName.Size = new System.Drawing.Size(444, 22);
            this.txtHallName.TabIndex = 1;

            // lblTotalRows
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Location = new System.Drawing.Point(25, 90);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(111, 16);
            this.lblTotalRows.TabIndex = 2;
            this.lblTotalRows.Text = "Количество рядов:";

            // numTotalRows
            this.numTotalRows.Location = new System.Drawing.Point(28, 115);
            this.numTotalRows.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTotalRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTotalRows.Name = "numTotalRows";
            this.numTotalRows.Size = new System.Drawing.Size(120, 22);
            this.numTotalRows.TabIndex = 2;
            this.numTotalRows.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});

            // lblSeatsPerRow
            this.lblSeatsPerRow.AutoSize = true;
            this.lblSeatsPerRow.Location = new System.Drawing.Point(25, 155);
            this.lblSeatsPerRow.Name = "lblSeatsPerRow";
            this.lblSeatsPerRow.Size = new System.Drawing.Size(96, 16);
            this.lblSeatsPerRow.TabIndex = 4;
            this.lblSeatsPerRow.Text = "Мест в ряду:";

            // numSeatsPerRow
            this.numSeatsPerRow.Location = new System.Drawing.Point(28, 180);
            this.numSeatsPerRow.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numSeatsPerRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSeatsPerRow.Name = "numSeatsPerRow";
            this.numSeatsPerRow.Size = new System.Drawing.Size(120, 22);
            this.numSeatsPerRow.TabIndex = 3;
            this.numSeatsPerRow.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});

            // lblScreenType
            this.lblScreenType.AutoSize = true;
            this.lblScreenType.Location = new System.Drawing.Point(25, 220);
            this.lblScreenType.Name = "lblScreenType";
            this.lblScreenType.Size = new System.Drawing.Size(81, 16);
            this.lblScreenType.TabIndex = 6;
            this.lblScreenType.Text = "Тип экрана:";

            // cmbScreenType
            this.cmbScreenType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbScreenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScreenType.FormattingEnabled = true;
            this.cmbScreenType.Location = new System.Drawing.Point(28, 245);
            this.cmbScreenType.Name = "cmbScreenType";
            this.cmbScreenType.Size = new System.Drawing.Size(444, 24);
            this.cmbScreenType.TabIndex = 4;

            // btnSave
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(262, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(378, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // panelButtons
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 305);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 65);
            this.panelButtons.TabIndex = 8;

            // HallForm
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.cmbScreenType);
            this.Controls.Add(this.lblScreenType);
            this.Controls.Add(this.numSeatsPerRow);
            this.Controls.Add(this.lblSeatsPerRow);
            this.Controls.Add(this.numTotalRows);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.txtHallName);
            this.Controls.Add(this.lblHallName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HallForm";
            this.Padding = new System.Windows.Forms.Padding(22, 20, 22, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление зала";
            this.Load += new System.EventHandler(this.HallForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTotalRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeatsPerRow)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblHallName;
        private System.Windows.Forms.TextBox txtHallName;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.NumericUpDown numTotalRows;
        private System.Windows.Forms.Label lblSeatsPerRow;
        private System.Windows.Forms.NumericUpDown numSeatsPerRow;
        private System.Windows.Forms.Label lblScreenType;
        private System.Windows.Forms.ComboBox cmbScreenType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
    }
}