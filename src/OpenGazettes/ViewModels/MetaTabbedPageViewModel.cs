using OpenGazettes.Models;
using Prism.Navigation;
using Prism.Services;

namespace OpenGazettes.ViewModels
{
    public class MetaTabbedPageViewModel : ViewModelBase
    {
        #region Events

        public ChildrenOneViewModel ChildrenfirstViewModel { get; set; }
        public ChildrenTwoViewModel ChildrensecondViewModel { get; set; }

        #endregion

        public MetaTabbedPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            ChildrenfirstViewModel = new ChildrenOneViewModel();
            ChildrensecondViewModel = new ChildrenTwoViewModel();
        }

        #region Navigation

        public override void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("gazette"))
            {
                var gazette = parameters["gazette"] as SearchResult;
                if (gazette != null)
                {
                    Title = gazette.Title;
                    ChildrenfirstViewModel.Text = "1";
                    ChildrensecondViewModel.Text = "2";

                    ChildrenfirstViewModel.SearchResult = gazette;
                    ChildrensecondViewModel.SearchResult = gazette;
                }
            }
        }

        #endregion Navigation
    }
}