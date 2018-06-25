using MessagingApp.Managers;
using MessagingApp.Models;
using MessagingApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MessagingApp.ViewModels
{
    public class ChatListPageViewModel
    {
        public ObservableCollection<Chat> Chats { get; set; } = new ObservableCollection<Chat>();
        public ICommand MessageCommand { get; private set; }
        public ICommand CreateChatCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public bool IsRefreshing { get; private set; } = false;

        public ChatListPageViewModel()
        {
            MessageManager.Instance.InitChats();
            LoadChats();
            MessageCommand = new Command<Chat>(x => MessageUser(x));
            CreateChatCommand = new Command(x => Application.Current.MainPage.Navigation.PushAsync(new CreateChatView()));
            RefreshCommand = new Command(Refresh);
        }

        public void MessageUser(Chat chat)
        {
            ChatView view = new ChatView(chat);
            Application.Current.MainPage.Navigation.PushAsync(view);
        }

        private void Refresh()
        {
            IsRefreshing = true;
            Chats.Clear();
            LoadChats();
            IsRefreshing = false;
        }

        private void LoadChats()
        {
            foreach (Chat chat in MessageManager.Instance.chats)
            {
                chat.Init();
                Chats.Add(chat);
            }
        }
    }
}