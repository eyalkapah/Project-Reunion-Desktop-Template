using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using ProjectReunionTemplate.Core.Interfaces;
using ProjectReunionTemplate.Core.ViewModels;
using ProjectReunionTemplate.Core.ViewModels.Base;
using ProjectReunionTemplate.Desktop.Ioc;

namespace ProjectReunionTemplate.Desktop.Services
{
    public class NavigationService : INavigationService
    {
        private static readonly ConcurrentDictionary<Type, Type> _viewModelToViewMap;
        private Frame _shellFrame;
        private Frame _innerFrame;

        public NavigationService()
        {
            
        }

        static NavigationService()
        {
            _viewModelToViewMap = new ConcurrentDictionary<Type, Type>();

        }
        public void InitializeFrame(Frame rootFrame)
        {
            _shellFrame = rootFrame;
            NavigateTo<MainViewModel>();
        }

        public async Task Navigate(Type viewModel, object parameter = null)
        {
            if (_shellFrame.DataContext is NavigationViewModel vm)
            {
                await vm.OnNavigatedFrom();
            }

            _shellFrame.Navigate(GetView(viewModel), parameter);

            vm = ServiceLocator.Instance.GetService(viewModel) as NavigationViewModel;

            if (vm != null)
            {
                await vm.OnNavigatedTo();
            }
        }

        public void NavigateTo<T>() 
        {
            InternalNavigateTo(typeof(T), null);
        }

        public void NavigateTo<T>(object parameter) 
        {
            InternalNavigateTo(typeof(T), parameter);
        }

        public void RemoveFromBackStack()
        {
            _shellFrame?.BackStack.Remove(_shellFrame.BackStack.Last());
        }

        public void InitializeInnerFrame(Frame innerFrame)
        {
            _innerFrame = innerFrame;
        }

        private void InternalNavigateTo(Type viewModelType, object parameter)
        {
            var pageType = GetView(viewModelType);

            var viewModel = ServiceLocator.Instance.GetService(viewModelType);

            if (_innerFrame != null)
            {
                _innerFrame.Navigate(pageType, parameter);

                

                _innerFrame.DataContext = viewModel;

                return;
            }

            _shellFrame.DataContext = viewModel;

            _shellFrame?.Navigate(pageType, parameter);

            var content = _shellFrame.Content;
            //if (content is ShellPage shellPage)
            //{
            //    var navigationView = (shellPage.Content as Panel).Children.OfType<NavigationView>().First();
            //    var navFrame = (navigationView.Content as Panel).Children.OfType<Frame>().First();
            //    _shellFrame = navFrame;

            //    // navigate to book flight viewmodel
            //    NavigateTo<BookFlightViewModel>();
            //}
        }

        private static Type GetPageTypeForViewModel(MemberInfo viewModelType)
        {
            var app = typeof(App);

            var viewName = $"{app.Namespace}.Pages.{viewModelType.Name.Replace("ViewModel", "Page")}";
            
            var viewModelAssemblyName = app.Assembly.FullName;

            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);

            var viewType = Type.GetType(viewAssemblyName);

            Debug.Assert(viewType != null, $"Couldn't resolve view {viewAssemblyName}");
            
            return viewType;
        }

        public static void Register<TViewModel, TView>() where TView : Page
        {
            _viewModelToViewMap.TryAdd(typeof(TViewModel), typeof(TView));

        }

        private static Type GetView(Type viewModel)
        {
            try
            {
                var view = _viewModelToViewMap[viewModel];
                return view;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("View not registered for the view model");
            }
        }
    }
}
