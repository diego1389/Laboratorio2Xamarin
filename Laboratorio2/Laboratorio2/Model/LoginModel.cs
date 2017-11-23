using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio2.Model
{
    public class LoginModel
    {

        public string Usuario { get; set; }
        public string Password { get; set; }

        public LoginModel()
        {
          
        }

        public static List<LoginModel> ObtenerUsuarios()
        {
            var listaUsuarios = new List<LoginModel>()
            {
                new LoginModel(){Usuario = "dguillen", Password="1234"},
                new LoginModel(){Usuario = "cpiedra", Password="c456"}
            };

            return listaUsuarios;
        }


     

    }
}
