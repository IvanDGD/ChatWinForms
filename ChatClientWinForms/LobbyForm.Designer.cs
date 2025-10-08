namespace ChatClientWinForms
{
    partial class LobbyForm
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
            label1 = new Label();
            label = new Label();
            onlineTextBox = new TextBox();
            logoutButton = new Button();
            offlineTextBox = new TextBox();
            MessageTextBox = new TextBox();
            sendTextBox = new TextBox();
            clearButton = new Button();
            sendButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 23);
            label1.TabIndex = 0;
            label1.Text = "Online users";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label.ForeColor = Color.Red;
            label.Location = new Point(12, 286);
            label.Name = "label";
            label.Size = new Size(111, 23);
            label.TabIndex = 1;
            label.Text = "Offline users";
            // 
            // onlineTextBox
            // 
            onlineTextBox.Location = new Point(12, 35);
            onlineTextBox.Multiline = true;
            onlineTextBox.Name = "onlineTextBox";
            onlineTextBox.Size = new Size(163, 248);
            onlineTextBox.TabIndex = 2;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(12, 558);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(163, 29);
            logoutButton.TabIndex = 4;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            // 
            // offlineTextBox
            // 
            offlineTextBox.Location = new Point(12, 312);
            offlineTextBox.Multiline = true;
            offlineTextBox.Name = "offlineTextBox";
            offlineTextBox.Size = new Size(163, 240);
            offlineTextBox.TabIndex = 5;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(202, 35);
            MessageTextBox.Multiline = true;
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(693, 374);
            MessageTextBox.TabIndex = 6;
            // 
            // sendTextBox
            // 
            sendTextBox.Location = new Point(202, 438);
            sendTextBox.Multiline = true;
            sendTextBox.Name = "sendTextBox";
            sendTextBox.Size = new Size(693, 114);
            sendTextBox.TabIndex = 7;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(202, 558);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(144, 29);
            clearButton.TabIndex = 8;
            clearButton.Text = "Remove";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(749, 560);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(146, 29);
            sendButton.TabIndex = 9;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 599);
            Controls.Add(sendButton);
            Controls.Add(clearButton);
            Controls.Add(sendTextBox);
            Controls.Add(MessageTextBox);
            Controls.Add(offlineTextBox);
            Controls.Add(logoutButton);
            Controls.Add(onlineTextBox);
            Controls.Add(label);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
            sendButton.Click += sendButton_Click;
            logoutButton.Click += logoutButton_Click;
            clearButton.Click += clearButton_Click;


        }

        #endregion

        private Label label1;
        private Label label;
        private TextBox onlineTextBox;
        private Button logoutButton;
        private TextBox offlineTextBox;
        private TextBox MessageTextBox;
        private TextBox sendTextBox;
        private Button clearButton;
        private Button sendButton;
    }
}
