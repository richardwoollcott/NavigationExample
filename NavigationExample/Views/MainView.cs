using Android.App;
using Android.Widget;
using Android.OS;
using System;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using NavigationExample.ViewModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;

namespace NavigationExample.Views
{
    [Activity(Label = "Home View", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainView : Activity, INavigationView
    {
        private readonly NavigationHelper navigationHelper = new NavigationHelper();

        public NavigationHelper Helper
        {
            get
            {
                return navigationHelper;
            }
        }

        protected override void OnResume()
        {
            Helper.OnResume(this);

            base.OnResume();
        }

        private readonly List<Binding> bindings = new List<Binding>();

        private MainViewModel Vm
        {
            get
            {
                return Bootstrapper.Locator.Main;
            }
        }

        private Button navigateChildButton;

        public Button NavigateChildButton
        {
            get
            {
                return navigateChildButton ??
                  (navigateChildButton = FindViewById<Button>(
                   Resource.Id.navChildButton));
            }
        }

        private EditText numberEditText;
        public EditText NumberEditText
        {
            get
            {
                return numberEditText ??
                  (numberEditText = FindViewById<EditText>(
                   Resource.Id.paramEditText));
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            NavigateChildButton.SetCommand("Click", Vm.NavigateChildCommand);

            //prevent agressive linker removing 'Click' event
            NavigateChildButton.Click += (sender, e) => { };

            bindings.Add(this.SetBinding(
                () => Vm.Parameter,
                () => NumberEditText.Text,
                BindingMode.TwoWay));
        }
    }
}


