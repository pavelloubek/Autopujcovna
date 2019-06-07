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


        // Musí být v code behind kvůli dostupnosti komponent + asynchronnímu alertu
        async public void OdebratClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Pozor!", "Opravdu chcete odebrat položku?", "Ano", "Ne");
            if (answer)
            {
                var button = sender as Button;
                var item = button.BindingContext as SeznamViewItem;
                var viewModel = BindingContext as SeznamViewModel;
                viewModel.OdebratCommand.Execute(item);
            }
        }
    }
}