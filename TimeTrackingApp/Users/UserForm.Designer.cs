namespace TimeKeeping.Users
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            identifierTextBox = new TextBox();
            label3 = new Label();
            lastNameTextBox = new TextBox();
            label2 = new Label();
            firstNameTextBox = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            cancelButton = new Button();
            saveButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(identifierTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lastNameTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(firstNameTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(7, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 116);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "User";
            // 
            // identifierTextBox
            // 
            identifierTextBox.Location = new Point(93, 79);
            identifierTextBox.Name = "identifierTextBox";
            identifierTextBox.Size = new Size(191, 23);
            identifierTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 4;
            label3.Text = "Identifier";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(93, 50);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(191, 23);
            lastNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Last Name";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(93, 21);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(191, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cancelButton);
            groupBox2.Controls.Add(saveButton);
            groupBox2.Location = new Point(309, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(97, 116);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(8, 52);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(81, 25);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(8, 19);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(81, 25);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(411, 127);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox identifierTextBox;
        private Label label3;
        private TextBox lastNameTextBox;
        private Label label2;
        private TextBox firstNameTextBox;
        private GroupBox groupBox2;
        private Button cancelButton;
        private Button saveButton;
    }
}