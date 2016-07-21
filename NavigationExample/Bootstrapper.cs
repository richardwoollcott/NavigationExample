using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using NavigationExample.Navigation;
using NavigationExample.ViewModel;
using NavigationExample.Views;

namespace NavigationExample
{
    public static class Bootstrapper
    {
        private static ViewModelLocator locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (locator == null)
                {
                    DispatcherHelper.Initialize();

                    var nav = new AlternateNavigationService();
                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    //register the pages with the navigation service
                    nav.Configure(ViewModelLocator.MainPageKey, typeof(MainView));
                    nav.Configure(ViewModelLocator.ChildPageKey, typeof(ChildView));

                    SimpleIoc.Default.Register<IDialogService, AlternateDialogService>();

                    locator = new ViewModelLocator();
                }

                return locator;
            }
        }
    }
}

