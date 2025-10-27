namespace Cinema_APP
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключитьсяКБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьСоединениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основныеТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.залыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сеансыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.билетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жанрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.возрастныеОграниченияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыЭкрановToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииМестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.горизонтальноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вертикальноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.закрытьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonФильмы = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonЗалы = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonСеансы = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonБилеты = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonМеста = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonОтчётWord = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonОтчётExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonОтчётPDF = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.таблицыToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.окноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьсяКБДToolStripMenuItem,
            this.закрытьСоединениеToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // подключитьсяКБДToolStripMenuItem
            // 
            this.подключитьсяКБДToolStripMenuItem.Name = "подключитьсяКБДToolStripMenuItem";
            this.подключитьсяКБДToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.подключитьсяКБДToolStripMenuItem.Text = "Подключиться к БД";
            this.подключитьсяКБДToolStripMenuItem.Click += new System.EventHandler(this.подключитьсяКБДToolStripMenuItem_Click);
            // 
            // закрытьСоединениеToolStripMenuItem
            // 
            this.закрытьСоединениеToolStripMenuItem.Name = "закрытьСоединениеToolStripMenuItem";
            this.закрытьСоединениеToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.закрытьСоединениеToolStripMenuItem.Text = "Закрыть соединение";
            this.закрытьСоединениеToolStripMenuItem.Click += new System.EventHandler(this.закрытьСоединениеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(234, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.основныеТаблицыToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // основныеТаблицыToolStripMenuItem
            // 
            this.основныеТаблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фильмыToolStripMenuItem,
            this.залыToolStripMenuItem,
            this.сеансыToolStripMenuItem,
            this.билетыToolStripMenuItem,
            this.местаToolStripMenuItem});
            this.основныеТаблицыToolStripMenuItem.Name = "основныеТаблицыToolStripMenuItem";
            this.основныеТаблицыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.основныеТаблицыToolStripMenuItem.Text = "Основные";
            // 
            // фильмыToolStripMenuItem
            // 
            this.фильмыToolStripMenuItem.Name = "фильмыToolStripMenuItem";
            this.фильмыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.фильмыToolStripMenuItem.Text = "Фильмы";
            this.фильмыToolStripMenuItem.Click += new System.EventHandler(this.фильмыToolStripMenuItem_Click);
            // 
            // залыToolStripMenuItem
            // 
            this.залыToolStripMenuItem.Name = "залыToolStripMenuItem";
            this.залыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.залыToolStripMenuItem.Text = "Залы";
            this.залыToolStripMenuItem.Click += new System.EventHandler(this.залыToolStripMenuItem_Click);
            // 
            // сеансыToolStripMenuItem
            // 
            this.сеансыToolStripMenuItem.Name = "сеансыToolStripMenuItem";
            this.сеансыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сеансыToolStripMenuItem.Text = "Сеансы";
            this.сеансыToolStripMenuItem.Click += new System.EventHandler(this.сеансыToolStripMenuItem_Click);
            // 
            // билетыToolStripMenuItem
            // 
            this.билетыToolStripMenuItem.Name = "билетыToolStripMenuItem";
            this.билетыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.билетыToolStripMenuItem.Text = "Билеты";
            this.билетыToolStripMenuItem.Click += new System.EventHandler(this.билетыToolStripMenuItem_Click);
            // 
            // местаToolStripMenuItem
            // 
            this.местаToolStripMenuItem.Name = "местаToolStripMenuItem";
            this.местаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.местаToolStripMenuItem.Text = "Места";
            this.местаToolStripMenuItem.Click += new System.EventHandler(this.местаToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.жанрыToolStripMenuItem,
            this.возрастныеОграниченияToolStripMenuItem,
            this.типыЭкрановToolStripMenuItem,
            this.категорииМестToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // жанрыToolStripMenuItem
            // 
            this.жанрыToolStripMenuItem.Name = "жанрыToolStripMenuItem";
            this.жанрыToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.жанрыToolStripMenuItem.Text = "Жанры";
            this.жанрыToolStripMenuItem.Click += new System.EventHandler(this.жанрыToolStripMenuItem_Click);
            // 
            // возрастныеОграниченияToolStripMenuItem
            // 
            this.возрастныеОграниченияToolStripMenuItem.Name = "возрастныеОграниченияToolStripMenuItem";
            this.возрастныеОграниченияToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.возрастныеОграниченияToolStripMenuItem.Text = "Возрастные ограничения";
            this.возрастныеОграниченияToolStripMenuItem.Click += new System.EventHandler(this.возрастныеОграниченияToolStripMenuItem_Click);
            // 
            // типыЭкрановToolStripMenuItem
            // 
            this.типыЭкрановToolStripMenuItem.Name = "типыЭкрановToolStripMenuItem";
            this.типыЭкрановToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.типыЭкрановToolStripMenuItem.Text = "Типы экранов";
            this.типыЭкрановToolStripMenuItem.Click += new System.EventHandler(this.типыЭкрановToolStripMenuItem_Click);
            // 
            // категорииМестToolStripMenuItem
            // 
            this.категорииМестToolStripMenuItem.Name = "категорииМестToolStripMenuItem";
            this.категорииМестToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.категорииМестToolStripMenuItem.Text = "Категории мест";
            this.категорииМестToolStripMenuItem.Click += new System.EventHandler(this.категорииМестToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вWordToolStripMenuItem,
            this.вExcelToolStripMenuItem,
            this.вPDFToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // вWordToolStripMenuItem
            // 
            this.вWordToolStripMenuItem.Name = "вWordToolStripMenuItem";
            this.вWordToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вWordToolStripMenuItem.Text = "В Word";
            this.вWordToolStripMenuItem.Click += new System.EventHandler(this.вWordToolStripMenuItem_Click);
            // 
            // вExcelToolStripMenuItem
            // 
            this.вExcelToolStripMenuItem.Name = "вExcelToolStripMenuItem";
            this.вExcelToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вExcelToolStripMenuItem.Text = "В Excel";
            this.вExcelToolStripMenuItem.Click += new System.EventHandler(this.вExcelToolStripMenuItem_Click);
            // 
            // вPDFToolStripMenuItem
            // 
            this.вPDFToolStripMenuItem.Name = "вPDFToolStripMenuItem";
            this.вPDFToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вPDFToolStripMenuItem.Text = "В PDF";
            this.вPDFToolStripMenuItem.Click += new System.EventHandler(this.вPDFToolStripMenuItem_Click);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem,
            this.горизонтальноToolStripMenuItem,
            this.вертикальноToolStripMenuItem,
            this.toolStripSeparator2,
            this.закрытьВсеToolStripMenuItem});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.окноToolStripMenuItem.Text = "Окно";
            // 
            // каскадомToolStripMenuItem
            // 
            this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.каскадомToolStripMenuItem.Text = "Каскадом";
            this.каскадомToolStripMenuItem.Click += new System.EventHandler(this.каскадомToolStripMenuItem_Click);
            // 
            // горизонтальноToolStripMenuItem
            // 
            this.горизонтальноToolStripMenuItem.Name = "горизонтальноToolStripMenuItem";
            this.горизонтальноToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.горизонтальноToolStripMenuItem.Text = "По горизонтали";
            this.горизонтальноToolStripMenuItem.Click += new System.EventHandler(this.горизонтальноToolStripMenuItem_Click);
            // 
            // вертикальноToolStripMenuItem
            // 
            this.вертикальноToolStripMenuItem.Name = "вертикальноToolStripMenuItem";
            this.вертикальноToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вертикальноToolStripMenuItem.Text = "По вертикали";
            this.вертикальноToolStripMenuItem.Click += new System.EventHandler(this.вертикальноToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // закрытьВсеToolStripMenuItem
            // 
            this.закрытьВсеToolStripMenuItem.Name = "закрытьВсеToolStripMenuItem";
            this.закрытьВсеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.закрытьВсеToolStripMenuItem.Text = "Закрыть все";
            this.закрытьВсеToolStripMenuItem.Click += new System.EventHandler(this.закрытьВсеToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonФильмы,
            this.toolStripButtonЗалы,
            this.toolStripButtonСеансы,
            this.toolStripButtonБилеты,
            this.toolStripButtonМеста,
            this.toolStripSeparator3,
            this.toolStripButtonОтчётWord,
            this.toolStripButtonОтчётExcel,
            this.toolStripButtonОтчётPDF});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1067, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonФильмы
            // 
            this.toolStripButtonФильмы.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonФильмы.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonФильмы.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonФильмы.Name = "toolStripButtonФильмы";
            this.toolStripButtonФильмы.Size = new System.Drawing.Size(65, 24);
            this.toolStripButtonФильмы.Text = "Фильмы";
            this.toolStripButtonФильмы.Click += new System.EventHandler(this.toolStripButtonФильмы_Click);
            // 
            // toolStripButtonЗалы
            // 
            this.toolStripButtonЗалы.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonЗалы.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonЗалы.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonЗалы.Name = "toolStripButtonЗалы";
            this.toolStripButtonЗалы.Size = new System.Drawing.Size(45, 24);
            this.toolStripButtonЗалы.Text = "Залы";
            this.toolStripButtonЗалы.Click += new System.EventHandler(this.toolStripButtonЗалы_Click);
            // 
            // toolStripButtonСеансы
            // 
            this.toolStripButtonСеансы.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonСеансы.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonСеансы.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonСеансы.Name = "toolStripButtonСеансы";
            this.toolStripButtonСеансы.Size = new System.Drawing.Size(63, 24);
            this.toolStripButtonСеансы.Text = "Сеансы";
            this.toolStripButtonСеансы.Click += new System.EventHandler(this.toolStripButtonСеансы_Click);
            // 
            // toolStripButtonБилеты
            // 
            this.toolStripButtonБилеты.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonБилеты.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonБилеты.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonБилеты.Name = "toolStripButtonБилеты";
            this.toolStripButtonБилеты.Size = new System.Drawing.Size(62, 24);
            this.toolStripButtonБилеты.Text = "Билеты";
            this.toolStripButtonБилеты.Click += new System.EventHandler(this.toolStripButtonБилеты_Click);
            // 
            // toolStripButtonМеста
            // 
            this.toolStripButtonМеста.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonМеста.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonМеста.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonМеста.Name = "toolStripButtonМеста";
            this.toolStripButtonМеста.Size = new System.Drawing.Size(55, 24);
            this.toolStripButtonМеста.Text = "Места";
            this.toolStripButtonМеста.Click += new System.EventHandler(this.toolStripButtonМеста_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonОтчётWord
            // 
            this.toolStripButtonОтчётWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonОтчётWord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonОтчётWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonОтчётWord.Name = "toolStripButtonОтчётWord";
            this.toolStripButtonОтчётWord.Size = new System.Drawing.Size(99, 24);
            this.toolStripButtonОтчётWord.Text = "Отчёт (Word)";
            this.toolStripButtonОтчётWord.Click += new System.EventHandler(this.toolStripButtonОтчётWord_Click);
            // 
            // toolStripButtonОтчётExcel
            // 
            this.toolStripButtonОтчётExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonОтчётExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonОтчётExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonОтчётExcel.Name = "toolStripButtonОтчётExcel";
            this.toolStripButtonОтчётExcel.Size = new System.Drawing.Size(97, 24);
            this.toolStripButtonОтчётExcel.Text = "Отчёт (Excel)";
            this.toolStripButtonОтчётExcel.Click += new System.EventHandler(this.toolStripButtonОтчётExcel_Click);
            // 
            // toolStripButtonОтчётPDF
            // 
            this.toolStripButtonОтчётPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonОтчётPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButtonОтчётPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonОтчётPDF.Name = "toolStripButtonОтчётPDF";
            this.toolStripButtonОтчётPDF.Size = new System.Drawing.Size(89, 24);
            this.toolStripButtonОтчётPDF.Text = "Отчёт (PDF)";
            this.toolStripButtonОтчётPDF.Click += new System.EventHandler(this.toolStripButtonОтчётPDF_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1067, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(139, 20);
            this.statusLabel.Text = "БД не подключена";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 558);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Кинотеатр: Управление";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяКБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьСоединениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основныеТаблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильмыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem залыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сеансыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem билетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem местаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жанрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem возрастныеОграниченияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыЭкрановToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииМестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem горизонтальноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вертикальноToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem закрытьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonФильмы;
        private System.Windows.Forms.ToolStripButton toolStripButtonЗалы;
        private System.Windows.Forms.ToolStripButton toolStripButtonСеансы;
        private System.Windows.Forms.ToolStripButton toolStripButtonБилеты;
        private System.Windows.Forms.ToolStripButton toolStripButtonМеста;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonОтчётWord;
        private System.Windows.Forms.ToolStripButton toolStripButtonОтчётExcel;
        private System.Windows.Forms.ToolStripButton toolStripButtonОтчётPDF;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}