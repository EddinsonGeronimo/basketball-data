﻿using BasketBall_Data_Project.Models.LeagueModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasketBall_Data_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaguePage : ContentPage
    {
        public LeaguePage()
        {
            InitializeComponent();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Datum;
            await Navigation.PushAsync(new LeagueDetailsPage(details.Name));
        }
    }
}