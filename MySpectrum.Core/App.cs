using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MySpectrum.Core.ViewModels;
using MySpectrum.Models.Users;
using MySpectrum.Shared.Repositories;

namespace MySpectrum.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IDao<User>, UserDao>();
            RegisterAppStart<UsersViewModel>();
        }
    }
}
