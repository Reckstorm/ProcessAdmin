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
            ProcessesWithRules = new ListBox();
            Block_btn = new Button();
            Unblock_btn = new Button();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            TimeAllowed_nud = new NumericUpDown();
            MaxLifeTime_tb = new TextBox();
            label2 = new Label();
            LeftLifeTime_tb = new TextBox();
            label3 = new Label();
            ProcessName_lb = new Label();
            ProcessName_tb = new TextBox();
            Run_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)TimeAllowed_nud).BeginInit();
            SuspendLayout();
            // 
            // ExistingProcesses
            // 
            ExistingProcesses.FormattingEnabled = true;
            ExistingProcesses.ItemHeight = 15;
            ExistingProcesses.Location = new Point(12, 14);
            ExistingProcesses.Name = "ExistingProcesses";
            ExistingProcesses.Size = new Size(243, 424);
            ExistingProcesses.TabIndex = 0;
            // 
            // ProcessesWithRules
            // 
            ProcessesWithRules.FormattingEnabled = true;
            ProcessesWithRules.ItemHeight = 15;
            ProcessesWithRules.Location = new Point(432, 14);
            ProcessesWithRules.Name = "ProcessesWithRules";
            ProcessesWithRules.Size = new Size(243, 424);
            ProcessesWithRules.TabIndex = 1;
            ProcessesWithRules.SelectedIndexChanged += AllowedTimeSelectedChanged;
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
            Unblock_btn.Location = new Point(261, 338);
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
            // button2
            // 
            button2.Location = new Point(261, 288);
            button2.Name = "button2";
            button2.Size = new Size(165, 44);
            button2.TabIndex = 6;
            button2.Text = "Set allowed time";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SetAllowedTimeClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 109);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 7;
            label1.Text = "Set allowed time(min)";
            // 
            // TimeAllowed_nud
            // 
            TimeAllowed_nud.Location = new Point(261, 259);
            TimeAllowed_nud.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            TimeAllowed_nud.Name = "TimeAllowed_nud";
            TimeAllowed_nud.Size = new Size(120, 23);
            TimeAllowed_nud.TabIndex = 8;
            TimeAllowed_nud.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MaxLifeTime_tb
            // 
            MaxLifeTime_tb.Location = new Point(261, 186);
            MaxLifeTime_tb.Name = "MaxLifeTime_tb";
            MaxLifeTime_tb.ReadOnly = true;
            MaxLifeTime_tb.Size = new Size(100, 23);
            MaxLifeTime_tb.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(261, 168);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 10;
            label2.Text = "Max life time allowed:";
            // 
            // LeftLifeTime_tb
            // 
            LeftLifeTime_tb.Location = new Point(261, 230);
            LeftLifeTime_tb.Name = "LeftLifeTime_tb";
            LeftLifeTime_tb.ReadOnly = true;
            LeftLifeTime_tb.Size = new Size(100, 23);
            LeftLifeTime_tb.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(261, 212);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 12;
            label3.Text = "Life time left today:";
            // 
            // ProcessName_lb
            // 
            ProcessName_lb.AutoSize = true;
            ProcessName_lb.Location = new Point(261, 124);
            ProcessName_lb.Name = "ProcessName_lb";
            ProcessName_lb.Size = new Size(83, 15);
            ProcessName_lb.TabIndex = 14;
            ProcessName_lb.Text = "Process name:";
            // 
            // ProcessName_tb
            // 
            ProcessName_tb.Location = new Point(261, 142);
            ProcessName_tb.Name = "ProcessName_tb";
            ProcessName_tb.ReadOnly = true;
            ProcessName_tb.Size = new Size(100, 23);
            ProcessName_tb.TabIndex = 13;
            // 
            // Run_btn
            // 
            Run_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            Run_btn.Location = new Point(261, 394);
            Run_btn.Name = "Run_btn";
            Run_btn.Size = new Size(165, 44);
            Run_btn.TabIndex = 15;
            Run_btn.Text = "Run rules";
            Run_btn.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 450);
            Controls.Add(Run_btn);
            Controls.Add(ProcessName_lb);
            Controls.Add(ProcessName_tb);
            Controls.Add(label3);
            Controls.Add(LeftLifeTime_tb);
            Controls.Add(label2);
            Controls.Add(MaxLifeTime_tb);
            Controls.Add(TimeAllowed_nud);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Unblock_btn);
            Controls.Add(Block_btn);
            Controls.Add(ProcessesWithRules);
            Controls.Add(ExistingProcesses);
            Name = "Admin";
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)TimeAllowed_nud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ExistingProcesses;
        private ListBox ProcessesWithRules;
        private Button Block_btn;
        private Button Unblock_btn;
        private Button button1;
        private Button button2;
        private Label label1;
        private NumericUpDown TimeAllowed_nud;
        private TextBox MaxLifeTime_tb;
        private Label label2;
        private TextBox LeftLifeTime_tb;
        private Label label3;
        private Label ProcessName_lb;
        private TextBox ProcessName_tb;
        private Button Run_btn;
    }
}