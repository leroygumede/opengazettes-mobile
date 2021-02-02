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
    public class SearchPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        #region Events
        public ObservableCollection<GazetteResult> CollectionList { get; set; }
        #endregion

        #region Commands

        public DelegateCommand SearchCommand => new DelegateCommand(async () => await Search());
        public DelegateCommand<object> SelectedItemCommand => new DelegateCommand<object>(async (obj) => await ItemSelected(obj));

        #endregion Commands

        public SearchPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
    : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
            Title = "Open Gazette";
        }

        #region Methods

        public async Task Search()
        {
            try
            {
                var np = new NavigationParameters
                {
                };
                await NavigationService.NavigateAsync("GazettesPage", np);
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync(Dialog.Error, ex.Message, Dialog.Ok);
            }
        }

        public async Task ItemSelected(object obj)
        {
            try
            {
                var item = (GazetteResult)obj;
                var np = new NavigationParameters
                    {
                        { "gazette", item}
                    };
                await NavigationService.NavigateAsync("GazettesPage", np);
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync(Dialog.Error, ex.Message, Dialog.Ok);
            }
        }

        public async Task GetCollection(string search)
        {
            try
            {
                var results = await _gazetteService.GetAllCountries();
                if (results != null)
                {
                    CollectionList = new ObservableCollection<GazetteResult>(results.Results);
                }
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync(Dialog.Error, ex.Message, Dialog.Ok);
            }
        }

        #endregion

        #region Navigation

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        #endregion Navigation
    }
}