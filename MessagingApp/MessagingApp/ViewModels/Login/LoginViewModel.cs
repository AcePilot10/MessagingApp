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
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; private set; }
        public ICommand NavigateToRegisterCommand { get; private set; }

        public LoginViewModel()
        {
            MessageManager.Instance.InitUsers();
            LoginCommand = new Command<string>(x => LoginUser(x));
            NavigateToRegisterCommand = new Command(x => Application.Current.MainPage.Navigation.PushAsync(new RegisterPage()));
        }

        public void LoginUser(string username)
        {
            User user = MessageManager.Instance.users.Find(x => x.Username == username);
            if (user != null)
            {
                MessageManager.Instance.LoginUser(user);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "That username doesn't exist!", "Try Again");
            }
        }
    }
}