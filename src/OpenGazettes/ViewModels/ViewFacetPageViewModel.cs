using OpenGazettes.Constants;
using OpenGazettes.Models;
using OpenGazettes.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace OpenGazettes.ViewModels
{
    public class ViewFacetPageViewModel : ViewModelBase
    {
        #region Events

        public ObservableCollection<Value> FacetList { get; set; } = new ObservableCollection<Value>();
        public string SelectionType { get; set; }
        #endregion

        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        #region Commands

        public DelegateCommand<object> SelectedItemCommand => new DelegateCommand<object>(async (obj) => await ItemSelected(obj));

        #endregion

        #region Constructor

        public ViewFacetPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
            : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
        }

        #endregion

        #region Methods

        public async Task GetFacets(string facet, int collectionId)
        {
            try
            {
                var result = await _gazetteService.FacetSearch(facet, collectionId);

                if (SelectionType == "Phone")
                {
                    FacetList = new ObservableCollection<Value>(result.Facets.PhoneNumbers.Values);
                }
                else if (SelectionType == "Email")
                {
                    FacetList = new ObservableCollection<Value>(result.Facets.EmailAddress.Values);
                }
                else if (SelectionType == "Website")
                {
                    FacetList = new ObservableCollection<Value>(result.Facets.Domains.Values);
                }
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
                var item = (Value)obj;
                if (SelectionType == "Phone")
                {
                    PhoneDialer.Open(item.Label);
                }
                else if (SelectionType == "Email")
                {
                    var message = new EmailMessage
                    {
                        Subject = "Gazette",
                        Body = "Gazette",
                        To = new System.Collections.Generic.List<string> { item.Label },
                    };
                    await Email.ComposeAsync(message);
                }
                else if (SelectionType == "Website")
                {
                    await Browser.OpenAsync("https://" + item.Label, BrowserLaunchMode.SystemPreferred);
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
            if (parameters.ContainsKey("Facet"))
            {
                Title = parameters["Title"] as string;
                var selectedFacet = parameters["Facet"] as string;
                var collectionId = parameters["CollectionId"] as string;
                SelectionType = parameters["SelectionType"] as string;
                if (!string.IsNullOrEmpty(selectedFacet))
                {
                    await GetFacets(selectedFacet, Convert.ToInt32(collectionId));
                }
            }
        }

        #endregion Navigation
    }
}