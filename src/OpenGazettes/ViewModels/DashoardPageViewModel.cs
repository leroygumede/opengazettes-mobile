using OpenGazettes.Constants;
using OpenGazettes.Models;
using OpenGazettes.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OpenGazettes.ViewModels
{
    public class DashoardPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        #region Events
        public ObservableCollection<GazetteResult> CollectionList { get; set; }
        #endregion

        #region Commands

        public DelegateCommand<object> ButtonNavigationCommand { get; set; }
        public DelegateCommand<object> SelectedItemCommand => new DelegateCommand<object>(async (obj) => await ItemSelected(obj));

        #endregion Commands

        public DashoardPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
            : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
            Title = "Open Gazette";

            ButtonNavigationCommand = new DelegateCommand<object>(async (path) => await NavigateToPage(path));
        }

        #region Methods

        public async Task NavigateToPage(object path)
        {
            try
            {
                var np = new NavigationParameters
                    {
                        { "location", path.ToString()}
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

        public async Task GetCollection()
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
            await GetCollection();
        }

        #endregion Navigation
    }
}