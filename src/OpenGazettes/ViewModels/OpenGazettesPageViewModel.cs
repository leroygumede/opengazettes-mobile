using OpenGazettes.Services.Interfaces;
using Prism.Navigation;
using Prism.Services;

namespace OpenGazettes.ViewModels
{
    public class OpenGazettesPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        public OpenGazettesPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
            : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            //if (parameters.ContainsKey("gazette"))
            //{
            //    SelectedGazette = parameters["gazette"] as Result;
            //    if (SelectedGazette != null)
            //    {
            //        Title = SelectedGazette.Label;
            //        // await GetYears(SelectedGazette);
            //    }
            //}
            //else
            //{
            //    await _navigationService.GoBackAsync();
            //}
        }
    }
}