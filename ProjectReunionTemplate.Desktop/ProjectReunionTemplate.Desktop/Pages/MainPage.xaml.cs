using Microsoft.UI.Xaml.Controls;
using ProjectReunionTemplate.Core.Interfaces;
using ProjectReunionTemplate.Core.ViewModels;
using ProjectReunionTemplate.Desktop.Ioc;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjectReunionTemplate.Desktop.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly INavigationService _navigationService;
        public MainViewModel ViewModel => DataContext as MainViewModel;

        // C'tor
        //
        public MainPage()
        {
            //_navigationService = navigationService;
            this.InitializeComponent();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ViewModel.NavigateToSettingsPage();
            }
            else
            {
                if (args.SelectedItem is not NavigationViewItem item) 
                    return;
                
                var tag = item.Tag?.ToString();

                if (tag == null)
                    return;

                if (!tag.ToLowerInvariant().Equals("homepage")) 
                    return;

                var navigationService = ServiceLocator.Instance.GetService<INavigationService>();

                navigationService.InitializeInnerFrame(ContentFrame);

                ViewModel.NavigateToHomePage();

                ContentFrame.BackStack.Clear();
                
                UpdateAppBackButton();

                return;
            }
        }

        private void UpdateAppBackButton()
        {
            MainNavigationView.IsBackEnabled = ContentFrame.CanGoBack;
        }
    }
}
