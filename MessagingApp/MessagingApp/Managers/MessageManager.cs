using FireSharp.Interfaces;
using MessagingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using Xamarin.Forms;
using MessagingApp.Views;

namespace MessagingApp.Managers
{
    public class MessageManager
    {

        #region Singleton
        private static MessageManager _instance;
        public static MessageManager Instance
        {
        get
            {
                if (_instance == null) _instance = new MessageManager();
                return _instance;
            }
        }
        #endregion

        public User currentUser;

        private IFirebaseClient client;

        public List<User> users = new List<User>();
        public List<Chat> chats = new List<Chat>();

        public MessageManager()
        {
            InitClient();
        }

        private void InitClient()
        {
            IFirebaseConfig config = new FirebaseConfig()
            {
                BasePath = "https://firesharp-test.firebaseio.com/"
            };
            client = new FirebaseClient(config);
        }

        public async void InitUsers()
        {
            Dictionary<string, User> userList = new Dictionary<string, User>();
            FirebaseResponse response = await client.GetAsync("users");
            userList = response.ResultAs<Dictionary<string, User>>();
            foreach (User user in userList.Values)
            {
                users.Add(user);
            }
        }

        public void InitChats()
        {
            Dictionary<string, Chat> chatList = new Dictionary<string, Chat>();
            FirebaseResponse response = client.Get("chats");
            chatList = response.ResultAs<Dictionary<string, Chat>>();
            foreach (Chat chat in chatList.Values)
            {
                if (chat.User1.Username == currentUser.Username ||
                    chat.User2.Username == currentUser.Username)
                {
                    if (chat.User1 == currentUser)
                    {
                        chat.To = chat.User2.Username;
                    }
                    else
                    {
                        chat.To = chat.User1.Username;
                    }
                    chats.Add(chat);
                }
            }
        }

        public async void UpdateChat(Chat chat)
        {
            string name = chat.User1.Username + "-" + chat.User2.Username;
            await client.SetAsync("chats/" + name, chat);

        }

        public async void UpdateUser(User user)
        {
            await client.SetAsync("users/" + user.Username, user);
        }

        public IFirebaseClient GetClient() { return client; }

        public void LoginUser(User user)
        {
            UpdateUser(user);
            currentUser = user;
            Application.Current.MainPage = new NavigationPage(new ChatListView());
            Application.Current.MainPage.DisplayAlert("Login Succesful", "Welcome, " + user.Username + "!", "Thanks!");
        }
    }
}