using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using ProjectReunionTemplate.Core.Interfaces;
using ProjectReunionTemplate.Core.Services;
using ProjectReunionTemplate.Core.ViewModels;
using ProjectReunionTemplate.Desktop.Ioc;
using ProjectReunionTemplate.Desktop.Pages;
using ProjectReunionTemplate.Desktop.Services;

namespace ProjectReunionTemplate.Desktop
{
    public class Startup
    {
        private readonly ServiceCollection _services;

        public Startup()
        {
            _services = new ServiceCollection();
        }

        public ServiceProvider ConfigureServices()
        {
            // Services
            _services.AddSingleton<INavigationService, NavigationService>();
            _services.AddSingleton<ITextService>(_ => new TextService("Hi WPF .NET 5!"));

            // Views
            _services.AddSingleton<MainShell>();

            RegisterView<MainViewModel, MainPage>();
            RegisterView<HomeViewModel, HomePage>();
            RegisterView<SettingsViewModel, SettingsPage>();
            RegisterView<ViewAViewModel, ViewAPage>();
            RegisterView<ViewBViewModel, ViewBPage>();

            var provider = _services.BuildServiceProvider();

            ServiceLocator.Init(provider);

            return provider;
        }

        public void RegisterView<TViewModel, TView>() where TView : Page
        {
            _services.AddTransient(typeof(TViewModel));

            NavigationService.Register<TViewModel, TView>();
        }
    }
}
