using FireSharp.Response;
using MessagingApp.Managers;
using MessagingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace MessagingApp.ViewModels
{
    public class ChatViewModel
    {
        public Chat Chat { get; set; }
        public string Recipent
        {
            get
            {
                User current = MessageManager.Instance.currentUser;
                if (Chat.User1.Username == current.Username)
                {
                    return Chat.User2.Username;
                }
                else
                {
                    return Chat.User1.Username;
                }
            }
        }
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        private EventStreamResponse eventResponse;

        public ChatViewModel(Chat chat)
        {
            Chat = chat;
            //LoadMessages();
            //LoadMessages2();
        }

        private async void LoadMessages()
        {
            string name = Chat.User1.Username + "-" + Chat.User2.Username;
            var client = MessageManager.Instance.GetClient();
            eventResponse = await client.OnAsync("chats/" + name + "/Messages", async (sender, args, context) => {
                var response = await client.GetAsync("chats/" + name);
                Chat chat = response.ResultAs<Chat>();
                chat.Messages.ForEach(x =>
                {
                    if (!MessageExists(x.Id))
                    {
                        x.SetTextSettings();
                        Messages.Add(x);
                    }
                });
            });
        }

        /**
        private async void LoadMessages2()
        {
            string chatName = Chat.User1.Username + "-" + Chat.User2.Username;
            var client = MessageManager.Instance.GetClient();
            string path = "chats/" + chatName + "/Messages";
            EventRootResponse<Chat> stream = await client.OnChangeGetAsync(path, async (sender, args) =>
            {
                Console.WriteLine("Found Chat");
            }); 
        }
    */
        private bool MessageExists(int id)
        {
            foreach (ChatMessage current in Messages)
            {
                if (current.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}