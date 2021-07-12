using Prism;
using Prism.Ioc;
using OpenGazettes.ViewModels;
using OpenGazettes.Views;
using Xamarin.Forms;
using OpenGazettes.Services.Interfaces;
using OpenGazettes.Services.Implementation;

namespace OpenGazettes
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");
            InitializeComponent();
            await NavigationService.NavigateAsync("/MainMenuPage/NavigationPage/DashoardPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MetaTabbedPage, MetaTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MainMenuPage, MainMenuPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<DashoardPage, DashoardPageViewModel>();
            containerRegistry.RegisterForNavigation<GazettesPage, GazettesPageViewModel>();

            containerRegistry.RegisterForNavigation<OpenGazettesPage, OpenGazettesPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewFacetPage, ViewFacetPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();
            containerRegistry.RegisterForNavigation<GazetteResultsPage, GazetteResultsPageViewModel>();
            containerRegistry.RegisterForNavigation<MetadataPage, MetadataPageViewModel>();
            containerRegistry.RegisterForNavigation<GazetteDetailsPage, GazetteDetailsPageViewModel>();

            RegisterServices(containerRegistry);
        }

        public void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IHttpService, HttpService>();
            containerRegistry.Register<IGazetteService, GazetteService>();
        }
    }
}