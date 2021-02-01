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
    public class GazettesPageViewModel : ViewModelBase
    {
        #region Events
        public DateTime SelectedDate { get; set; }
        #endregion
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        public ObservableCollection<Models.GazetteGroup> GazetteList { get; private set; } = new ObservableCollection<Models.GazetteGroup>();
        public GazetteResult SelectedGazette { get; set; }

        #region Commands

        public DelegateCommand SearchDateCommand => new DelegateCommand(async () => await SearchDate());

        #endregion Commands

        public GazettesPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
            : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
            SelectedDate = DateTime.Now;
        }

        public async Task SearchDate()
        {
            try
            {
                var date = SelectedDate.ToString("MMMM yyyy");
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

        #region Navigation

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("gazette"))
            {
                SelectedGazette = parameters["gazette"] as GazetteResult;
                if (SelectedGazette != null)
                {
                    Title = SelectedGazette.Label;
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