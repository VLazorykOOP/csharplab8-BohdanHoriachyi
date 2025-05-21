using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsLab8
{
    public class MenuForm : Form
    {
        public MenuForm()
        {
            Text = "Меню";
            Width = 300;
            Height = 200;
            StartPosition = FormStartPosition.CenterScreen;

            Button form1Btn = new Button { Text = "Відкрити Form1", Dock = DockStyle.Top, Height = 50 };
            Button form2Btn = new Button { Text = "Відкрити Form2", Dock = DockStyle.Top, Height = 50 };
            Button form3Btn = new Button { Text = "Відкрити Form3", Dock = DockStyle.Top, Height = 50 };
            Button form4Btn = new Button { Text = "Відкрити Form4", Dock = DockStyle.Top, Height = 50 };
            Button form5Btn = new Button { Text = "Відкрити Form5", Dock = DockStyle.Top, Height = 50 };
            Button exitBtn = new Button { Text = "Вихід", Dock = DockStyle.Bottom, Height = 40 };
            

            form1Btn.Click += (s, e) => { new Form1().Show(); this.Hide(); };
            form2Btn.Click += (s, e) => { new Form2().Show(); this.Hide(); };
            form3Btn.Click += (s, e) => { new Form3().Show(); this.Hide(); };
            form4Btn.Click += (s, e) => { new Form4().Show(); this.Hide(); };
            form5Btn.Click += (s, e) => { new Form5().Show(); this.Hide(); };
            exitBtn.Click += (s, e) => { Application.Exit(); };

            Controls.Add(form1Btn);
            Controls.Add(form2Btn);
            Controls.Add(form3Btn);
            Controls.Add(form4Btn);
            Controls.Add(form5Btn);
            Controls.Add(exitBtn);
        }
    }
}
