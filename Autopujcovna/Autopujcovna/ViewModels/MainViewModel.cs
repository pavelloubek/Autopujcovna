using System;
using System.Collections.Generic;
using System.Text;
using Autopujcovna.Views;
using Xamarin.Forms;
using Autopujcovna.Models;
using Autopujcovna.ViewModels;
using System.IO;

namespace Autopujcovna.ViewModels
{
    class MainViewModel : Abstract.ViewModel
    {
        // Konstruktor
        public MainViewModel()
        {
            UkazSeznam = new Command(UkazSeznam_e);
            UkazPridat = new Command(UkazPridat_e);
            NovySeznam = new Command(NovySeznam_e);
            UlozitSeznam = new Command(UlozitSeznam_e);
            NacistSeznam = new Command(NacistSeznam_e);
        }

        // Definování commandů
        public Command UkazSeznam { get; private set; }
        public Command UkazPridat { get; private set; }
        public Command NovySeznam { get; private set; }
        public Command UlozitSeznam { get; private set; }
        public Command NacistSeznam { get; private set; }

        // Získání dat z modelu
        public List<SeznamViewItem> ListData { get { return SeznamData.seznamData.List; } set { SeznamData.seznamData.List = value; } }

        // Command pro ukázání seznamu
        private void UkazSeznam_e()
        {
            App.Current.MainPage = new NavigationPage(new SeznamView());
        }

        // Command pro ukázání "přidat item"
        private void UkazPridat_e()
        {
            App.Current.MainPage = new NavigationPage(new PridatView());
        }



        // Proměnná pro cestu k souboru na ukládání/načítání (Netrumfnul jsem si ukládání více souborů do mobilu dle uživatele, tak jsem raději použil statický data.txt)
        readonly string filename = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "data.txt");

        // Command pro vyresetování seznamu
        private async void NovySeznam_e()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Pozor!", "Opravdu chcete vytvořit nový seznam? Tímto si vymažete aktuální seznam vozidel!", "Ano", "Ne");
            if (answer)
            {
                ListData = new List<SeznamViewItem>();
            }
            await Application.Current.MainPage.DisplayAlert("Info", "Vytvořil se Vám nový seznam.", "OK");
        }

        // Command pro uložení seznamu
        private async void UlozitSeznam_e()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Pozor!", "Opravdu chcete uložit seznam? Tímto si vymažete předešle uložený seznam vozidel!", "Ano", "Ne");
            if (answer)
            {
                using (var streamWriter = new StreamWriter(filename))
                {
                    List<SeznamViewItem> listData = ListData;
                    foreach (SeznamViewItem item in listData)
                    {
                        string jmeno = item.jmeno;
                        string spz = item.spz;
                        string vozidlo = item.vozidlo;
                        streamWriter.WriteLine(jmeno + "§" + spz + "§" + vozidlo);
                    }
                    await Application.Current.MainPage.DisplayAlert("Info", "Váš seznam se uložil.", "OK");
                }
            }
        }

        // Command pro načtení seznamu
        private async void NacistSeznam_e()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Pozor!", "Opravdu chcete načíst seznam? Tímto si vymažete aktuální seznam vozidel!", "Ano", "Ne");
            if (answer)
            {
                ListData = new List<SeznamViewItem>();
                using (var streamReader = new StreamReader(filename))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] slova = line.Split('§');
                        SeznamViewItem item = new SeznamViewItem { jmeno = slova[0], spz = slova[1], vozidlo = slova[2] };
                        ListData.Add(item);
                    }
                }
                await Application.Current.MainPage.DisplayAlert("Info", "Váš seznam se načetl.", "OK");
            }
        }
    }
}
