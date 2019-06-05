using System;
using System.Collections.Generic;
using System.Text;
using Autopujcovna.Views;
using Xamarin.Forms;

namespace Autopujcovna.ViewModels
{
    class MainViewModel : Abstract.ViewModel
    {
        public MainViewModel()
        {
            UkazSeznam = new Command(UkazSeznam_e);
            UkazPridat = new Command(UkazPridat_e);
        }

        public Command UkazSeznam { get; private set; }
        public Command UkazPridat { get; private set; }

        private void UkazSeznam_e()
        {
            App.Current.MainPage = new NavigationPage(new SeznamView());
        }

        private void UkazPridat_e()
        {
            App.Current.MainPage = new NavigationPage(new PridatView());
        }
    }
}
