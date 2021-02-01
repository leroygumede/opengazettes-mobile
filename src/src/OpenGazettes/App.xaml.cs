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
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/DashoardPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<DashoardPage, DashoardPageViewModel>();
            containerRegistry.RegisterForNavigation<GazettesPage, GazettesPageViewModel>();
            containerRegistry.RegisterForNavigation<GazetteDetailsPage, GazetteDetailsPageViewModel>();

            RegisterServices(containerRegistry);
        }

        public void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IHttpService, HttpService>();
            containerRegistry.Register<IGazetteService, GazetteService>();
            containerRegistry.RegisterForNavigation<GazetteResultsPage, GazetteResultsPageViewModel>();
        }
    }
}