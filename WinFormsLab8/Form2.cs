using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsLab8
{
    public class Form2 : Form
    {
        private Button btnProcess;
        private Label lblStatus;

        public Form2()
        {
            Text = "Завдання 2 — Видалення слів на голосну";
            Width = 500;
            Height = 200;
            StartPosition = FormStartPosition.CenterScreen;

            btnProcess = new Button
            {
                Text = "Обрати файл і обробити",
                Dock = DockStyle.Top,
                Height = 50
            };

            lblStatus = new Label
            {
                Text = "",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            btnProcess.Click += ProcessFile;

            Controls.Add(lblStatus);
            Controls.Add(btnProcess);
        }

        private void ProcessFile(object? sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Текстові файли (*.txt)|*.txt"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string content = File.ReadAllText(ofd.FileName);

            
            string pattern = @"\b[АЕЄИІЇОУЮЯаеєиіїоуюя][а-яА-ЯіІїЇєЄґҐ']*\b";
            string result = Regex.Replace(content, pattern, "", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            string outputPath = Path.Combine(Application.StartupPath, "Form2_Output.txt");
            File.WriteAllText(outputPath, result);

            lblStatus.Text = $"Результат збережено в: {outputPath}";
            MessageBox.Show("Обробку завершено успішно!", "Готово");
        }
    }
}
