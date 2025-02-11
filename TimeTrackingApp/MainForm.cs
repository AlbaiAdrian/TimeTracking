using Entity;
using Repository;
using Services;
using TimeKeeping.DI_Factory;
using TimeKeeping.Users;

namespace TimeKeeping;

public partial class MainForm : Form
{
    private readonly IFactory<UsersList> _usersManagementFactory;
    private readonly IUsersService _usersService;
    private readonly ITimeEntryService _timeEntry;
    private string _scannedRFID = "";

    public MainForm(IFactory<UsersList> usersManagementFactory, IUsersService usersService, ITimeEntryService timeEntry)
    {
        InitializeComponent();
        _usersManagementFactory = usersManagementFactory;
        _usersService = usersService;
        _timeEntry = timeEntry;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        currentPicker.Value = DateTime.Now;
        entriesGrid.DataSource = _timeEntry.GetTimeEntries(currentPicker.Value);
        Cursor.Current = Cursors.Default;
    }

    private void UsersMenu_Click(object sender, EventArgs e)
    {
        UsersList usersManagement = _usersManagementFactory.Create();
        usersManagement.ShowDialog(this);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if ((keyData >= Keys.D0 && keyData <= Keys.D9) ||  // Numbers 0-9
                (keyData >= Keys.A && keyData <= Keys.Z))     // Letters A-Z
        {
            _scannedRFID += keyData.ToString().Replace("D", ""); // Remove 'D' from numeric keys
            return true;
        }

        // If Enter is detected, process the RFID tag
        if (keyData == Keys.Enter)
        {
            if (!string.IsNullOrEmpty(_scannedRFID))
            {
                ProcessRFID(_scannedRFID);
                _scannedRFID = ""; // Reset after processing
            }
            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ProcessRFID(string rfidTag)
    {
        var userId = _usersService.GetUserId(rfidTag);
        if (null == userId)
        {
            MessageBox.Show("Cannot find a user with assosciated RFID {rfidTag}");
            return;
        }
        Cursor.Current = Cursors.WaitCursor;
        _timeEntry.AddEntry((int)userId, DateTime.Now);
        currentPicker.Value = DateTime.Now;
        entriesGrid.DataSource = _timeEntry.GetTimeEntries(currentPicker.Value);
        Cursor.Current = Cursors.Default;
    }

    private void currentPicker_ValueChanged(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        entriesGrid.DataSource = _timeEntry.GetTimeEntries(currentPicker.Value);
        Cursor.Current = Cursors.Default;
    }
}