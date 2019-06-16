using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace EduApp
{
    [Activity(Theme = "@style/MyTheme.Splash", Icon = "@drawable/logo", RoundIcon = "@drawable/logo",
       MainLauncher = true, NoHistory = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashScreenActivity : AppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            await Initialize();
        }
        public async Task Initialize()
        {
            await Task.Delay(2000);
            StartActivity(new Intent(BaseContext, typeof(InfoActivity)));
        }
    }
}