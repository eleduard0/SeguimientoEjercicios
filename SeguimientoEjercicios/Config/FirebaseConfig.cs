using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Firebase.Auth;
using Firebase.Auth.Providers;


namespace SeguimientoEjercicios.Config
{
    public static class FirebaseConfig
    {
        public static string ApiKey = "AIzaSyDYhTRDyoE8C6hBe_ivUCRTmn6ZzU9qKdc"; // API Key de Firebase
        public static string AuthDomain = "seguimientoejercicio.web.app"; // Auth Domain de Firebase
        public static FirebaseAuthProvider[] Providers = new FirebaseAuthProvider[] // Proveedores de Firebase Auth
        {
            new EmailProvider() // Proveedor de correo electrónico
        };

        // Método para obtener la configuración de Firebase Auth
        public static FirebaseAuthConfig AuthConfig => new FirebaseAuthConfig
        {
            ApiKey = ApiKey,
            AuthDomain = AuthDomain,
            Providers = Providers
        };
    }
}
