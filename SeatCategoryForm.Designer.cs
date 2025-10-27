namespace Cinema_APP
{
    partial class SeatCategoryForm
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
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblRowStart = new System.Windows.Forms.Label();
            this.numRowStart = new System.Windows.Forms.NumericUpDown();
            this.lblRowEnd = new System.Windows.Forms.Label();
            this.numRowEnd = new System.Windows.Forms.NumericUpDown();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.numBasePrice = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numRowStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // lblCategoryName
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(25, 25);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(139, 16);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Название категории:";

            // txtCategoryName
            this.txtCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryName.Location = new System.Drawing.Point(28, 50);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(444, 22);
            this.txtCategoryName.TabIndex = 1;
            this.txtCategoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryName_KeyDown);

            // lblRowStart
            this.lblRowStart.AutoSize = true;
            this.lblRowStart.Location = new System.Drawing.Point(25, 90);
            this.lblRowStart.Name = "lblRowStart";
            this.lblRowStart.Size = new System.Drawing.Size(99, 16);
            this.lblRowStart.TabIndex = 2;
            this.lblRowStart.Text = "Начальный ряд:";

            // numRowStart
            this.numRowStart.Location = new System.Drawing.Point(28, 115);
            this.numRowStart.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRowStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowStart.Name = "numRowStart";
            this.numRowStart.Size = new System.Drawing.Size(120, 22);
            this.numRowStart.TabIndex = 2;
            this.numRowStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowStart.ValueChanged += new System.EventHandler(this.numRowStart_ValueChanged);

            // lblRowEnd
            this.lblRowEnd.AutoSize = true;
            this.lblRowEnd.Location = new System.Drawing.Point(25, 155);
            this.lblRowEnd.Name = "lblRowEnd";
            this.lblRowEnd.Size = new System.Drawing.Size(90, 16);
            this.lblRowEnd.TabIndex = 4;
            this.lblRowEnd.Text = "Конечный ряд:";

            // numRowEnd
            this.numRowEnd.Location = new System.Drawing.Point(28, 180);
            this.numRowEnd.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRowEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRowEnd.Name = "numRowEnd";
            this.numRowEnd.Size = new System.Drawing.Size(120, 22);
            this.numRowEnd.TabIndex = 3;
            this.numRowEnd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRowEnd.ValueChanged += new System.EventHandler(this.numRowEnd_ValueChanged);

            // lblBasePrice
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Location = new System.Drawing.Point(25, 220);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(86, 16);
            this.lblBasePrice.TabIndex = 6;
            this.lblBasePrice.Text = "Базовая цена:";

            // numBasePrice
            this.numBasePrice.DecimalPlaces = 2;
            this.numBasePrice.Location = new System.Drawing.Point(28, 245);
            this.numBasePrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBasePrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBasePrice.Name = "numBasePrice";
            this.numBasePrice.Size = new System.Drawing.Size(120, 22);
            this.numBasePrice.TabIndex = 4;
            this.numBasePrice.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});

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

            // SeatCategoryForm
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.numBasePrice);
            this.Controls.Add(this.lblBasePrice);
            this.Controls.Add(this.numRowEnd);
            this.Controls.Add(this.lblRowEnd);
            this.Controls.Add(this.numRowStart);
            this.Controls.Add(this.lblRowStart);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.lblCategoryName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeatCategoryForm";
            this.Padding = new System.Windows.Forms.Padding(22, 20, 22, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление категории места";
            this.Load += new System.EventHandler(this.SeatCategoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRowStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblRowStart;
        private System.Windows.Forms.NumericUpDown numRowStart;
        private System.Windows.Forms.Label lblRowEnd;
        private System.Windows.Forms.NumericUpDown numRowEnd;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.NumericUpDown numBasePrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
    }
}