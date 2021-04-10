using ProjectReunionTemplate.Core.Interfaces;
using ProjectReunionTemplate.Core.ViewModels.Base;

namespace ProjectReunionTemplate.Core.ViewModels
{
    public class HomeViewModel : NavigationViewModel
    {
        public HomeViewModel(INavigationService navigationService, ILoggerService loggerService) : base(navigationService, loggerService)
        {
        }
    }
}
