using OpenGazettes.Dependencies;
using OpenGazettes.Models;
using OpenGazettes.Services.Interfaces;
using Prism.Navigation;
using Prism.Services;
using Syncfusion.Pdf.Parsing;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace OpenGazettes.ViewModels
{
    public class GazetteDetailsPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;
        readonly IPageDialogService _pageDialogService;
        readonly ILocalFile _localFile;

        #endregion Services

        public SearchResult SelectedGazette { get; set; }

        public Stream SourceWebView { get; set; }
        public PdfLoadedDocument SourceWebView2 { get; set; }
        public byte[] SourceWebView3 { get; set; }

        public GazetteDetailsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService, ILocalFile localFile)
                        : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
            _pageDialogService = pageDialogService;
            _localFile = localFile;
            Title = "PDF";
        }

        public async Task SaveAndOpenFile()
        {
            if (await CheckPermissions())
            {
                SourceWebView = await _gazetteService.DownloadPdfNative(SelectedGazette.SourceUrl.ToString());
            }
        }

        public Stream ToStream(byte[] bytes)
        {
            return new MemoryStream(bytes)
            {
                Position = 0
            };
        }

        public async Task<bool> CheckPermissions()
        {
            var statusWrite = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (statusWrite != PermissionStatus.Granted)
            {
                statusWrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            if (statusWrite != PermissionStatus.Granted)
            {
                await _pageDialogService.DisplayAlertAsync("Permissions Error", "The application requires permission to use your storage", "OK");
                return false;
            }

            var statusRead = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (statusRead != PermissionStatus.Granted)
            {
                statusRead = await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            if (statusRead != PermissionStatus.Granted)
            {
                await _pageDialogService.DisplayAlertAsync("Permissions Error", "The application requires permission to read cache", "OK");
                return false;
            }

            return true;
        }

        #region Navigation

        public override async void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("gazette"))
            {
                var gazette = parameters["gazette"] as SearchResult;
                if (gazette != null)
                {
                    SelectedGazette = gazette;
                    Title = SelectedGazette.Title;
                    await SaveAndOpenFile();
                }
            }
        }

        #endregion Navigation
    }
}