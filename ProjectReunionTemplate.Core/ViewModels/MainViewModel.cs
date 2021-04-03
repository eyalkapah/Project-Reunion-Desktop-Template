using ProjectReunionTemplate.Core.Interfaces;
using ProjectReunionTemplate.Core.ViewModels.Base;

namespace ProjectReunionTemplate.Core.ViewModels
{
    public class MainViewModel : NavigationViewModel
    {
        private string _title = "Project Reunion for Desktop .NET 5!";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public void NavigateToSettingsPage()
        {
            NavigationService.NavigateTo<SettingsViewModel>();
        }

        public void NavigateToViewA()
        {
            NavigationService.NavigateTo<ViewAViewModel>();
        }

        public void NavigateToViewB()
        {
            NavigationService.NavigateTo<ViewBViewModel>();
        }

        public void NavigateToHomePage()
        {
            NavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
