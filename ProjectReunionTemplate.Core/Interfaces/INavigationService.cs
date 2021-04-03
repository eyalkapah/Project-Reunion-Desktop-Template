using Microsoft.UI.Xaml.Controls;

namespace ProjectReunionTemplate.Core.Interfaces
{
    public interface INavigationService
    {
        void InitializeFrame(Frame rootFrame);

        void NavigateTo<NavigationViewModel>();

        void NavigateTo<NavigationViewModel>(object parameter);

        void RemoveFromBackStack();
        void InitializeInnerFrame(Frame innerFrame);
    }
}
