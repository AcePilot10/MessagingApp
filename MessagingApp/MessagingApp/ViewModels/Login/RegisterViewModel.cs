using MessagingApp.Managers;
using MessagingApp.Models;
using MessagingApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MessagingApp.ViewModels
{
    public class RegisterViewModel
    {
        public ICommand RegisterCommand { get; private set; }

        public RegisterViewModel()
        {
            MessageManager.Instance.InitUsers();
            RegisterCommand = new Command<string>(x => RegisterUser(x));
        }

        public void RegisterUser(string username)
        {
            User user = new User()
            {
                Username = username
            };
            MessageManager.Instance.LoginUser(user);  
        }
    }
}