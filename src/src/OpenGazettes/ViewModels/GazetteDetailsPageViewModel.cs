using OpenGazettes.Constants;
using OpenGazettes.Models;
using OpenGazettes.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace OpenGazettes.ViewModels
{
    public class GazetteDetailsPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        public SearchResult SelectedGazette { get; set; }

        public string SourceWebView { get; set; }

        #region Commands

        public DelegateCommand<object> SelectedItemCommand { get; set; }

        #endregion Commands

        public GazetteDetailsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
            : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;

            SelectedItemCommand = new DelegateCommand<object>(async (obj) => await ItemSelected(obj));
        }

        public async Task ItemSelected(object obj)
        {
            try
            {
                await NavigationService.NavigateAsync("GazetteDetailsPage");
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync(Dialog.Error, ex.Message, Dialog.Ok);
            }
        }

        #region Navigation

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("gazette"))
            {
                var gazette = parameters["gazette"] as SearchResult;
                if (gazette != null)
                {
                    Title = gazette.Title;
                    SelectedGazette = gazette;
                    SourceWebView = "https://docs.google.com/viewer?url=" + SelectedGazette.SourceUrl;
                }
            }
            else
            {
                await NavigationService.GoBackAsync();
            }
        }

        #endregion Navigation
    }
}