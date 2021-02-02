using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace OpenGazettes.ViewModels
{
    public class MainMenuPageViewModel : ViewModelBase
    {
        #region Commands

        public DelegateCommand NavigateToAboutCommand => new DelegateCommand(async () => await NavigateToAbout());
        public DelegateCommand NavigateToHomeCommand => new DelegateCommand(async () => await NavigateToHome());

        #endregion

        #region Constructor

        public MainMenuPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }

        #endregion

        #region Methods

        public async Task NavigateToAbout()
        {
            await NavigationService.NavigateAsync("MainMenuPage/NavigationPage/AboutPage");
        }

        public async Task NavigateToHome()
        {
            await NavigationService.NavigateAsync("MainMenuPage/NavigationPage/DashoardPage");
        }

        #endregion
    }
}