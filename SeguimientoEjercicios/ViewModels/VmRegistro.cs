using SeguimientoEjercicios.Services;
using SeguimientoEjercicios.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeguimientoEjercicios.ViewModels
{
    public class VmRegistro : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private string _email;
        private string _password;
        #endregion
        #region CONTRUCTOR
        public VmRegistro(INavigation navigation)
        {
            Navigation = navigation;
            RegisterCommand = new Command(Register);

        }
        #endregion
        #region OBJETOS
        public string Email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        public async void Register(object obj)
        {

            var userService = new UserService();
            var registerUser = await userService.Register(Email, Password);

            if (registerUser)
            {
                await Volver();

                var currentUser = await userService.GetCurrentUserAsync();
                await Application.Current.MainPage.DisplayAlert("Bienvenido", $"¡Hola {currentUser.Info.DisplayName}!", "OK");
            }


        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        #endregion
        #region COMANDOS
        public Command RegisterCommand { get; }
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
