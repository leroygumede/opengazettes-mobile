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
    }
}