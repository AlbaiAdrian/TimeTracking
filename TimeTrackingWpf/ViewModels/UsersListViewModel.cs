using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DIFactory;
using DTO.UserDTOs;
using Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TimeTrackingWpf.Users;

namespace TimeTrackingWpf.ViewModels;

public partial class UsersListViewModel : ObservableObject
{
    private readonly IUsersService _usersService;
    private readonly IFactory<UserForm> _userFormFactory;
    private readonly IFactory<UserFormViewModel> _userFormViewModelfactory;

    [ObservableProperty]
    private ObservableCollection<UserListDTO> users = new ObservableCollection<UserListDTO>();

    [ObservableProperty]
    private UserListDTO? selectedUser;

    // Initialize commands
    public RelayCommand UpdateUserCommand { get; }
    public RelayCommand DeleteUserCommand { get; }

    private bool CanModifyUser() => SelectedUser != null;

    public UsersListViewModel(IUsersService usersService, IFactory<UserForm> userFormFactory, IFactory<UserFormViewModel> userFormViewModelfactory, IMapper mapper)
    {
        _usersService = usersService;

        _userFormFactory = userFormFactory;
        _userFormViewModelfactory = userFormViewModelfactory;

        // Initialize commands
        UpdateUserCommand = new RelayCommand(UpdateUser, CanModifyUser);
        DeleteUserCommand = new RelayCommand(DeleteUser, CanModifyUser);

        LoadUsers();
    }

    [RelayCommand]
    private void AddUser()
    {
        var userFormViewModel = _userFormViewModelfactory.Create();
        var userForm = _userFormFactory.Create();
        userForm.DataContext = userFormViewModel;
        userForm.ShowDialog();
        if (userFormViewModel.IsCanceled)
        {
            return;
        }
        
        var userCreateDTO = new UserCreateDTO() {
            FirstName = userFormViewModel.FirstName,
            LastName = userFormViewModel.LastName,
            Identifier = userFormViewModel.Identifier
        };
        _usersService.CreateUser(userCreateDTO);
        LoadUsers();
    }

    private void UpdateUser()
    {
        var userFormViewModel = _userFormViewModelfactory.Create();
        userFormViewModel.FirstName = SelectedUser.FirstName;
        userFormViewModel.LastName = SelectedUser.LastName;
        userFormViewModel.Identifier = SelectedUser.Identifier;

        var userForm = _userFormFactory.Create();
        userForm.DataContext = userFormViewModel;
        userForm.ShowDialog();
        if (userFormViewModel.IsCanceled)
        {
            return;
        }

        UserUpdateDTO userUpdateDTO = new UserUpdateDTO()
        {
            Id = SelectedUser.Id,
            FirstName = userFormViewModel.FirstName,
            LastName = userFormViewModel.LastName,
            Identifier = userFormViewModel.Identifier
        };
        _usersService.UpdateUser(userUpdateDTO);
        LoadUsers();
    }

    private void DeleteUser()
    {
        var result = MessageBox.Show("Are you sure you want to delete the user!", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result != MessageBoxResult.Yes)
        {
            return;
        }

        _usersService.DeleteUser(SelectedUser.Id);
        LoadUsers();
    }

    [RelayCommand]
    private void CloseWindow(Window window)
    {
        window?.Close();
    }

    // Notify commands when SelectedUser changes
    partial void OnSelectedUserChanged(UserListDTO? value)
    {
        UpdateUserCommand.NotifyCanExecuteChanged();
        DeleteUserCommand.NotifyCanExecuteChanged();
    }

    private void LoadUsers()
    {
        Users.Clear();
        _usersService.GetAll().ToList().ForEach(u => Users.Add(u));
    }
}
