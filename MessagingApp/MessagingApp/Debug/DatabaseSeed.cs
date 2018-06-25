using FireSharp.Interfaces;
using MessagingApp.Managers;
using MessagingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingApp.Debug
{
    public class DatabaseSeed
    {
        public static void SeedUsers()
        {
            User testUser = new User()
            {
                Username = "codyjg10"
            };
            /**
            User testUser2 = new User()
            {
                Username = "testUser"
            };

            IFirebaseClient client = MessageManager.Instance.GetClient();

            client.Set("users/" + testUser.Username, testUser);
            client.Set("users/" + testUser2.Username, testUser2);

            Chat chat = new Chat()
            {
                Key = testUser.Username + "-" + testUser2.Username,
                Messages = new List<ChatMessage>(),
                User1 = testUser,
                User2 = testUser2
            };

            client.Set("chats/" + chat.Key, chat);
            */

            MessageManager.Instance.currentUser = testUser;
        }
    }
}