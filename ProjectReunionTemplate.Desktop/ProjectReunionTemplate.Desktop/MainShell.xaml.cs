using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ProjectReunionTemplate.Core.Interfaces;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjectReunionTemplate.Desktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainShell : Window
    {
        private readonly ITextService _textService;


        public MainShell(ITextService textService, INavigationService navigationService)
        {
            _textService = textService;

            this.InitializeComponent();

            var rootFrame = Content as Frame;

            navigationService.InitializeFrame(rootFrame);
        }

     
    }
}
