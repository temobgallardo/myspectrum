using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MySpectrum.Core.ViewModels;

namespace MySpectrum.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = false)]
    public class UsersView : MvxAppCompatActivity<UsersViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.users_view);
            SupportActionBar.Title = ViewModel.Title;

            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerview);
            var decorationItem = new DividerItemDecoration(recyclerView.Context, 1);
            recyclerView.AddItemDecoration(decorationItem);
        }
    }
}