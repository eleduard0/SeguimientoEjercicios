using Firebase.Auth;
using SeguimientoEjercicios.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeguimientoEjercicios.Services
{
    public class UserService
    {
        private static FirebaseAuthClient _firebaseAuth;
        private UserCredential userCredential;
        private string token;
        public static FirebaseAuthClient FirebaseAuthInstance
        {
            get
            {
                if (_firebaseAuth == null)
                {
                    _firebaseAuth = new FirebaseAuthClient(FirebaseConfig.AuthConfig);
                }
                return _firebaseAuth;
            }
        }
        public async Task<bool> UserLogin(string email, string password)
        {
            try
            {
                userCredential = await FirebaseAuthInstance.SignInWithEmailAndPasswordAsync(email, password);
                var user = userCredential.User;
                token = await user.GetIdTokenAsync();
                return true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", ex.Message, "ok");
                return false;

            }
        }
        public async Task<User> GetCurrentUserAsync()
        {
            try
            {
                var user = userCredential.User;
                var uid = user.Uid;
                var name = user.Info.DisplayName;

                return user;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", ex.Message, "ok");
                return null;
            }
        }
    }
}
