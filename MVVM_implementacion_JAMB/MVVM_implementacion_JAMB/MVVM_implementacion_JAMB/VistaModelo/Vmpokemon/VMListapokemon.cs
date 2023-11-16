using MVVM_implementacion_JAMB.Datos;
using MVVM_implementacion_JAMB.Modelo;
using MVVM_implementacion_JAMB.Vistas.Pokemon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM_implementacion_JAMB.VistaModelo.Vmpokemon
{
    internal class VMListapokemon : BaseViewModel
    {
       
             #region VARIABLES
             string _Texto;
              ObservableCollection<Mpokemon> _Listapokemon;
             #endregion
             #region CONSTRUCTOR
            public VMListapokemon(INavigation navigation)
            {
            Navigation = navigation;
            Mostrarpokemon();
            }
            #endregion
            #region OBJETOS
            public ObservableCollection<Mpokemon> Listapokemon
            {
                get { return _Listapokemon; }
                set { SetValue(ref _Listapokemon, value);
                          OnpropertyChanged();
                }
            }
            #endregion
            #region PROCESOS

              public async Task Mostrarpokemon()
              {
                var funcion = new Dpokemon();
               Listapokemon= await funcion.MostrarPokemon();
              }

            public async Task Iraregistro()
            {
            await Navigation.PushAsync(new Registrarpokemon());
            }
            public void ProcesoSimple()
            {

            }
            #endregion
            #region COMANDOS
            public ICommand Iraregistrocommand => new Command(async () => await Iraregistro());
            public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
            #endregion
        
    }
}
