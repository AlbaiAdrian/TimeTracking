using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace TimeTrackingWpf.ViewModels;

public partial class UserFormViewModel : ObservableObject
{
    [ObservableProperty]
    private string? firstName;

    [ObservableProperty]
    private string? lastName;

    [ObservableProperty]
    private string? identifier;

    public bool IsCanceled { get; set; } = false;

    public UserFormViewModel() { }

    [RelayCommand]
    private void Save(Window window)
    {
        if (string.IsNullOrEmpty(FirstName))
        {
            MessageBox.Show("Please enter a value for first name!", "First Name", MessageBoxButton.OK);
            return;
        }

        if (string.IsNullOrEmpty(LastName))
        {
            MessageBox.Show("Please enter a value for last name!", "Last Name", MessageBoxButton.OK);
            return;
        }

        if (string.IsNullOrEmpty(Identifier) || !int.TryParse(Identifier, out _))
        {
            MessageBox.Show("Please enter a numeric value for identifier!", "Identifier", MessageBoxButton.OK);
            return;
        }

        window.Close();
    }

    [RelayCommand]
    private void Cancel(Window window)
    {
        IsCanceled = true;
        window.Close(); // Close without saving
    }
}