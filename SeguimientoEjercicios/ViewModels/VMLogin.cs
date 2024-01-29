
using SeguimientoEjercicios.Services;
using SeguimientoEjercicios.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;



namespace SeguimientoEjercicios.ViewModels
{
    public class VMLogin : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private string _email;
        private string _password;
        #endregion
        #region CONTRUCTOR
        public VMLogin(INavigation navigation)
        {
            Navigation = navigation;
            LoginCommand = new Command(OnLoginClicked);

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
        // Método para iniciar sesión
        public async void OnLoginClicked(object obj)
        {
            // Variables para el inicio de sesión
            var userService = new UserService(); // Instancia de UserService
            var isLoggedIn = await userService.LoginAsync(Email, Password); // Llama al método LoginAsync de UserService

            // Comprueba si el inicio de sesión fue exitoso
            if (isLoggedIn)
            {
                // Si el inicio de sesión fue exitoso, muestra un mensaje de alerta y navega a la página principal
                await Navigation.PushAsync(new Inicio());

                var currentUser = await userService.GetCurrentUserAsync(); // Obtiene el usuario actual
                await Application.Current.MainPage.DisplayAlert("Bienvenido", $"¡Hola {currentUser.Info.DisplayName}!", "OK");
            }
        }

        #endregion
        #region COMANDOS
        public Command LoginCommand { get; }
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
