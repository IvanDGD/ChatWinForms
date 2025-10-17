namespace CubeGame
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
            components = new System.ComponentModel.Container();
            UsernameTextBox = new TextBox();
            LoginButton = new Button();
            label1 = new Label();
            User1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            User2 = new Label();
            CountUser1 = new Label();
            CountUser2 = new Label();
            label3 = new Label();
            RollDiceButton = new Button();
            ModeBox = new ComboBox();
            SuspendLayout();
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(31, 153);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(125, 27);
            UsernameTextBox.TabIndex = 0;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(31, 186);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(125, 29);
            LoginButton.TabIndex = 1;
            LoginButton.Text = "LogIn";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 130);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 2;
            label1.Text = "Enter your user name";
            // 
            // User1
            // 
            User1.AutoSize = true;
            User1.Location = new Point(31, 20);
            User1.Name = "User1";
            User1.Size = new Size(46, 20);
            User1.TabIndex = 3;
            User1.Text = "User1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // User2
            // 
            User2.AutoSize = true;
            User2.Location = new Point(457, 20);
            User2.Name = "User2";
            User2.Size = new Size(46, 20);
            User2.TabIndex = 5;
            User2.Text = "User2";
            // 
            // CountUser1
            // 
            CountUser1.AutoSize = true;
            CountUser1.Location = new Point(262, 20);
            CountUser1.Name = "CountUser1";
            CountUser1.Size = new Size(17, 20);
            CountUser1.TabIndex = 6;
            CountUser1.Text = "0";
            // 
            // CountUser2
            // 
            CountUser2.AutoSize = true;
            CountUser2.Location = new Point(306, 20);
            CountUser2.Name = "CountUser2";
            CountUser2.Size = new Size(17, 20);
            CountUser2.TabIndex = 7;
            CountUser2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 20);
            label3.Name = "label3";
            label3.Size = new Size(15, 20);
            label3.TabIndex = 8;
            label3.Text = "-";
            // 
            // RollDiceButton
            // 
            RollDiceButton.Location = new Point(31, 98);
            RollDiceButton.Name = "RollDiceButton";
            RollDiceButton.Size = new Size(125, 29);
            RollDiceButton.TabIndex = 9;
            RollDiceButton.Text = "Roll the dice";
            RollDiceButton.UseVisualStyleBackColor = true;
            // 
            // ModeBox
            // 
            ModeBox.FormattingEnabled = true;
            ModeBox.Items.AddRange(new object[] { "Computer", "User" });
            ModeBox.Location = new Point(181, 98);
            ModeBox.Name = "ModeBox";
            ModeBox.Size = new Size(151, 28);
            ModeBox.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 248);
            Controls.Add(ModeBox);
            Controls.Add(RollDiceButton);
            Controls.Add(label3);
            Controls.Add(CountUser2);
            Controls.Add(CountUser1);
            Controls.Add(User2);
            Controls.Add(User1);
            Controls.Add(label1);
            Controls.Add(LoginButton);
            Controls.Add(UsernameTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTextBox;
        private Button LoginButton;
        private Label label1;
        private Label User1;
        private ContextMenuStrip contextMenuStrip1;
        private Label User2;
        private Label CountUser1;
        private Label CountUser2;
        private Label label3;
        private Button RollDiceButton;
        private ComboBox ModeBox;
    }
}
