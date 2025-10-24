namespace Cinema_APP
{
    partial class MovieForm
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
            this.lblMovieName = new System.Windows.Forms.Label();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.lblAgeRestriction = new System.Windows.Forms.Label();
            this.cmbAgeRestriction = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // lblMovieName
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Location = new System.Drawing.Point(25, 25);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(116, 16);
            this.lblMovieName.TabIndex = 0;
            this.lblMovieName.Text = "Название фильма:";

            // txtMovieName
            this.txtMovieName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMovieName.Location = new System.Drawing.Point(28, 50);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(444, 22);
            this.txtMovieName.TabIndex = 1;

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(25, 90);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(88, 16);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Длительность:";

            // numDuration
            this.numDuration.Location = new System.Drawing.Point(28, 115);
            this.numDuration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(120, 22);
            this.numDuration.TabIndex = 2;
            this.numDuration.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(25, 155);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 16);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание:";

            // txtDescription
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(28, 180);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(444, 80);
            this.txtDescription.TabIndex = 3;

            // lblGenre
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(25, 280);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(46, 16);
            this.lblGenre.TabIndex = 6;
            this.lblGenre.Text = "Жанр:";

            // cmbGenre
            this.cmbGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(28, 305);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(444, 24);
            this.cmbGenre.TabIndex = 4;

            // lblAgeRestriction
            this.lblAgeRestriction.AutoSize = true;
            this.lblAgeRestriction.Location = new System.Drawing.Point(25, 345);
            this.lblAgeRestriction.Name = "lblAgeRestriction";
            this.lblAgeRestriction.Size = new System.Drawing.Size(159, 16);
            this.lblAgeRestriction.TabIndex = 8;
            this.lblAgeRestriction.Text = "Возрастное ограничение:";

            // cmbAgeRestriction
            this.cmbAgeRestriction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAgeRestriction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeRestriction.FormattingEnabled = true;
            this.cmbAgeRestriction.Location = new System.Drawing.Point(28, 370);
            this.cmbAgeRestriction.Name = "cmbAgeRestriction";
            this.cmbAgeRestriction.Size = new System.Drawing.Size(444, 24);
            this.cmbAgeRestriction.TabIndex = 5;

            // btnSave
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(262, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 6;
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
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // panelButtons
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 430);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 65);
            this.panelButtons.TabIndex = 10;

            // MovieForm
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 495);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.cmbAgeRestriction);
            this.Controls.Add(this.lblAgeRestriction);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtMovieName);
            this.Controls.Add(this.lblMovieName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovieForm";
            this.Padding = new System.Windows.Forms.Padding(22, 20, 22, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление фильма";
            this.Load += new System.EventHandler(this.MovieForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.Label lblAgeRestriction;
        private System.Windows.Forms.ComboBox cmbAgeRestriction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
    }
}