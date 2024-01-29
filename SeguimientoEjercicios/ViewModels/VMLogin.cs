
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
        public async void OnLoginClicked(object obj)
        {
            
            var userService = new UserService(); 
            var isLoggedIn = await userService.UserLogin(Email, Password); 

            if (isLoggedIn)
            {
                await Navigation.PushAsync(new Inicio());

                var currentUser = await userService.GetCurrentUserAsync(); 
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
