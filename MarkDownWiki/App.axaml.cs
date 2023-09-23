using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MarkDownWiki.ViewModels;
using MarkDownWiki.Views;

namespace MarkDownWiki;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        //Themes.Change(Settings.Default.IsDarkMode, Color.FromUInt32(Settings.Default.PrimaryColor), );
        Themes.Change(isDarkMode: true, Themes.LookUp(Material.Colors.PrimaryColor.LightBlue), Themes.LookUp(Material.Colors.SecondaryColor.DeepPurple));

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
