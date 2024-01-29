using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;

using SeguimientoEjercicios.ViewModels;

namespace SeguimientoEjercicios.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new VMLogin(Navigation);
        }
        //private void OnRegisterButtonClicked(object sender, EventArgs e)
        //{
        ////    // Obtén el correo electrónico y la contraseña del usuario.
        ////    string email = txtEmail.Text;
        ////    string password = txtPassword.Text;

        ////    // Crea un nuevo usuario en Firebase.
        ////    FirebaseAuth.Auth.CreateUserWithEmailAndPassword(email, password);

        ////    // Muestra un mensaje de confirmación al usuario.
        ////    DisplayAlert("Registro exitoso", "El usuario se ha registrado correctamente", "Aceptar");
        ////}
    }

}