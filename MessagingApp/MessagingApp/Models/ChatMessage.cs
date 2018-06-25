using MessagingApp.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MessagingApp.Models
{
    public class ChatMessage : ModelBase
    {

        private User _author;

        public int Id { get; set; }
        public User Author
        { 
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged("Author");
                //SetTextSettings();
            }
        }
        public string Message { get; set; }
        
        public TextAlignment  TextAlignment { get; set; }
        public Color TextColor { get; set; }

        public void SetTextSettings()
        {
            if (Author.Username == MessageManager.Instance.currentUser.Username)
            {
                TextAlignment = TextAlignment.End;
                TextColor = Color.Blue;
            }
            else
            {
                TextAlignment = TextAlignment.Start;
                TextColor = Color.Green;
            }
        }
    }
}