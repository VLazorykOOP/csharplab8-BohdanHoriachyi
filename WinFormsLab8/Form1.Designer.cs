namespace WinFormsLab8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Button btnReplace;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            btnLoadFile = new Button();
            txtResults = new TextBox();
            lblCount = new Label();
            txtFind = new TextBox();
            txtReplace = new TextBox();
            btnReplace = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 10);
            label1.Name = "label1";
            label1.Size = new Size(166, 15);
            label1.TabIndex = 0;
            label1.Text = "Обробка .com-адрес у файлі";
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(20, 40);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(150, 30);
            btnLoadFile.TabIndex = 1;
            btnLoadFile.Text = "Завантажити файл";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // txtResults
            // 
            txtResults.Location = new Point(20, 80);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(500, 150);
            txtResults.TabIndex = 2;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(20, 240);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 15);
            lblCount.TabIndex = 3;
            // 
            // txtFind
            // 
            txtFind.Location = new Point(20, 270);
            txtFind.Name = "txtFind";
            txtFind.PlaceholderText = "Що знайти";
            txtFind.Size = new Size(200, 23);
            txtFind.TabIndex = 4;
            // 
            // txtReplace
            // 
            txtReplace.Location = new Point(230, 270);
            txtReplace.Name = "txtReplace";
            txtReplace.PlaceholderText = "На що замінити";
            txtReplace.Size = new Size(200, 23);
            txtReplace.TabIndex = 5;
            // 
            // btnReplace
            // 
            btnReplace.Location = new Point(440, 270);
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new Size(80, 23);
            btnReplace.TabIndex = 6;
            btnReplace.Text = "Замінити";
            btnReplace.UseVisualStyleBackColor = true;
            btnReplace.Click += btnReplace_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 320);
            Controls.Add(label1);
            Controls.Add(btnLoadFile);
            Controls.Add(txtResults);
            Controls.Add(lblCount);
            Controls.Add(txtFind);
            Controls.Add(txtReplace);
            Controls.Add(btnReplace);
            Name = "Form1";
            Text = "Lab 8 — Робота з текстом";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
