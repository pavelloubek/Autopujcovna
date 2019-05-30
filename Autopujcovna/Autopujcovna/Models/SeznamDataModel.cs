using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Autopujcovna.Views;
using Autopujcovna.ViewModels;
using Autopujcovna.Models;

namespace Autopujcovna.Models
{
    class SeznamDataModel : ViewModels.Abstract.ViewModel
    {
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
    }
}
