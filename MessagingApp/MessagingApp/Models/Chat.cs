using MessagingApp.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingApp.Models
{
    public class Chat : ModelBase
    {
        private string _key;

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                OnPropertyChanged("Key");
            }
        }
        public List<ChatMessage> Messages { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }
        public string To { get; set; }

        public void Init()
        {
            if (User1.Username == MessageManager.Instance.currentUser.Username)
            {
                To = User2.Username;
            }
            else
            {
                To = User1.Username;
            }
        }
    }
}