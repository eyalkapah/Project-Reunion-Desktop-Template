using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectReunionTemplate.Core.Interfaces;
using ProjectReunionTemplate.Core.ViewModels.Base;

namespace ProjectReunionTemplate.Core.ViewModels
{
    public class ViewBViewModel : NavigationViewModel
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewBViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "View B";
        }
    }
}
