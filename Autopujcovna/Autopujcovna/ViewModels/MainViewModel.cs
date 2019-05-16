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
            UkazOdebrat = new Command(UkazOdebrat_e);
        }

        public Command UkazSeznam { get; private set; }
        public Command UkazPridat { get; private set; }
        public Command UkazOdebrat { get; private set; }

        void UkazSeznam_e(object sender)
        {
            App.Current.MainPage = new NavigationPage(new SeznamView());
        }

        void UkazPridat_e(object sender)
        {
            App.Current.MainPage = new NavigationPage(new PridatView());
        }

        void UkazOdebrat_e(object sender)
        {
            App.Current.MainPage = new NavigationPage(new OdebratView());
        }
    }
}
