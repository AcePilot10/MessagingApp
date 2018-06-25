using MessagingApp.Managers;
using MessagingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MessagingApp.Views
{
    public class CreateChatViewModel
    {
        public ICommand ChatCommand { get; private set; }

        public CreateChatViewModel()
        {
            ChatCommand = new Command<string>(x => CreateChat(x));
        }

        private void CreateChat(string username)
        {
            User user = MessageManager.Instance.users.Find(x => x.Username == username);
            if (user != null)
            {
                Chat chat = new Chat()
                {
                    User1 = MessageManager.Instance.currentUser,
                    User2  = user
                };
                MessageManager.Instance.UpdateChat(chat);
                Application.Current.MainPage.Navigation.PushAsync(new ChatView(chat));
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error!", "User could not be found!", "Ok");
            }
        }
    }
}