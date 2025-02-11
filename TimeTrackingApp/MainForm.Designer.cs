namespace TimeKeeping
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            usersToolStripMenuItem = new ToolStripMenuItem();
            UsersMenu = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            currentPicker = new DateTimePicker();
            groupBox2 = new GroupBox();
            entriesGrid = new DataGridView();
            FullName = new DataGridViewTextBoxColumn();
            Entry = new DataGridViewTextBoxColumn();
            Exit = new DataGridViewTextBoxColumn();
            WorkedTime = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)entriesGrid).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { usersToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(552, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { UsersMenu });
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(55, 20);
            usersToolStripMenuItem.Text = "Config";
            // 
            // UsersMenu
            // 
            UsersMenu.Name = "UsersMenu";
            UsersMenu.Size = new Size(102, 22);
            UsersMenu.Text = "Users";
            UsersMenu.Click += UsersMenu_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(currentPicker);
            groupBox1.Location = new Point(7, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(542, 46);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // currentPicker
            // 
            currentPicker.Location = new Point(6, 17);
            currentPicker.Name = "currentPicker";
            currentPicker.Size = new Size(239, 23);
            currentPicker.TabIndex = 0;
            currentPicker.ValueChanged += currentPicker_ValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(entriesGrid);
            groupBox2.Location = new Point(7, 79);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(542, 363);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Entries";
            // 
            // entriesGrid
            // 
            entriesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            entriesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            entriesGrid.Columns.AddRange(new DataGridViewColumn[] { FullName, Entry, Exit, WorkedTime });
            entriesGrid.Location = new Point(6, 18);
            entriesGrid.Name = "entriesGrid";
            entriesGrid.RowTemplate.Height = 25;
            entriesGrid.Size = new Size(527, 339);
            entriesGrid.TabIndex = 0;
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            FullName.DataPropertyName = "FullName";
            FullName.HeaderText = "Full Name";
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            FullName.Width = 86;
            // 
            // Entry
            // 
            Entry.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Entry.DataPropertyName = "Entry";
            Entry.HeaderText = "Entry";
            Entry.Name = "Entry";
            Entry.ReadOnly = true;
            Entry.Width = 59;
            // 
            // Exit
            // 
            Exit.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Exit.DataPropertyName = "Exit";
            Exit.HeaderText = "Exit";
            Exit.Name = "Exit";
            Exit.ReadOnly = true;
            Exit.Width = 51;
            // 
            // WorkedTime
            // 
            WorkedTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            WorkedTime.DataPropertyName = "WorkedTime";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            WorkedTime.DefaultCellStyle = dataGridViewCellStyle1;
            WorkedTime.HeaderText = "Worked Time";
            WorkedTime.Name = "WorkedTime";
            WorkedTime.ReadOnly = true;
            WorkedTime.Width = 102;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 445);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Time Keeping";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)entriesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem UsersMenu;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView entriesGrid;
        private DateTimePicker currentPicker;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Entry;
        private DataGridViewTextBoxColumn Exit;
        private DataGridViewTextBoxColumn WorkedTime;
    }
}