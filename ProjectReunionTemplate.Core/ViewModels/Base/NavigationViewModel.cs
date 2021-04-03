using System.Threading.Tasks;
using ProjectReunionTemplate.Core.Interfaces;

namespace ProjectReunionTemplate.Core.ViewModels.Base
{
    public class NavigationViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; }

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
        public NavigationViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
