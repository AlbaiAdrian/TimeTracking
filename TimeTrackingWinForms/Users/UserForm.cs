using DTO.UserDTOs;

namespace TimeKeeping.Users;

public partial class UserForm : Form
{
    private UserDisplayDTO _userDisplayDTO = null;

    public UserForm()
    {
        InitializeComponent();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(firstNameTextBox.Text.Trim()))
        {
            MessageBox.Show("Please enter a value for first name!", "First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(lastNameTextBox.Text.Trim()))
        {
            MessageBox.Show("Please enter a value for last name!", "Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(identifierTextBox.Text.Trim()) || !int.TryParse(identifierTextBox.Text, out _))
        {
            MessageBox.Show("Please enter a numeric value for identifier!", "Identifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _userDisplayDTO = new UserDisplayDTO() { FirstName = firstNameTextBox.Text, LastName = lastNameTextBox.Text, Identifier = identifierTextBox.Text.Trim() };

        Close();
    }

    public UserDisplayDTO Open(UserDisplayDTO? userDisplayDTO)
    {
        if (userDisplayDTO != null)
        {
            firstNameTextBox.Text = userDisplayDTO.FirstName;
            lastNameTextBox.Text = userDisplayDTO.LastName;
            identifierTextBox.Text = userDisplayDTO.Identifier.ToString();
        }

        ShowDialog();

        return _userDisplayDTO;
    }

}
