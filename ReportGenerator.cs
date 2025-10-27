using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace Cinema_APP
{
    public static class ReportGenerator
    {
        public static void GenerateWordReport(string reportName, DataTable data, string[] columnsToInclude = null)
        {
            try
            {
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для формирования отчета.", "Пустой отчет",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Word Documents|*.doc",
                    FileName = $"{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.doc",
                    Title = "Сохранить отчет Word"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine($"ОТЧЕТ: {reportName}");
                        writer.WriteLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
                        writer.WriteLine("=".PadRight(80, '='));
                        writer.WriteLine();
                        foreach (DataRow row in data.Rows)
                        {
                            for (int i = 0; i < data.Columns.Count; i++)
                            {
                                if (columnsToInclude == null || Array.IndexOf(columnsToInclude, data.Columns[i].ColumnName) >= 0)
                                {
                                    var value = row[i] == DBNull.Value ? "не указано" : row[i].ToString();
                                    writer.WriteLine($"{data.Columns[i].ColumnName}: {value}");
                                }
                            }
                            writer.WriteLine("-".PadRight(40, '-'));
                        }
                        writer.WriteLine();
                        writer.WriteLine($"Всего записей: {data.Rows.Count}");
                    }
                    MessageBox.Show($"Отчет успешно сохранен:\n{saveFileDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации отчета Word: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Отчёт в Excel (CSV) (без изменений) ===
        public static void GenerateExcelReport(string reportName, DataTable data, string[] columnsToInclude = null)
        {
            try
            {
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для формирования отчета.", "Пустой отчет",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV Files|*.csv",
                    FileName = $"{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Сохранить отчет Excel"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        bool first = true;
                        for (int i = 0; i < data.Columns.Count; i++)
                        {
                            if (columnsToInclude == null || Array.IndexOf(columnsToInclude, data.Columns[i].ColumnName) >= 0)
                            {
                                if (!first) writer.Write(";");
                                writer.Write($"\"{data.Columns[i].ColumnName}\"");
                                first = false;
                            }
                        }
                        writer.WriteLine();

                        foreach (DataRow row in data.Rows)
                        {
                            first = true;
                            for (int i = 0; i < data.Columns.Count; i++)
                            {
                                if (columnsToInclude == null || Array.IndexOf(columnsToInclude, data.Columns[i].ColumnName) >= 0)
                                {
                                    if (!first) writer.Write(";");
                                    var value = row[i] == DBNull.Value ? "" : row[i].ToString();
                                    writer.Write($"\"{value}\"");
                                    first = false;
                                }
                            }
                            writer.WriteLine();
                        }
                        writer.WriteLine($";;;;\"Всего записей: {data.Rows.Count}\"");
                    }
                    MessageBox.Show($"Отчет успешно сохранен:\n{saveFileDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации отчета Excel: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === ОТЧЁТ В PDF С ИСПОЛЬЗОВАНИЕМ PdfSharpCore ===
        public static void GeneratePdfReport(string reportName, DataTable data, string[] columnsToInclude = null)
        {
            try
            {
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для формирования отчета.", "Пустой отчет",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    FileName = $"{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                    Title = "Сохранить отчет PDF"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                // Создаём документ
                PdfDocument document = new PdfDocument();
                document.Info.Title = reportName;

                // Добавляем страницу
                PdfPage page = document.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Шрифты - PdfSharpCore лучше работает со шрифтами
                XFont titleFont = new XFont("Arial", 12, XFontStyle.Bold);
                XFont headerFont = new XFont("Arial", 10, XFontStyle.Bold);
                XFont regularFont = new XFont("Arial", 9, XFontStyle.Regular);

                const double margin = 40;
                double y = 50;
                const double lineHeight = 18;
                const double columnWidth = 130;

                // Заголовок отчета
                gfx.DrawString($"ОТЧЁТ: {reportName}", titleFont, XBrushes.Black,
                    new XRect(margin, y, page.Width.Point - 2 * margin, lineHeight),
                    XStringFormats.TopLeft);
                y += lineHeight;

                // Дата формирования
                gfx.DrawString($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}", regularFont, XBrushes.Black,
                    new XRect(margin, y, page.Width.Point - 2 * margin, lineHeight),
                    XStringFormats.TopLeft);
                y += lineHeight * 1.5;

                // Заголовки столбцов
                double x = margin;
                foreach (DataColumn col in data.Columns)
                {
                    if (columnsToInclude == null || Array.IndexOf(columnsToInclude, col.ColumnName) >= 0)
                    {
                        gfx.DrawString(col.ColumnName, headerFont, XBrushes.DarkBlue,
                            new XRect(x, y, columnWidth, lineHeight),
                            XStringFormats.TopLeft);
                        x += columnWidth;
                    }
                }
                y += lineHeight;

                // Разделительная линия под заголовками
                gfx.DrawLine(XPens.Gray, margin, y, page.Width.Point - margin, y);
                y += 5;

                // Данные таблицы
                foreach (DataRow row in data.Rows)
                {
                    x = margin;

                    // Проверяем, помещается ли строка на текущей странице
                    if (y + lineHeight > page.Height.Point - margin)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        y = margin;
                    }

                    foreach (DataColumn col in data.Columns)
                    {
                        if (columnsToInclude == null || Array.IndexOf(columnsToInclude, col.ColumnName) >= 0)
                        {
                            string value = row[col] == DBNull.Value ? "—"
                                         : (row[col] as DateTime?)?.ToString("dd.MM.yyyy HH:mm")
                                           ?? row[col].ToString();

                            // Обрезаем длинный текст
                            if (value.Length > 20)
                                value = value.Substring(0, 17) + "...";

                            gfx.DrawString(value, regularFont, XBrushes.Black,
                                new XRect(x, y, columnWidth, lineHeight),
                                XStringFormats.TopLeft);
                            x += columnWidth;
                        }
                    }
                    y += lineHeight;

                    // Разделительная линия между строками
                    gfx.DrawLine(XPens.LightGray, margin, y, page.Width.Point - margin, y);
                    y += 2;
                }

                // Итоговая информация
                y += 10;
                gfx.DrawString($"Всего записей: {data.Rows.Count}", headerFont, XBrushes.Black,
                    new XRect(margin, y, page.Width.Point - 2 * margin, lineHeight),
                    XStringFormats.TopLeft);

                // Сохраняем документ
                document.Save(saveFileDialog.FileName);
                document.Dispose();

                MessageBox.Show($"Отчёт успешно сохранён:\n{saveFileDialog.FileName}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации PDF-отчёта:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}