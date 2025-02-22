namespace TimeKeeping.Users
{
    partial class UsersList
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
            usersGrid = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Identifier = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            closeButton = new Button();
            deleteButton = new Button();
            updateButton = new Button();
            addNewButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersGrid).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(usersGrid);
            groupBox1.Location = new Point(6, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(578, 613);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Users";
            // 
            // usersGrid
            // 
            usersGrid.AllowUserToAddRows = false;
            usersGrid.AllowUserToDeleteRows = false;
            usersGrid.AllowUserToOrderColumns = true;
            usersGrid.AllowUserToResizeColumns = false;
            usersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersGrid.Columns.AddRange(new DataGridViewColumn[] { Id, FirstName, LastName, Identifier });
            usersGrid.Dock = DockStyle.Fill;
            usersGrid.Location = new Point(3, 19);
            usersGrid.MultiSelect = false;
            usersGrid.Name = "usersGrid";
            usersGrid.ReadOnly = true;
            usersGrid.RowTemplate.Height = 25;
            usersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersGrid.Size = new Size(572, 591);
            usersGrid.TabIndex = 0;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "First Name";
            FirstName.MaxInputLength = 100;
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            FirstName.Width = 200;
            // 
            // LastName
            // 
            LastName.DataPropertyName = "LastName";
            LastName.HeaderText = "Last Name";
            LastName.MaxInputLength = 100;
            LastName.Name = "LastName";
            LastName.ReadOnly = true;
            LastName.Width = 200;
            // 
            // Identifier
            // 
            Identifier.DataPropertyName = "Identifier";
            Identifier.HeaderText = "Identifier";
            Identifier.Name = "Identifier";
            Identifier.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(closeButton);
            groupBox2.Controls.Add(deleteButton);
            groupBox2.Controls.Add(updateButton);
            groupBox2.Controls.Add(addNewButton);
            groupBox2.Location = new Point(590, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(142, 615);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(11, 128);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(121, 29);
            closeButton.TabIndex = 3;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(11, 93);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(121, 29);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(11, 58);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(121, 29);
            updateButton.TabIndex = 1;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // addNewButton
            // 
            addNewButton.Location = new Point(11, 23);
            addNewButton.Name = "addNewButton";
            addNewButton.Size = new Size(121, 29);
            addNewButton.TabIndex = 0;
            addNewButton.Text = "Add New";
            addNewButton.UseVisualStyleBackColor = true;
            addNewButton.Click += addNewButton_Click;
            // 
            // UsersList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 628);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UsersList";
            Text = "UsersList";
            Load += UsersList_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)usersGrid).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView usersGrid;
        private Button addNewButton;
        private Button closeButton;
        private Button deleteButton;
        private Button updateButton;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Identifier;
    }
}