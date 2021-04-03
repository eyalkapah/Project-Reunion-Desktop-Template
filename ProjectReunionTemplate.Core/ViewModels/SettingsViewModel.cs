using ProjectReunionTemplate.Core.Interfaces;
using ProjectReunionTemplate.Core.ViewModels.Base;

namespace ProjectReunionTemplate.Core.ViewModels
{
    public class SettingsViewModel : NavigationViewModel
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Settings";
        }
    }
}
