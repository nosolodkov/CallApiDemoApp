using Apis.Sun;
using System.Windows;

namespace WpfApp;

/// <summary>
/// Interaction logic for SunInfoWindow.xaml
/// </summary>
public partial class SunInfoWindow : Window
{
    public SunInfoWindow()
    {
        InitializeComponent();
    }

    private async void LoadSunInfo(object sender, RoutedEventArgs e)
    {
        var sunInfo = await SunProcessor.LoadSunInfo();

        textBlockSunrise.Text = $"Sunrise is at {sunInfo.Sunrise.ToLocalTime()}";
        textBlockSunset.Text = $"Sunset is at {sunInfo.Sunset.ToLocalTime()}";
    }
}
