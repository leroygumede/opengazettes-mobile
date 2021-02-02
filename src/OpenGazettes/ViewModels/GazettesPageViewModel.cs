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
    public class GazettesPageViewModel : ViewModelBase
    {
        #region Events
        public DateTime SelectedDate { get; set; }
        #endregion
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        public ObservableCollection<Value> PublicationDatesList { get; set; } = new ObservableCollection<Value>();
        public GazetteResult SelectedGazette { get; set; }

        #region Commands

        public DelegateCommand ViewPhoneNumbersCommand => new DelegateCommand(async () => await ViewPhoneNumbers());
        public DelegateCommand ViewEmailAddressCommand => new DelegateCommand(async () => await ViewEmailAddress());
        public DelegateCommand ViewDomainsCommand => new DelegateCommand(async () => await ViewDomains());
        public DelegateCommand<object> SelectedItemCommand => new DelegateCommand<object>(async (obj) => await ItemSelected(obj));

        #endregion Commands

        public GazettesPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
            : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
            SelectedDate = DateTime.Now;
        }

        #region Methods

        public async Task ViewPhoneNumbers()
        {
            throw new NotImplementedException();
        }

        public async Task ViewEmailAddress()
        {
            throw new NotImplementedException();
        }

        public async Task ViewDomains()
        {
            throw new NotImplementedException();
        }

        public async Task ItemSelected(object obj)
        {
            try
            {
                var item = (Value)obj;
                var date = DateTime.Parse(item.Label).ToString("MMMM yyyy");
                var name = GetUntilOrEmpty(SelectedGazette.Label, " Gazettes") + " Gazette vol";
                var searchParam = @"""" + name + @""" AND """ + date + @"""";
                var np = new NavigationParameters
                    {
                        { "SearchParam", searchParam}
                    };
                await NavigationService.NavigateAsync("GazetteResultsPage", np);
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync(Dialog.Error, ex.Message, Dialog.Ok);
            }
        }

        public string GetUntilOrEmpty(string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

        public async Task GetPublicstions()
        {
            try
            {
                var result = await _gazetteService.FacetSearch("publication_date", Convert.ToInt32(SelectedGazette.Id));
                PublicationDatesList = new ObservableCollection<Value>(result.Facets.PublicationDate.Values);
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
            if (parameters.ContainsKey("gazette"))
            {
                SelectedGazette = parameters["gazette"] as GazetteResult;
                if (SelectedGazette != null)
                {
                    Title = SelectedGazette.Label;
                    await GetPublicstions();
                }
            }
        }

        #endregion Navigation
    }
}