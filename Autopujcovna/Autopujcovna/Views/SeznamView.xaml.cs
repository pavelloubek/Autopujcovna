using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Autopujcovna.Models;
using Autopujcovna.ViewModels;

namespace Autopujcovna.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SeznamView : ContentPage
	{
		public SeznamView ()
		{
			InitializeComponent ();
		}

        private void Odebrat_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button.BindingContext as SeznamViewItem;
            var viewModel = BindingContext as SeznamViewModel;
            viewModel.OdebratCommand.Execute(item);
        }
    }
}