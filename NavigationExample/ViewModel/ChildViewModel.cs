using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace NavigationExample.ViewModel
{
    public class ChildViewModel : ViewModelBase
    {
        protected readonly INavigationService navigationService;

        private int parameter;

        private RelayCommand navigateHomeCommand;

        public INavigationService NavigationService
        {
            get { return navigationService; }
        }

        public int Parameter
        {
            get
            {
                return parameter;
            }
            set
            {
                Set(ref parameter, value);
            }
        }

        public RelayCommand NavigateHomeCommand
        {
            get
            {
                return navigateHomeCommand
                       ?? (navigateHomeCommand = new RelayCommand(
                           () =>
                           {
                            navigationService.NavigateTo(ViewModelLocator.MainPageKey);
                           }));
            }
        }

        public ChildViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}

