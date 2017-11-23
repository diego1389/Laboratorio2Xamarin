using Laboratorio2.Model;
using Laboratorio2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratorio2.ViewModel
{
    public class PersonaViewModel : INotifyPropertyChanged
    {
        private static PersonaViewModel instance = null;

        private PersonaViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static PersonaViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PersonaViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        private List<PersonaModel> lstOriginalPersonas = new List<PersonaModel>();

        private ObservableCollection<PersonaModel> _personasList= new ObservableCollection<PersonaModel>();

        public ObservableCollection<PersonaModel> PersonasList
        {
            get
            {
                return _personasList;
            }
            set
            {
                _personasList = value;
                OnPropertyChanged("PersonasList");
            }
        }

        private string _textoBuscar = string.Empty;

        public string TextoBuscar
        {
            get
            {
                return _textoBuscar;
            }
            set
            {
                _textoBuscar = value;
                OnPropertyChanged("TextoBuscar");
                FiltrarPersona(_textoBuscar);
            }
        }

        private string _nuevaPersona = string.Empty;

        public string NuevaPersona
        {
            get
            {
                return _nuevaPersona;
            }
            set
            {
                _nuevaPersona = value;
                OnPropertyChanged("NuevaPersona");
            }
        }

        private PersonaModel _personaActual { get; set; }

        public PersonaModel PersonaActual
        {
            get
            {
                return _personaActual;
            }
            set
            {
                _personaActual = value;
                OnPropertyChanged("PersonaActual");
            }
        }


        public ICommand AgregarPersonaCommand { get; set; }
        public ICommand BorrarPersonaCommand { get; set; }
        public ICommand VerPersonaCommand { get; set; }


        private void AgregarPersona()
        {
            PersonasList.Add(new PersonaModel { Nombre = NuevaPersona });
            lstOriginalPersonas.Add(new PersonaModel { Nombre = NuevaPersona });

            NuevaPersona = string.Empty;
        }

        private void FiltrarPersona(string textoBuscar)
        {
            PersonasList.Clear();
            lstOriginalPersonas.Where(x => x.Nombre.ToLower().Contains(textoBuscar.ToLower())).ToList().ForEach(x => PersonasList.Add(x));
        }

        private void BorrarPersona(int id)
        {

            lstOriginalPersonas.RemoveAll(x => x.Id == id);

        }

        private void VerPersona(int id)
        {
            PersonaActual = lstOriginalPersonas.Where(x => x.Id == id).FirstOrDefault();

           ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new UsuarioDetalle());

        }

        private async Task InitClass()
        {

            PersonasList = await PersonaModel.ObtenerPersonas();

            lstOriginalPersonas = PersonasList.ToList();
        }

        private void InitCommands()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            BorrarPersonaCommand = new Command<int>(BorrarPersona);
            VerPersonaCommand = new Command<int>(VerPersona);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
