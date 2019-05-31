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

        private List<SeznamViewItem> seznamData;

        public Command Odebrat { get; private set; }

        public static List<SeznamViewItem> VratData(List<SeznamViewItem> data)
        {
            return data;
        }

        private void Odebrat_e(object parameter)
        {
            var item = parameter as SeznamViewItem;
            if (item != null)
            {
                seznamData.Remove(item);
            }
        }
    }
}
