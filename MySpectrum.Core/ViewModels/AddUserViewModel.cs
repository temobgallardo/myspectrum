using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MySpectrum.Models.Users;
using MySpectrum.Shared.Repositories;
using MySpectrum.Shared.Utils;
using System.Threading.Tasks;

namespace MySpectrum.Core.ViewModels
{
    public class AddUserViewModel : GenericViewModel
    {
        private readonly IDao<User> _userDao;
        private readonly IUserDialogs _dialogService;
        private string _userName;
        private string _password;
        private string _fullName;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public IMvxAsyncCommand SaveCommand { get; private set; }
        public IMvxAsyncCommand BackCommand { get; private set; }

        public AddUserViewModel(IMvxNavigationService navigationService,
            IUserDialogs dialogService,
            IDao<User> userDao) : base(navigationService)
        {
            _dialogService = dialogService;
            _userDao = userDao;

            Title = "Add User";
            SaveCommand = new MvxAsyncCommand(Save);
            BackCommand = new MvxAsyncCommand(Back);
        }

        private async Task Save()
        {
            if (string.IsNullOrEmpty(UserName)) {
                _dialogService.Alert("The User Name must not be empty");
                return;
            }

            if (!Util.CheckPassword(Password)) {
                _dialogService.Alert("Password must contain: \nFrom 5 - 12 characters.\nAt least one words and digit.\nFollowing characters must be different.");
                return;
            }

            if (string.IsNullOrEmpty(FullName)) {
                _dialogService.Alert("The Full Name must not be empty");
                return;
            }

            await _userDao.SaveEntityAsync(new User()
            {
                UserName = UserName,
                Password = Password,
                FullName = FullName
            });

            await _navigationService.Close(this);
        }

        private async Task Back()
        {
            await _navigationService.Close(this);
        }
    }
}
