
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using NavigationExample.ViewModel;

namespace NavigationExample.Views
{
    [Activity(Label = "Child View")]
    public class ChildView : Activity, INavigationView
    {
        private readonly List<Binding> bindings = new List<Binding>();

        private readonly NavigationHelper navigationHelper = new NavigationHelper();

        public NavigationHelper Helper
        {
            get
            {
                return navigationHelper;
            }
        }

        private TextView parameterTextView;

        public TextView ParameterTextView
        {
            get
            {
                return parameterTextView ??
                  (parameterTextView = FindViewById<TextView>(
                   Resource.Id.navigationParameterTextView));
            }
        }

        protected override void OnResume()
        {
            Helper.OnResume(this);

            base.OnResume();
        }

        public AlternateNavigationService Nav
        {
            get
            {
                return (AlternateNavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        private ChildViewModel Vm
        {
            get
            {
                return Bootstrapper.Locator.Child;
            }
        }

        private Button navigateHomeButton;

        public Button NavigateHomeButton
        {
            get
            {
                return navigateHomeButton ??
                  (navigateHomeButton = FindViewById<Button>(
                   Resource.Id.navHomeButton));
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "child" layout resource
            SetContentView(Resource.Layout.Child);

            var param = Nav.GetAndRemoveParameter<ChildNavigationParameter>(Intent);
            if (param != null)
            {
                Vm.Parameter = param.Id;
            }

            NavigateHomeButton.SetCommand("Click", Vm.NavigateHomeCommand);

            //prevent agressive linker removing 'Click' event
            NavigateHomeButton.Click += (sender, e) => { };

            bindings.Add(this.SetBinding(
                () => Vm.Parameter,
                () => ParameterTextView.Text));
        }
    }
}

