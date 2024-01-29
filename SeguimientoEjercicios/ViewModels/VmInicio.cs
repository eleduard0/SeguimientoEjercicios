using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeguimientoEjercicios.ViewModels
{
    public class VmInicio : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _calorias;
        string _dia1;
        string _dia2;
        string _dia3;
        string _resultado;
        #endregion
        #region CONTRUCTOR
        public VmInicio(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Calorias
        {
            get { return _calorias; }
            set { SetValue(ref _calorias, value); }
        }
        public string Dia1
        {
            get { return _dia1; }
            set { SetValue(ref _dia1, value); }
        }
        public string Dia2
        {
            get { return _dia2; }
            set { SetValue(ref _dia2, value); }
        }
        public string Dia3
        {
            get { return _dia3; }
            set { SetValue(ref _dia3, value); }
        } 
        public string Resultado
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void Calcularcalorias()
        {
            int calorias = int.Parse(Calorias);
            int kmdia1 = (int.Parse(Dia1)) * 62;
            int kmdia2 = (int.Parse(Dia2)) * 62;
            int kmdia3 = (int.Parse(Dia3)) * 62;

            if ((kmdia1 + kmdia2 + kmdia3)>calorias)
            {
                Resultado = "Alcanzaste tu meta";
            }
            else 
            {
                Resultado = "No alcanzaste tu meta";
            }

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand Calcularcaloriascommand => new Command(Calcularcalorias);
        #endregion
    }
}
