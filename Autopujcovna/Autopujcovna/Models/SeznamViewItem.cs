using System;
using System.Collections.Generic;
using System.Text;

namespace Autopujcovna.Models 
{
    class SeznamViewItem : Autopujcovna.ViewModels.Abstract.ViewModel
    {
        public string spz;
        public string jmeno;
        public string vozidlo;

        public string SeznamJmeno
        {
            get
            {
                return this.jmeno;
            }
            set
            {
                jmeno = value;
                this.OnPropertyChanged();
            }
        }

        public string SeznamVozidlo
        {
            get
            {
                return this.vozidlo;
            }
            set
            {
                vozidlo = value;
                this.OnPropertyChanged();
            }
        }

        public string SeznamSPZ
        {
            get
            {
                return this.spz;
            }
            set
            {
                spz = value;
                this.OnPropertyChanged();
            }
        }
    }
}
