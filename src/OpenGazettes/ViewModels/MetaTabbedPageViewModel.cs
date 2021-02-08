using OpenGazettes.Models;
using OpenGazettes.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    ChildrenfirstViewModel.Text = "2";
                    ChildrensecondViewModel.Text = "3";

                    ChildrenfirstViewModel.SearchResult = gazette;
                    ChildrensecondViewModel.SearchResult = gazette;
                }
            }
        }

        #endregion Navigation
    }
}