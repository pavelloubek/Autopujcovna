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

            Data = new ObservableCollection<SeznamViewItem>(ListData);
        }
        
        public Command UkazMain { get; private set; }
        
        public List<SeznamViewItem> ListData { get { return SeznamData.seznamData.List; } set { SeznamData.seznamData.List = value; } }

        public ObservableCollection <SeznamViewItem> Data { get; set; }

        void UkazMain_e(object sender)
        {
            App.Current.MainPage = new NavigationPage(new MainView());
        }

        public Command<SeznamViewItem> OdebratCommand
        {
            get
            {
                return new Command<SeznamViewItem>((item) => {
                    Data.Remove(item);
                    ListData.Remove(item);
                });
            }
        }
    }
}
