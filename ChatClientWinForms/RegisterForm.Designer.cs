namespace ChatClientWinForms
{
    partial class RegisterForm
    {
        
        
        
        / <summary>
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
            loginLinkLabel = new LinkLabel();
            label4 = new Label();
            label2 = new Label();
            registerButton = new Button();
            label1 = new Label();
            label3 = new Label();
            emailLable = new Label();
            passwordTextBox = new TextBox();
            emailTextBox = new TextBox();
            label5 = new Label();
            userTextBox = new TextBox();
            SuspendLayout();
            // 
            // loginLinkLabel
            // 
            loginLinkLabel.AutoSize = true;
            loginLinkLabel.Location = new Point(201, 345);
            loginLinkLabel.Name = "loginLinkLabel";
            loginLinkLabel.Size = new Size(46, 20);
            loginLinkLabel.TabIndex = 24;
            loginLinkLabel.TabStop = true;
            loginLinkLabel.Text = "LogIn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(172, 345);
            label4.Name = "label4";
            label4.Size = new Size(23, 20);
            label4.TabIndex = 23;
            label4.Text = "or";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(44, 250);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 22;
            label2.Text = "Password";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(72, 341);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(94, 29);
            registerButton.TabIndex = 21;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(95, 27);
            label1.Name = "label1";
            label1.Size = new Size(119, 41);
            label1.TabIndex = 20;
            label1.Text = "LeChat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 84);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 19;
            // 
            // emailLable
            // 
            emailLable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emailLable.AutoSize = true;
            emailLable.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            emailLable.ImageAlign = ContentAlignment.MiddleLeft;
            emailLable.Location = new Point(44, 84);
            emailLable.Name = "emailLable";
            emailLable.Size = new Size(58, 25);
            emailLable.TabIndex = 18;
            emailLable.Text = "Email";
            emailLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(44, 278);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(268, 27);
            passwordTextBox.TabIndex = 17;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(44, 112);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(268, 27);
            emailTextBox.TabIndex = 16;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(44, 168);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 26;
            label5.Text = "User name";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(44, 196);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(268, 27);
            userTextBox.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 450);
            Controls.Add(label5);
            Controls.Add(userTextBox);
            Controls.Add(loginLinkLabel);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(registerButton);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(emailLable);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
            registerButton.Click += registerButton_Click;
            loginLinkLabel.LinkClicked += loginLinkLabel_LinkClicked;

        }

        #endregion

        private LinkLabel loginLinkLabel;
        private Label label4;
        private Label label2;
        private Button registerButton;
        private Label label1;
        private Label label3;
        private Label emailLable;
        private TextBox passwordTextBox;
        private TextBox emailTextBox;
        private Label label5;
        private TextBox userTextBox;
    }
}
