using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace NavigationExample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        protected readonly INavigationService navigationService;

        private int parameter;

        private RelayCommand navigateChildCommand;

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
                Set(ref parameter, value);}
        }

        public RelayCommand NavigateChildCommand
        {
            get
            {
                return navigateChildCommand
                       ?? (navigateChildCommand = new RelayCommand(
                           () =>
                           {
                                navigationService.NavigateTo(ViewModelLocator.ChildPageKey,
                                                             new ChildNavigationParameter()
                                                             { Id = Parameter });
                           }));
            }
        }

        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}