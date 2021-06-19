using OpenGazettes.Constants;
using OpenGazettes.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace OpenGazettes.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        #region Commands

        public DelegateCommand<string> SelectedLinkCommand => new DelegateCommand<string>(async (path) => await SelectedLink(path));
        #endregion

        public AboutPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "About Us";
        }

        #region Methods

        public async Task SelectedLink(string path)
        {
            try
            {
                await Browser.OpenAsync(path, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync(Dialog.Error, ex.Message, Dialog.Ok);
            }
        }

        #endregion
    }
}