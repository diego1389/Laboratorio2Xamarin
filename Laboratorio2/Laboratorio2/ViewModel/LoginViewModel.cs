using Laboratorio2.Model;
using Laboratorio2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratorio2.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _usuario;
        private string _password;
        private string _infoLogin;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Usuario
        {
            get { return _usuario; }
            set {
                _usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        public string InfoLogin
        {
            get { return _infoLogin; }
            set
            {
                _infoLogin = value;
                OnPropertyChanged("InfoLogin");
            }
        }

        public ICommand LoginCommand { get; set; }


        public LoginViewModel()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            LoginCommand = new Command(Login);
        }

        public void Login()
        {
            string usuario = Usuario;
            string password = Password;

            if (Login(usuario, password))         
                NavigateToMasterDetailPage();               
            else
                InfoLogin = "Usuario o contraseña incorrectos";      
        }

        public bool Login(string usuario, string password)
        {
            var listaUsuarios = LoginModel.ObtenerUsuarios();
            return listaUsuarios.Exists(u => u.Usuario == usuario && u.Password == password);
        }

        public void NavigateToMasterDetailPage()
        {
            NavigationPage navigation = new NavigationPage(new People());

            App.Current.MainPage = new MasterDetailPage
            {
                Master = new HomeMenu(),
                Detail = navigation
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
