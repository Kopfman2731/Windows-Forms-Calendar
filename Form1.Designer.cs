namespace Calendar
{
    partial class Form1
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
            listBox1 = new ListBox();
            btEntry = new Button();
            label1 = new Label();
            btMenu = new Button();
            btSwitchView = new Button();
            btNext = new Button();
            btPrevious = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(3, 77);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(794, 499);
            listBox1.TabIndex = 0;
            // 
            // btEntry
            // 
            btEntry.Location = new Point(677, 22);
            btEntry.Name = "btEntry";
            btEntry.Size = new Size(111, 42);
            btEntry.TabIndex = 1;
            btEntry.Text = "New Entry";
            btEntry.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(271, 19);
            label1.Name = "label1";
            label1.Size = new Size(233, 45);
            label1.TabIndex = 2;
            label1.Text = "Week 0, Year 0";
            // 
            // btMenu
            // 
            btMenu.Location = new Point(12, 22);
            btMenu.Name = "btMenu";
            btMenu.Size = new Size(111, 42);
            btMenu.TabIndex = 3;
            btMenu.Text = "Menu";
            btMenu.UseVisualStyleBackColor = true;
            // 
            // btSwitchView
            // 
            btSwitchView.Location = new Point(12, 586);
            btSwitchView.Name = "btSwitchView";
            btSwitchView.Size = new Size(111, 42);
            btSwitchView.TabIndex = 4;
            btSwitchView.Text = "Switch View";
            btSwitchView.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            btNext.Location = new Point(710, 586);
            btNext.Name = "btNext";
            btNext.Size = new Size(78, 42);
            btNext.TabIndex = 5;
            btNext.Text = ">";
            btNext.UseVisualStyleBackColor = true;
            // 
            // btPrevious
            // 
            btPrevious.Location = new Point(626, 586);
            btPrevious.Name = "btPrevious";
            btPrevious.Size = new Size(78, 42);
            btPrevious.TabIndex = 6;
            btPrevious.Text = "<";
            btPrevious.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 640);
            Controls.Add(btPrevious);
            Controls.Add(btNext);
            Controls.Add(btSwitchView);
            Controls.Add(btMenu);
            Controls.Add(label1);
            Controls.Add(btEntry);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button btEntry;
        private Label label1;
        private Button btMenu;
        private Button btSwitchView;
        private Button btNext;
        private Button btPrevious;
    }
}
