using OpenGazettes.Models;
using OpenGazettes.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenGazettes.ViewModels
{
    public class MetadataPageViewModel : ViewModelBase
    {
        #region Services

        readonly IGazetteService _gazetteService;

        #endregion Services

        #region Commands

        public DelegateCommand<string> DownloadFileCommand => new DelegateCommand<string>(async (path) => await DownloadFile(path));

        #endregion

        public MetadataPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGazetteService gazetteService)
    : base(navigationService, pageDialogService)
        {
            _gazetteService = gazetteService;
            Title = "Meta data";
        }

        #region Methods

        public Task DownloadFile(string path)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("gazette"))
            {
                var gazette = parameters["gazette"] as SearchResult;
                if (gazette != null)
                {
                }
            }
        }

        #endregion Navigation
    }
}