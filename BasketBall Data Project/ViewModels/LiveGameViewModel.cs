using BasketBall_Data_Project.Constants;
using BasketBall_Data_Project.Models;
using BasketBall_Data_Project.Models.Event;
using BasketBall_Data_Project.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace BasketBall_Data_Project.ViewModels
{
    public class LiveGameViewModel : BaseViewModel
    {
        public override string Title { get; set; } = Config.LiveGamesTitle;

        public ObservableCollection<Datum> Events { get; set; }
        private IEventApiService _eventApiService;
        public bool IsBusy { get; set; }
        public bool IsNotBusy => !IsBusy;

        public LiveGameViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEventApiService eventApiService) : base(navigationService, pageDialogService)
        {
            _eventApiService = eventApiService;
            LoadLiveGames();
        }

        private async void LoadLiveGames()
        {
            IsBusy = true;
            if (!(Connectivity.NetworkAccess == NetworkAccess.Internet))
            {
                await AlertService.DisplayAlertAsync(AlertDialogConstants.Error, AlertDialogConstants.NoInternet, AlertDialogConstants.Ok);
            }
            else
            {
                var events = await _eventApiService.GetInfoAsync();
                Events = events.Data;
            }
            IsBusy = false;
        }
    }
}
