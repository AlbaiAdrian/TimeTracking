using AutoMapper;
using DTO.UserDTOs;
using Services;
using TimeKeeping.DI_Factory;

namespace TimeKeeping.Users;

public partial class UsersList : Form
{
    private readonly IUsersService _usersService;
    private readonly IFactory<UserForm> _userFormFactory;
    private readonly IMapper _mapper;

    public UsersList(IUsersService usersService, IFactory<UserForm> userFormFactory, IMapper mapper)
    {
        InitializeComponent();
        _usersService = usersService;
        _userFormFactory = userFormFactory;
        _mapper = mapper;
    }

    private void UsersList_Load(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        LoadUsers();
        Cursor.Current = Cursors.Default;
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void addNewButton_Click(object sender, EventArgs e)
    {

        UserForm userForm = _userFormFactory.Create();
        var userCreate = userForm.Open(null);
        if (null == userCreate)
        {
            return;
        }
        Cursor.Current = Cursors.WaitCursor;
        _usersService.CreateUser(_mapper.Map<UserCreateDTO>(userCreate));
        LoadUsers();
        Cursor.Current = Cursors.Default;
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        if (!IsSelectedUser())
        {
            MessageBox.Show("Please select a user!", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var isOkTodelete = MessageBox.Show("Are you sure you want to delete the user!", "User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (isOkTodelete != DialogResult.Yes)
        {
            return;
        }

        Cursor.Current = Cursors.WaitCursor;
        UserListDTO selectedUser = (UserListDTO)usersGrid.SelectedRows[0].DataBoundItem;
        _usersService.DeleteUser(selectedUser.Id);
        LoadUsers();
        Cursor.Current = Cursors.Default;
    }

    private void updateButton_Click(object sender, EventArgs e)
    {
        if (!IsSelectedUser())
        {
            MessageBox.Show("Please select a user!", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        UserForm userForm = _userFormFactory.Create();
        UserListDTO selectedUser = (UserListDTO)usersGrid.SelectedRows[0].DataBoundItem;
        var userDisplayDTO = userForm.Open(_mapper.Map<UserDisplayDTO>(selectedUser));
        if (null == userDisplayDTO)
        {
            return;
        }
        Cursor.Current = Cursors.WaitCursor;
        UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(userDisplayDTO);
        userUpdateDTO.Id = selectedUser.Id;
        _usersService.UpdateUser(userUpdateDTO);
        LoadUsers();
        Cursor.Current = Cursors.Default;
    }

    private void LoadUsers()
    {
        usersGrid.DataSource = _usersService.GetAll();
    }

    private bool IsSelectedUser()
    {
        var selectedRows = usersGrid.SelectedRows;
        if (selectedRows.Count <= 0)
        {
            return false;
        }
        return true;
    }
}
