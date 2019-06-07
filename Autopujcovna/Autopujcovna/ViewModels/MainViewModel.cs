using System;
using System.Collections.Generic;
using System.Text;
using Autopujcovna.Views;
using Xamarin.Forms;
using Autopujcovna.Models;
using Autopujcovna.ViewModels;
using Autopujcovna.Views;
using System.IO;

namespace Autopujcovna.ViewModels
{
    class MainViewModel : Abstract.ViewModel
    {
        public MainViewModel()
        {
            UkazSeznam = new Command(UkazSeznam_e);
            UkazPridat = new Command(UkazPridat_e);
            NovySeznam = new Command(NovySeznam_e);
            UlozitSeznam = new Command(UlozitSeznam_e);
            NacistSeznam = new Command(NacistSeznam_e);
        }

        public Command UkazSeznam { get; private set; }
        public Command UkazPridat { get; private set; }
        public Command NovySeznam { get; private set; }
        public Command UlozitSeznam { get; private set; }
        public Command NacistSeznam { get; private set; }

        public List<SeznamViewItem> ListData { get { return SeznamData.seznamData.List; } set { SeznamData.seznamData.List = value; } }

        private void UkazSeznam_e()
        {
            App.Current.MainPage = new NavigationPage(new SeznamView());
        }

        private void UkazPridat_e()
        {
            App.Current.MainPage = new NavigationPage(new PridatView());
        }

        private void NovySeznam_e()
        {
            ListData = new List<SeznamViewItem>();
        }
        
        string filename = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "data.txt");

        private void UlozitSeznam_e()
        {
            using (var streamWriter = new StreamWriter(filename, true))
            {
                List<SeznamViewItem> listData = ListData;
                foreach(SeznamViewItem item in listData)
                {
                    string jmeno = item.jmeno;
                    string spz = item.spz;
                    string vozidlo = item.vozidlo;
                    streamWriter.WriteLine(jmeno + " " + spz + " " + vozidlo);
                }
            }
        }

        private void NacistSeznam_e()
        {
            ListData = new List<SeznamViewItem>();
            using (var streamReader = new StreamReader(filename))
            {
                List<string> listData;
                string line;
                while((line = streamReader.ReadLine()) != null)
                {

                }
            }
        }
    }
}
