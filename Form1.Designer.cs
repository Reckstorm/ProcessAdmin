namespace ProcessAdmin_19._08
{
    partial class Admin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExistingProcesses = new ListBox();
            BlockedProcesses = new ListBox();
            Block_btn = new Button();
            Unblock_btn = new Button();
            button1 = new Button();
            AllowedProcesses = new ListBox();
            button2 = new Button();
            label1 = new Label();
            TimeAllowed_nud = new NumericUpDown();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)TimeAllowed_nud).BeginInit();
            SuspendLayout();
            // 
            // ExistingProcesses
            // 
            ExistingProcesses.FormattingEnabled = true;
            ExistingProcesses.ItemHeight = 15;
            ExistingProcesses.Location = new Point(12, 12);
            ExistingProcesses.Name = "ExistingProcesses";
            ExistingProcesses.Size = new Size(243, 424);
            ExistingProcesses.TabIndex = 0;
            // 
            // BlockedProcesses
            // 
            BlockedProcesses.FormattingEnabled = true;
            BlockedProcesses.ItemHeight = 15;
            BlockedProcesses.Location = new Point(432, 14);
            BlockedProcesses.Name = "BlockedProcesses";
            BlockedProcesses.Size = new Size(243, 424);
            BlockedProcesses.TabIndex = 1;
            // 
            // Block_btn
            // 
            Block_btn.Location = new Point(261, 12);
            Block_btn.Name = "Block_btn";
            Block_btn.Size = new Size(165, 44);
            Block_btn.TabIndex = 2;
            Block_btn.Text = "Block process";
            Block_btn.UseVisualStyleBackColor = true;
            Block_btn.Click += BlockProcessClick;
            // 
            // Unblock_btn
            // 
            Unblock_btn.Location = new Point(261, 112);
            Unblock_btn.Name = "Unblock_btn";
            Unblock_btn.Size = new Size(165, 44);
            Unblock_btn.TabIndex = 3;
            Unblock_btn.Text = "Unblock process";
            Unblock_btn.UseVisualStyleBackColor = true;
            Unblock_btn.Click += UnblockProcessClick;
            // 
            // button1
            // 
            button1.Location = new Point(261, 62);
            button1.Name = "button1";
            button1.Size = new Size(165, 44);
            button1.TabIndex = 4;
            button1.Text = "Block process exe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BlockProcessExeClick;
            // 
            // AllowedProcesses
            // 
            AllowedProcesses.FormattingEnabled = true;
            AllowedProcesses.ItemHeight = 15;
            AllowedProcesses.Location = new Point(852, 12);
            AllowedProcesses.Name = "AllowedProcesses";
            AllowedProcesses.Size = new Size(243, 424);
            AllowedProcesses.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(681, 62);
            button2.Name = "button2";
            button2.Size = new Size(165, 44);
            button2.TabIndex = 6;
            button2.Text = "Set allowed time";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(681, 14);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 7;
            label1.Text = "Set allowed time(min)";
            // 
            // TimeAllowed_nud
            // 
            TimeAllowed_nud.Location = new Point(681, 33);
            TimeAllowed_nud.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            TimeAllowed_nud.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TimeAllowed_nud.Name = "TimeAllowed_nud";
            TimeAllowed_nud.Size = new Size(120, 23);
            TimeAllowed_nud.TabIndex = 8;
            TimeAllowed_nud.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(681, 133);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(681, 115);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 10;
            label2.Text = "Max life time allowed";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(681, 184);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(681, 166);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 12;
            label3.Text = "Life time left today";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 450);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(TimeAllowed_nud);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(AllowedProcesses);
            Controls.Add(button1);
            Controls.Add(Unblock_btn);
            Controls.Add(Block_btn);
            Controls.Add(BlockedProcesses);
            Controls.Add(ExistingProcesses);
            Name = "Admin";
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)TimeAllowed_nud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ExistingProcesses;
        private ListBox BlockedProcesses;
        private Button Block_btn;
        private Button Unblock_btn;
        private Button button1;
        private ListBox AllowedProcesses;
        private Button button2;
        private Label label1;
        private NumericUpDown TimeAllowed_nud;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
    }
}