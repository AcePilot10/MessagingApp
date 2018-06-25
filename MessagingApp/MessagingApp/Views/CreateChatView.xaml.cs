using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateChatView : ContentPage
	{
		public CreateChatView ()
		{
			InitializeComponent ();
            BindingContext = new CreateChatViewModel();
		}
	}
}