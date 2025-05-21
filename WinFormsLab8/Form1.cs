using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsLab8
{
    public partial class Form1 : Form
    {
        private string currentText = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            currentText = File.ReadAllText(ofd.FileName);

            // Пошук .com-адрес
            string pattern = @"\b(?:https?://)?(?:www\.)?[\w\-]+\.(?:com)\b";
            MatchCollection matches = Regex.Matches(currentText, pattern);

            txtResults.Clear();
            foreach (Match match in matches)
            {
                txtResults.AppendText(match.Value + Environment.NewLine);
            }

            lblCount.Text = $"Знайдено: {matches.Count} адрес(и) з .com";

            // Збереження знайдених адрес у директорії запуску
            string outputPath = Path.Combine(Application.StartupPath, "output.txt");
            File.WriteAllLines(outputPath, matches.Select(m => m.Value));

            MessageBox.Show($"Адреси збережено в: {outputPath}");
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentText))
            {
                MessageBox.Show("Спочатку завантажте файл.");
                return;
            }

            string oldValue = txtFind.Text;
            string newValue = txtReplace.Text;

            if (string.IsNullOrEmpty(oldValue))
            {
                MessageBox.Show("Введіть значення для пошуку.");
                return;
            }

            string replaced = currentText.Replace(oldValue, newValue);
            string replacedPath = Path.Combine(Application.StartupPath, "ReplacedOutput.txt");
            File.WriteAllText(replacedPath, replaced);

            MessageBox.Show($"Заміна виконана. Збережено в: {replacedPath}");
        }
    }
}
