using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;

namespace PresentationApp.Views
{
    [Activity(Label = "PresentationApp", 
        MainLauncher = true, 
        Theme = "@style/Theme.MyTheme", 
        LaunchMode = LaunchMode.SingleTop,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        public const string FileName = "File Name";

        private BottomNavigationView bottomNavigation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.NavigationItemSelected += (sender, e) =>
            {
                LoadFragment(e.Item.ItemId);
            };
            LoadFragment(Resource.Id.menu_company);
        }

        private void LoadFragment(int id)
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_company:
                    fragment = new CompanyFragment();
                    break;
                case Resource.Id.menu_stories:
                    fragment = new StoriesFragment();
                    break;
                case Resource.Id.menu_contact:
                    fragment = new ContactFragment();
                    break;
            }

            if (fragment == null)
                return;

            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }
    }
}

