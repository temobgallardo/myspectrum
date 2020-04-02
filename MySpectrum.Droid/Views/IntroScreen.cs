using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MySpectrum.Droid.Views
{
    [Activity(
        Label = "@string/app_name"
        , MainLauncher = true
        , NoHistory = true
        , Theme = "@style/AppTheme.Splash"
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class IntroScreen : MvxSplashScreenAppCompatActivity
    {
        public IntroScreen()
            : base(Resource.Layout.intro_view)
        { }
    }
}