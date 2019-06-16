using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using CheeseBind;
using Android.Content.PM;
using EduApp.Utility;

namespace EduApp
{
    [Activity(Theme = "@style/MainTheme.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        [BindView(Resource.Id.mainActivity_bottomNavigation)]
        BottomNavigationView bottomNavigation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_layout);
            Cheeseknife.Bind(this);

            bottomNavigation.SetShiftMode(false, false);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            //TODO temp
            FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
            fragmentTx.Replace(Resource.Id.mainActivity_content, new StatFragment()).Commit();
        }

        void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();

            switch (e.Item.ItemId)
            {
                case Resource.Id.menu_news:
                    fragmentTx.Replace(Resource.Id.mainActivity_content, new StatFragment()).Commit();
                    break;
                case Resource.Id.menu_favorites:
                    fragmentTx.Replace(Resource.Id.mainActivity_content, new FavoritTasksFragment()).Commit();
                    break;
            }
        }
    }
}