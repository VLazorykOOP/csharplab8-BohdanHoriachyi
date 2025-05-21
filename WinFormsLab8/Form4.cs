using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsLab8
{
    public partial class Form4 : Form
    {
        private Button? btnCreateFile;
        private TextBox? txtOutput;

        public Form4()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnCreateFile = new Button();
            this.txtOutput = new TextBox();

            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new Point(20, 20);
            this.btnCreateFile.Size = new Size(250, 30);
            this.btnCreateFile.Text = "Створити файл з додатніми числами";
            this.btnCreateFile.Click += new EventHandler(this.btnCreateFile_Click);

            // 
            // txtOutput
            // 
            this.txtOutput.Location = new Point(20, 60);
            this.txtOutput.Size = new Size(400, 200);
            this.txtOutput.Multiline = true;
            this.txtOutput.ScrollBars = ScrollBars.Vertical;
            this.txtOutput.ReadOnly = true;

            // 
            // Form4
            // 
            this.ClientSize = new Size(450, 300);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form4";
            this.Text = "Форма 4 — Робота з двійковими файлами";
        }

        private void btnCreateFile_Click(object? sender, EventArgs e)
        {
            // Початкова послідовність чисел
            int[] numbers = { -5, 10, 0, 3, -2, 7, -9, 15 };

            string filePath = Path.Combine(Application.StartupPath, "positives.bin");

            // Запис тільки додатніх чисел у двійковий файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (int number in numbers)
                {
                    if (number > 0)
                        writer.Write(number);
                }
            }

            // Зчитування з файлу та відображення
            string result = "Додатні числа:\r\n";

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int value = reader.ReadInt32();
                    result += value + "\r\n";
                }
            }

            if (txtOutput != null)
                txtOutput.Text = result;

            MessageBox.Show($"Файл створено: {filePath}");
        }
    }
}
