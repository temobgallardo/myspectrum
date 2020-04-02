using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MySpectrum.Models.Users;
using MySpectrum.Shared.Repositories;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySpectrum.Core.ViewModels
{
    public class UsersViewModel : GenericViewModel
    {
        private readonly IDao<User> _userDao;
        public IMvxAsyncCommand NewUserCommand { get; private set; }
        public MvxObservableCollection<User> Users { get; private set; }

        public UsersViewModel(IMvxNavigationService navigationService,
            IDao<User> userDao) : base(navigationService)
        {
            _userDao = userDao;
            Title = "MySpectrum - Users";
            NewUserCommand = new MvxAsyncCommand(NewUser);
            Users = new MvxObservableCollection<User>();
        }

        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            await ReloadUsers();
        }
        private async Task ReloadUsers() 
        {
            if (IsBusy) 
            {
                return;
            }

            try
            {

                IsBusy = true;
                var users = await _userDao.GetEntitiesAsync();
                if (users != null && users.Any())
                {
                    Users.Clear();
                    Users.AddRange(items: users);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally 
            {
                IsBusy = false;
            }
        }

        private async Task NewUser()
        {
            await _navigationService.Navigate<AddUserViewModel>();
        }
    }
}
