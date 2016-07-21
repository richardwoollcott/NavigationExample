using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace NavigationExample.ViewModel
{
    public class ChildViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        private readonly IDialogService dialogService;

        private int parameter;

        private RelayCommand navigateHomeCommand;

        private RelayCommand showMessageCommand;

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

        public RelayCommand ShowMessageCommand
        {
            get
            {
                return showMessageCommand
                       ?? (showMessageCommand = new RelayCommand(
                           () =>
                           {
                                Task.Run(() => 
                                {
                                    AlternateDispatcherHelper.CheckBeginInvokeOnUI(() =>
                                           dialogService.ShowMessageBox("Test the Alternate Dialog Service works.",
                                                                        "Test AlternateDialogService"));    
                                });
                    
                           }));
            }
        }

        public ChildViewModel(INavigationService navigationService,
                              IDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
        }
    }
}

