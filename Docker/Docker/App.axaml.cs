using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Docker.ViewModels;
using Docker.Views;

namespace Docker;

public class FluentThemeManager : IThemeManager
{
    private static readonly Uri BaseUri = new("avares://Docker/Styles");

    private static readonly FluentTheme Fluent = new()
    {
    };

    private static readonly Styles DockFluent = new()
    {
        new StyleInclude(BaseUri)
        {
            Source = new Uri("avares://Dock.Avalonia/Themes/DockFluentTheme.axaml")
        }
    };
    
    public void Initialize(Application application)
    {
        application.Styles.Insert(0, Fluent);
        application.Styles.Insert(1, DockFluent);
    }
}



public interface IThemeManager
{
    void Initialize(Application application);
}

public partial class App : Application
{
    public static IThemeManager? ThemeManager;
    public override void Initialize()
    {
        ThemeManager = new FluentThemeManager();
        ThemeManager.Initialize(this);
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            var mainWindowViewModel = new MainWindowViewModel();
            // DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel,
            };
            
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}