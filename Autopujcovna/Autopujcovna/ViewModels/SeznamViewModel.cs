using System;
using System.Collections.Generic;
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
            Odebrat = new Command(Odebrat_e);
        }

        public Command Odebrat { get; private set; }
        private List<SeznamViewItem> seznamData;

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

        private void Odebrat_e(object sender)
        {

        }
    }
}
