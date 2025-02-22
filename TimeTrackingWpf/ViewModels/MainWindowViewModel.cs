using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DTO.TimeEntryDTOs;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using TimeTracking.Users;
using DIFactory;

namespace TimeTrackingWpf.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly ITimeEntryService _timeEntryService;
    private readonly IUsersService _usersService;
    private readonly IFactory<UsersList> _usersListfactory;
    private readonly IFactory<UsersListViewModel> _usersListViewModelFactory;
    private readonly IReportGenerator _reportGenerator;

    [ObservableProperty]
    private ObservableCollection<TimeEntryDisplayDTO> entries = new ObservableCollection<TimeEntryDisplayDTO>();

    [ObservableProperty]
    private DateTime? selectedDate = DateTime.Today;

    public MainWindowViewModel(ITimeEntryService timeEntryService, IUsersService usersService,  IFactory<UsersList> usersListfactory, IFactory<UsersListViewModel> usersListViewModelFactory, IReportGenerator reportGenerator)
    {
        _timeEntryService = timeEntryService;
        _usersService = usersService;
        _usersListfactory = usersListfactory;
        _usersListViewModelFactory = usersListViewModelFactory;
        _reportGenerator = reportGenerator;
        
        ChangeCursor(Cursors.Wait);
        LoadEntries();
        ChangeCursor(Cursors.Arrow);
    }

    [RelayCommand]
    private void OpenUsers()
    {
        var usersList = _usersListfactory.Create();
        var usersListViewModel = _usersListViewModelFactory.Create();
        usersList.DataContext = usersListViewModel;
        usersList.Show();
    }

    [RelayCommand]
    private void GenerateTrackingReport() {
        ChangeCursor(Cursors.Wait);
        _reportGenerator.GenerateReport((DateTime)SelectedDate);
        ChangeCursor(Cursors.Arrow);
    }

    partial void OnSelectedDateChanged(DateTime? oldValue, DateTime? newValue)
    {
        ChangeCursor(Cursors.Wait);
        LoadEntries();
        ChangeCursor(Cursors.Arrow);
    }

    public void ProcessRFID(string rfidTag)
    {
        var userId = _usersService.GetUserId(rfidTag);
        if (null == userId)
        {
            MessageBox.Show("Cannot find a user with assosciated RFID {rfidTag}");
            return;
        }
        ChangeCursor(Cursors.Wait);
        _timeEntryService.AddEntry((int)userId, DateTime.Now);
        SelectedDate = DateTime.Now;
        LoadEntries();
        ChangeCursor(Cursors.Arrow);
    }

    private void LoadEntries()
    {
        Entries.Clear();
        _timeEntryService.GetTimeEntries((DateTime)SelectedDate).ToList().ForEach(ent => Entries.Add(ent));
    }

    private void ChangeCursor(Cursor cursor)
    {
        System.Windows.Application.Current.Dispatcher.Invoke(() =>
        {
            Mouse.OverrideCursor = cursor;
        });
    }
}
