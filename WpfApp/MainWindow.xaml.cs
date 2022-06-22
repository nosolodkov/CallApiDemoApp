using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Apis.Xkcd;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int maxNumber = 0;
    private int curNumber = 0;

    public MainWindow()
    {
        InitializeComponent();

        btnNextImg.IsEnabled = false;
    }

    private async Task LoadImage(int imageNumber = 0)
    {
        var comic = await ComicProcessor.LoadComic(imageNumber);
        if (imageNumber == 0)
        {
            maxNumber = comic.Num;
        }

        curNumber = comic.Num;

        var uriSource = new Uri(comic.Img, UriKind.Absolute);
        comicImage.Source = new BitmapImage(uriSource);
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await LoadImage();
    }

    private async void LoadPrevImg(object sender, RoutedEventArgs e)
    {
        if (curNumber > 1)
        {
            curNumber--;
            btnNextImg.IsEnabled = true;

            await LoadImage(curNumber);
            if (curNumber == 1)
            {
                btnPrevImg.IsEnabled = false;
            }
        }
    }

    private async void LoadNextImg(object sender, RoutedEventArgs e)
    {
        if (curNumber < maxNumber)
        {
            curNumber++;
            btnNextImg.IsEnabled = true;

            await LoadImage(curNumber);
            if (curNumber == maxNumber)
            {
                btnNextImg.IsEnabled = false;
            }
        }
    }

    private async void LoadSunInfo(object sender, RoutedEventArgs e)
    {
        var sunInfoWnd = new SunInfoWindow
        {
            Owner = this
        };

        sunInfoWnd.Show();
    }
}
