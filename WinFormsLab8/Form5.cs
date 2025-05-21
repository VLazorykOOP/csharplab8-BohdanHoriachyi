using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsLab8
{
    public class Form5 : Form
    {
        private Button btnRun;
        private TextBox textBox1;

        public Form5()
        {
            btnRun = new Button
            {
                Text = "Виконати завдання",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 30)
            };
            btnRun.Click += btnRun_Click;

            textBox1 = new TextBox
            {
                Location = new System.Drawing.Point(20, 70),
                Size = new System.Drawing.Size(550, 300),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            this.Controls.Add(btnRun);
            this.Controls.Add(textBox1);
            this.Text = "Form5 – Створення файлів";
            this.ClientSize = new System.Drawing.Size(600, 400);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string surname = "Shevchenko";
            string basePath = @"D:\temp";
            string folder1 = Path.Combine(basePath, surname + "1");
            string folder2 = Path.Combine(basePath, surname + "2");
            string renamedFolder = Path.Combine(basePath, "ALL");

            if (Directory.Exists(folder1)) Directory.Delete(folder1, true);
            if (Directory.Exists(folder2)) Directory.Delete(folder2, true);
            if (Directory.Exists(renamedFolder)) Directory.Delete(renamedFolder, true);

            Directory.CreateDirectory(folder1);
            Directory.CreateDirectory(folder2);

            File.WriteAllText(Path.Combine(folder1, "t1.txt"),
                $"{surname} Степан Іванович, 2001 року народження, місце проживання м. Суми");

            File.WriteAllText(Path.Combine(folder1, "t2.txt"),
                "Комар Сергій Федорович, 2000 року народження, місце проживання м. Київ");

            string t1Text = File.ReadAllText(Path.Combine(folder1, "t1.txt"));
            string t2Text = File.ReadAllText(Path.Combine(folder1, "t2.txt"));
            File.WriteAllText(Path.Combine(folder2, "t3.txt"), t1Text + Environment.NewLine + t2Text);

            string output = "";
            foreach (var file in Directory.GetFiles(folder1))
            {
                FileInfo fi = new FileInfo(file);
                output += $"[F1] {fi.Name} - {fi.Length} байт - Створено: {fi.CreationTime}\r\n";
            }

            File.Move(Path.Combine(folder1, "t2.txt"), Path.Combine(folder2, "t2.txt"));
            File.Copy(Path.Combine(folder1, "t1.txt"), Path.Combine(folder2, "t1.txt"));

            Directory.Move(folder2, renamedFolder);
            Directory.Delete(folder1, true);

            output += "\r\n--- Папка ALL ---\r\n";
            foreach (var file in Directory.GetFiles(renamedFolder))
            {
                FileInfo fi = new FileInfo(file);
                output += $"{fi.Name} - {fi.Length} байт - Створено: {fi.CreationTime}\r\n";
            }

            textBox1.Text = output;
        }
    }
}
