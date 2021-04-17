using BasketBall_Data_Project.Constants;
using BasketBall_Data_Project.Models.TeamModel;
using BasketBall_Data_Project.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketBall_Data_Project.ViewModels
{
    public class TeamDetailsViewModel : BaseViewModel, INavigationAware
    {
        public override string Title { get; set; } = Config.TeamTitle;
        public Datum TeamDetails { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Logo { get; set; }
        public TeamDetailsViewModel(INavigationService navigationService, IPageDialogService pageDialogService, TeamApiService teamApiService) : base(navigationService, pageDialogService){}
        public void OnNavigatedFrom(INavigationParameters parameters) { }
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            TeamDetails = parameters.GetValue<Datum>(ParameterConstants.Team);
            Name = TeamDetails.Name;
            Logo = TeamDetails.Logo;
            Country = TeamDetails.Country;
        }
    }
}
