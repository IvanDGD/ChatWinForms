namespace ChatClientWinForms
{
    partial class LoginForm
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
            label3 = new Label();
            emailLable = new Label();
            passwordTextBox = new TextBox();
            emailTextBox = new TextBox();
            label1 = new Label();
            loginButton = new Button();
            label2 = new Label();
            label4 = new Label();
            registerLinkLable = new LinkLabel();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(130, 63);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 9;
            label3.Text = "Port:";
            // 
            // emailLable
            // 
            emailLable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emailLable.AutoSize = true;
            emailLable.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            emailLable.ImageAlign = ContentAlignment.MiddleLeft;
            emailLable.Location = new Point(46, 132);
            emailLable.Name = "emailLable";
            emailLable.Size = new Size(58, 25);
            emailLable.TabIndex = 8;
            emailLable.Text = "Email";
            emailLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(46, 257);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(268, 27);
            passwordTextBox.TabIndex = 7;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(46, 160);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(268, 27);
            emailTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(110, 59);
            label1.Name = "label1";
            label1.Size = new Size(119, 41);
            label1.TabIndex = 10;
            label1.Text = "LeChat";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(74, 320);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(94, 29);
            loginButton.TabIndex = 12;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(46, 229);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 13;
            label2.Text = "Password";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(174, 324);
            label4.Name = "label4";
            label4.Size = new Size(23, 20);
            label4.TabIndex = 14;
            label4.Text = "or";
            // 
            // registerLinkLable
            // 
            registerLinkLable.AutoSize = true;
            registerLinkLable.Location = new Point(203, 324);
            registerLinkLable.Name = "registerLinkLable";
            registerLinkLable.Size = new Size(63, 20);
            registerLinkLable.TabIndex = 15;
            registerLinkLable.TabStop = true;
            registerLinkLable.Text = "Register";
            registerLinkLable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLinkLable_LinkClicked);
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 403);
            Controls.Add(registerLinkLable);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(loginButton);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(emailLable);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label emailLable;
        private TextBox passwordTextBox;
        private TextBox emailTextBox;
        private Label label1;
        private Button loginButton;
        private Label label2;
        private Label label4;
        private LinkLabel registerLinkLable;
    }
}
