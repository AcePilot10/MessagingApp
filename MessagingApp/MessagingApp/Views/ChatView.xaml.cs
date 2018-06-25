using MessagingApp.Managers;
using MessagingApp.Models;
using MessagingApp.ViewModels;
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
	public partial class ChatView : ContentPage
	{

        private ChatViewModel model;

		public ChatView (Chat chat)
		{
			InitializeComponent ();
            model = new ChatViewModel(chat);
            BindingContext = model;
        }

        private void BtnSend_Clicked(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            if (model.Chat.Messages == null) model.Chat.Messages = new List<ChatMessage>();
            User author = MessageManager.Instance.currentUser;
            int id = model.Chat.Messages.Count + 1;
            ChatMessage msg = new ChatMessage
            {
                Author = author,
                Message = message,
                Id = id
            };
            model.Chat.Messages.Add(msg);
            MessageManager.Instance.UpdateChat(model.Chat);
            txtMessage.Text = "";
        }

        private void listChat_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listChat.SelectedItem = null;
        }
    }
}