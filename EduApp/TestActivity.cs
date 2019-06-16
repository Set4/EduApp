using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using CheeseBind;
using Android.Support.V7.Widget;

namespace EduApp
{
    [Activity(Theme = "@style/MainTheme.NoActionBar", Label = "", LaunchMode = LaunchMode.SingleTask, ScreenOrientation = ScreenOrientation.Portrait)]
    public class TestActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.test_layout);
            Cheeseknife.Bind(this);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.testActivity_toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            toolbar.NavigationClick += Toolbar_NavigationClick;
        }

        private void Toolbar_NavigationClick(object sender, V7Toolbar.NavigationClickEventArgs e)
        {
            OnBackPressed();
        }
    }
}