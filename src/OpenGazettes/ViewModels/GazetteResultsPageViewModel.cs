using OpenGazettes.Constants;
using OpenGazettes.Models;
using OpenGazettes.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OpenGazettes.ViewModels
{
    public class GazetteResultsPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        #region Commands

        public DelegateCommand<object> SelectedItemCommand => new DelegateCommand<object>(async (obj) => await ItemSelected(obj));

        #endregion

        #region Events

        public ObservableCollection<SearchResult> CollectionList { get; set; }

        #endregion

        #region Constructor

        public GazetteResultsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
            : base(navigationService, pageDialogService)
        {
            Title = "Gazette";
            _gazetteService = gazetteService;
        }

        #endregion

        #region Methods

        public async Task ItemSelected(object obj)
        {
            try
            {
                var item = (SearchResult)obj;
                var np = new NavigationParameters
                    {
                        { "gazette", item}
                    };
                await NavigationService.NavigateAsync("GazetteDetailsPage", np);
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync(Dialog.Error, ex.Message, Dialog.Ok);
            }
        }

        public async Task Search(string path)
        {
            //var test2 = @"""KwaZulu-Natal Provincial Gazette vol"" AND ""September 2016""";
            var result = await _gazetteService.QuerySearch(path);

            if (result != null)
            {
                CollectionList = new ObservableCollection<SearchResult>(result.Results);
            }
        }

        #endregion

        #region Navigation

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("SearchParam"))
            {
                var SelectedMonth = parameters["SearchParam"] as string;
                if (!string.IsNullOrEmpty(SelectedMonth))
                {
                    await Search(SelectedMonth);
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