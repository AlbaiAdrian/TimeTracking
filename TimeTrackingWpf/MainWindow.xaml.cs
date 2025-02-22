using System.Text;
using System.Windows;
using System.Windows.Input;
using TimeTrackingWpf.ViewModels;

namespace TimeTracking;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private StringBuilder rfidBuffer = new StringBuilder();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            string scannedData = rfidBuffer.ToString();
            if (DataContext is MainWindowViewModel viewModel)
            {
                viewModel.ProcessRFID(scannedData);
            }
                
            // Process RFID Data
            rfidBuffer.Clear(); // Reset for the next scan

            e.Handled = true; // Stop further event propagation
        }
        else
        {
            // Append characters (only if not special keys)
            if (e.Key >= Key.D0 && e.Key <= Key.Z)
            {
                rfidBuffer.Append(e.Key.ToString().Replace("D", ""));
            }
        }
    }
}
