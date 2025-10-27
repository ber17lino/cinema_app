namespace Cinema_APP
{
    partial class SessionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMovie = new System.Windows.Forms.Label();
            this.cmbMovie = new System.Windows.Forms.ComboBox();
            this.lblHall = new System.Windows.Forms.Label();
            this.cmbHall = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Location = new System.Drawing.Point(25, 25);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(49, 16);
            this.lblMovie.TabIndex = 0;
            this.lblMovie.Text = "Фильм:";
            // 
            // cmbMovie
            // 
            this.cmbMovie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovie.FormattingEnabled = true;
            this.cmbMovie.Location = new System.Drawing.Point(28, 50);
            this.cmbMovie.Name = "cmbMovie";
            this.cmbMovie.Size = new System.Drawing.Size(444, 24);
            this.cmbMovie.TabIndex = 1;
            this.cmbMovie.SelectedIndexChanged += new System.EventHandler(this.cmbMovie_SelectedIndexChanged);
            // 
            // lblHall
            // 
            this.lblHall.AutoSize = true;
            this.lblHall.Location = new System.Drawing.Point(25, 90);
            this.lblHall.Name = "lblHall";
            this.lblHall.Size = new System.Drawing.Size(35, 16);
            this.lblHall.TabIndex = 2;
            this.lblHall.Text = "Зал:";
            // 
            // cmbHall
            // 
            this.cmbHall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHall.FormattingEnabled = true;
            this.cmbHall.Location = new System.Drawing.Point(28, 115);
            this.cmbHall.Name = "cmbHall";
            this.cmbHall.Size = new System.Drawing.Size(444, 24);
            this.cmbHall.TabIndex = 2;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(25, 155);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(95, 16);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Дата сеанса:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(28, 180);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 22);
            this.dtpStartDate.TabIndex = 3;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(200, 155);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(99, 16);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "Время сеанса:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(203, 180);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(120, 22);
            this.dtpStartTime.TabIndex = 4;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEndTime.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblEndTime.Location = new System.Drawing.Point(25, 220);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(95, 18);
            this.lblEndTime.TabIndex = 10;
            this.lblEndTime.Text = "Окончание:";
            // 
            // btnSave
            // 
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
            // 
            // btnCancel
            // 
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
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 270);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(500, 65);
            this.panelButtons.TabIndex = 11;
            // 
            // SessionForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 335);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cmbHall);
            this.Controls.Add(this.lblHall);
            this.Controls.Add(this.cmbMovie);
            this.Controls.Add(this.lblMovie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionForm";
            this.Padding = new System.Windows.Forms.Padding(22, 20, 22, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление сеанса";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.ComboBox cmbMovie;
        private System.Windows.Forms.Label lblHall;
        private System.Windows.Forms.ComboBox cmbHall;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;
    }
}