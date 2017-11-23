using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorio2.Model
{
    public class PersonaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FotoPath { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string Observaciones { get; set; }
        private string _nombreCompleto;
        private int _edad;

        public int Edad
        {
            get { return _edad; }
            set { _edad = DateTime.Today.Year - FechaNacimiento.Year; }
        }


        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = this.Nombre + " " + this.ApellidoPaterno + " " + this.ApellidoMaterno; }
        }

        public ObservableCollection<VentasModel> ListaVentas { get; set; }

        public static async Task<ObservableCollection<PersonaModel>> ObtenerPersonas()
        {

            ObservableCollection<PersonaModel> lstPersonas = new ObservableCollection<PersonaModel>();

            lstPersonas.Add(new PersonaModel { Id = 1, Nombre = "Carlos", Telefono="84734166" });
            lstPersonas.Add(new PersonaModel { Id = 2, Nombre = "Yendry", Telefono = "25522968" });
            lstPersonas.Add(new PersonaModel { Id = 3, Nombre = "Natasha", Telefono = "25517390" });

            Thread.Sleep(4000);


            return lstPersonas;

        }
    }
}
