using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using CheeseBind;
using Android.Widget;
using Android.Content;
using System;

namespace EduApp
{
    [Activity(Theme = "@style/MainTheme.NoActionBar", Label = "", LaunchMode = LaunchMode.SingleTask, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ResultTestActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.result_test_layout);
            Cheeseknife.Bind(this);
        }

        [OnClick(Resource.Id.ResultTestActivity_closeBtn)]
        void OnClickCloseButton(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}