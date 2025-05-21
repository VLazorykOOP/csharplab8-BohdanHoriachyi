using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsLab8
{
    public partial class Form3 : Form
    {
        private Button? btnProcess;
        private TextBox? txtOutput;

        public Form3()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            btnProcess = new Button();
            txtOutput = new TextBox();
            SuspendLayout();
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(20, 20);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(200, 30);
            btnProcess.TabIndex = 0;
            btnProcess.Text = "Обрати файл та обробити";
            btnProcess.Click += btnProcess_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(20, 60);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(500, 250);
            txtOutput.TabIndex = 1;
            // 
            // Form3
            // 
            ClientSize = new Size(550, 330);
            Controls.Add(btnProcess);
            Controls.Add(txtOutput);
            Name = "Form3";
            Text = "Форма 3 — Видалення повторів першої літери";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnProcess_Click(object? sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string inputText = File.ReadAllText(ofd.FileName);

            // Обробка кожного слова: видалення всіх входжень першої літери, крім першого
            string processedText = Regex.Replace(inputText, @"\b\w+\b", match =>
            {
                string word = match.Value;
                if (word.Length < 2) return word;

                char first = word[0];
                string rest = new string(word.Skip(1).Where(c => char.ToLower(c) != char.ToLower(first)).ToArray());
                return first + rest;
            });

            // Збереження результату
            string outputPath = Path.Combine(Application.StartupPath, "Form3_Output.txt");
            File.WriteAllText(outputPath, processedText);

            MessageBox.Show($"Оброблений текст збережено у: {outputPath}");

            if (txtOutput != null)
                txtOutput.Text = processedText;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
