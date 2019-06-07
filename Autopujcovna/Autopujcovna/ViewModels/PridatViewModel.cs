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
    class PridatViewModel : Abstract.ViewModel
    {
        // Konstruktor
        public PridatViewModel()
        {
            UkazMain = new Command(UkazMain_e);
            PotvrditPridat = new Command(PotvrditPridat_e);
        }

        // Definování commandů/proměnných
        public Command UkazMain { get; private set; }
        public Command PotvrditPridat { get; private set; }
        private string NazevVozidla = "";
        private string SPZ = "";
        private string Jmeno = "";

        public string EntryNazevVozidla
        {
            get { return NazevVozidla; }
            set { NazevVozidla = value; }
        }

        public string EntrySPZ
        {
            get { return SPZ; }
            set { SPZ = value; }
        }

        public string EntryJmeno
        {
            get { return Jmeno; }
            set { Jmeno = value; }
        }

        // Command pro ukázání hlavní obrazovky/menu
        void UkazMain_e(object sender)
        {
            App.Current.MainPage = new NavigationPage(new MainView());
        }

        // Přidá item do seznamu
        async void PotvrditPridat_e(object sender)
        {
            // Kontrola, zda není entry prázdný
            if (EntryJmeno == "" || EntryNazevVozidla == "" || EntrySPZ == "")
            {
                await Application.Current.MainPage.DisplayAlert("Pozor!", "Máte nevyplněné políčko!", "OK");
                return;
            }
            // Kontrola zda má SPZ 7 znaků
            if (EntrySPZ.Length < 7)
            {
                await Application.Current.MainPage.DisplayAlert("Pozor!", "Vaše SPZ neobsahuje 7 znaků!", "OK");
                return;
            }
            // Kontrola zda není SPZ stejná s jiným autem
            foreach(SeznamViewItem item in SeznamData.seznamData.List)
            {
                if (item.spz == EntrySPZ)
                {
                    await Application.Current.MainPage.DisplayAlert("Pozor!", "Auto s touto SPZ již existuje!", "OK");
                    return;
                }
            }
            // Finální přidání
            SeznamViewItem item1 = new SeznamViewItem { jmeno = EntryJmeno, spz = EntrySPZ, vozidlo = EntryNazevVozidla };
            SeznamData.seznamData.List.Add(item1);
            // Zde bych dal nějaký toast s informací o přidání, ale poměrně složitě se implementuje, tak použiju alert
            await Application.Current.MainPage.DisplayAlert("Info", "Přidali jste novou položku.", "OK");
        }
    }
}
