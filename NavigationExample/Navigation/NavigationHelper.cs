using Android.App;

namespace NavigationExample.Navigation
{
    public class NavigationHelper
    {
        public Activity CurrentActivity { get; set; }

        public string ActivityKey { get; set; }

        public string NextPageKey { get; set; }

        public void GoBack()
        {
            if (CurrentActivity != null)
            {
                CurrentActivity.OnBackPressed();
            }
        }

        public void OnResume(Activity view)
        {
            CurrentActivity = view;

            if (string.IsNullOrEmpty(ActivityKey))
            {
                ActivityKey = NextPageKey;
                NextPageKey = null;
            }
        }
    }
}

