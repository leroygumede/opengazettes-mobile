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

        #endregion

        public MainMenuPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }

        #region Methods

        public async Task NavigateToAbout()
        {
            await NavigationService.NavigateAsync("AboutPage");
        }

        #endregion
    }
}