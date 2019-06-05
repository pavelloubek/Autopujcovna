using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Autopujcovna.Views;
using Autopujcovna.ViewModels;
using Autopujcovna.Models;

namespace Autopujcovna.ViewModels
{
    class SeznamViewModel : Abstract.ViewModel
    {
        public SeznamViewModel()
        {
            UkazMain = new Command(UkazMain_e);

            SeznamData = new ObservableCollection<SeznamViewItem>
            {
                new SeznamViewItem { jmeno = "jmeno1", spz = "spz1", vozidlo = "vozidlo1" },
                new SeznamViewItem { jmeno = "jmeno2", spz = "spz2", vozidlo = "vozidlo2" },
                new SeznamViewItem { jmeno = "jmeno3", spz = "spz3", vozidlo = "vozidlo3" },
                new SeznamViewItem { jmeno = "jmeno4", spz = "spz4", vozidlo = "vozidlo4" },
                new SeznamViewItem { jmeno = "jmeno5", spz = "spz5", vozidlo = "vozidlo5" }
            };
        }

        // vím že data by neměli být ve viewmodelu
        // private List<SeznamViewItem> seznamData;
        
        public Command UkazMain { get; private set; }

        /*
        public List<SeznamViewItem> SeznamData
        {
            get => seznamData;
            set
            {
                if (seznamData != value)
                {
                    seznamData = value;
                    OnPropertyChanged(nameof(SeznamData));
                }
            }
        }
        */

        public ObservableCollection<SeznamViewItem> SeznamData { get; set; }

        public Command<SeznamViewItem> OdebratCommand
        {
            get
            {
                return new Command<SeznamViewItem>((item) =>
                {
                    SeznamData.Remove(item);
                });
            }
        }


        void UkazMain_e(object sender)
        {
            App.Current.MainPage = new NavigationPage(new MainView());
        }
    }
}
