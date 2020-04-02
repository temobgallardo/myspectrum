using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MySpectrum.Core.ViewModels
{
    public class GenericViewModel : MvxViewModel
    {
        private string _title;
        private bool _isBusy;
        protected IMvxNavigationService _navigationService;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public GenericViewModel(IMvxNavigationService navigationService) 
        {
            _navigationService = navigationService;
        }
    }
}
