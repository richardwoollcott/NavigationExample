using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace NavigationExample.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public const string MainPageKey = "MainPage";
        public const string ChildPageKey = "ChildPage";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ChildViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ChildViewModel Child
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChildViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}