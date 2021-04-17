using BasketBall_Data_Project.Constants;
using BasketBall_Data_Project.Services;
using BasketBall_Data_Project.ViewModels;
using BasketBall_Data_Project.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace BasketBall_Data_Project
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }
        
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(NavigationConstants.Home);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITeamApiService, TeamApiService>();
            containerRegistry.Register<ILeagueApiService, LeagueApiService>();
            containerRegistry.Register<ISerializerService, SerializerService>();
            containerRegistry.Register<IEventApiService, EventApiService>();

            containerRegistry.RegisterForNavigation<CustomTabbedPage>(NavigationConstants.Tabs);
            containerRegistry.RegisterForNavigation<NavigationPage>(NavigationConstants.Navigate);
            containerRegistry.RegisterForNavigation<LeaguePage>(NavigationConstants.League);
            containerRegistry.RegisterForNavigation<EventPage>(NavigationConstants.Event);
            containerRegistry.RegisterForNavigation<TeamPage>(NavigationConstants.Team);
            containerRegistry.RegisterForNavigation<TeamDetailsPage>(NavigationConstants.TeamDetails);

            containerRegistry.RegisterForNavigation<LeaguePage, LeagueViewModel>(NavigationConstants.League);
            containerRegistry.RegisterForNavigation<EventPage, LiveGameViewModel>(NavigationConstants.Event);
            containerRegistry.RegisterForNavigation<TeamPage, TeamViewModel>(NavigationConstants.Team);
            containerRegistry.RegisterForNavigation<TeamDetailsPage, TeamDetailsViewModel>(NavigationConstants.TeamDetails);
            containerRegistry.RegisterForNavigation<LeagueDetailsPage, LeagueDetailsViewModel>(NavigationConstants.LeagueDetails);
        }
    }
}
