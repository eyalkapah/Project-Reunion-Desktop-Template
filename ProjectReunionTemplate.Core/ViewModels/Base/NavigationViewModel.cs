using System.Threading.Tasks;
using ProjectReunionTemplate.Core.Interfaces;

namespace ProjectReunionTemplate.Core.ViewModels.Base
{
    public class NavigationViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; }
        protected ILoggerService Logger { get; }

        public virtual Task OnNavigatedTo()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnNavigatedFrom()
        {
            return Task.CompletedTask;
        }

        // C'tor
        //
        public NavigationViewModel(INavigationService navigationService, ILoggerService loggerService)
        {
            NavigationService = navigationService;
            Logger = loggerService;
        }
    }
}
