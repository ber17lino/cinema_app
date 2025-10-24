namespace Cinema_APP
{
    partial class ScreenTypeForm
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
            this.lblTypeName = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.lblMarkup = new System.Windows.Forms.Label();
            this.numMarkup = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkup)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // lblTypeName
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(25, 25);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(110, 16);
            this.lblTypeName.TabIndex = 0;
            this.lblTypeName.Text = "Название типа:";

            // txtTypeName
            this.txtTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTypeName.Location = new System.Drawing.Point(28, 50);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(444, 22);
            this.txtTypeName.TabIndex = 1;

            // lblMarkup
            this.lblMarkup.AutoSize = true;
            this.lblMarkup.Location = new System.Drawing.Point(25, 90);
            this.lblMarkup.Name = "lblMarkup";
            this.lblMarkup.Size = new System.Drawing.Size(64, 16);
            this.lblMarkup.TabIndex = 2;
            this.lblMarkup.Text = "Наценка:";

            // numMarkup
            this.numMarkup.DecimalPlaces = 2;
            this.numMarkup.Location = new System.Drawing.Point(28, 115);
            this.numMarkup.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMarkup.Name = "numMarkup";
            this.numMarkup.Size = new System.Drawing.Size(120, 22);
            this.numMarkup.TabIndex = 2;
            this.numMarkup.Value = new decimal(new int[] {
            10,
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
            this.btnSave.TabIndex = 3;
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
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // panelButtons
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 175);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 65);
            this.panelButtons.TabIndex = 5;

            // ScreenTypeForm
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 240);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.numMarkup);
            this.Controls.Add(this.lblMarkup);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.lblTypeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenTypeForm";
            this.Padding = new System.Windows.Forms.Padding(22, 20, 22, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление типа экрана";
            this.Load += new System.EventHandler(this.ScreenTypeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMarkup)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label lblMarkup;
        private System.Windows.Forms.NumericUpDown numMarkup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
    }
}