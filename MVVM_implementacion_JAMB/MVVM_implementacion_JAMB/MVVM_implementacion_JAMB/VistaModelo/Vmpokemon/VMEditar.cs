using MVVM_implementacion_JAMB.Datos;
using MVVM_implementacion_JAMB.Modelo;
using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM_implementacion_JAMB.VistaModelo.Vmpokemon
{
    public class VMEditar : BaseViewModel
    {
        Mpokemon _Seleccionapokemon;
        #region VARIABLES
        string _Nombre;
        string _Colorfondo;
        string _Colorpoder;
        string _Icono;
        string _NroOrden;
        string _Poder;
  
        #endregion
        #region CONSTRUCTOR
        public VMEditar(Mpokemon pokemonSeleccionado,INavigation navigation)
        {
            Navigation = navigation;
            _Colorfondo = pokemonSeleccionado.Colorfondo.ToString();
            _Colorpoder = pokemonSeleccionado.Colorpoder.ToString();
            _Icono = pokemonSeleccionado.Icono.ToString();
            _Nombre = pokemonSeleccionado.Nombre.ToString();
            _NroOrden = pokemonSeleccionado.NroOrden.ToString();
            _Poder = pokemonSeleccionado.Poder.ToString();
            _Seleccionapokemon = pokemonSeleccionado;
        }

       
        #endregion
        #region OBJETOS
        public string Colorfondo
        {
            get { return _Colorfondo; }
            set { SetValue(ref _Colorfondo, value); }
        }
        public string Colorpoder
        {
            get { return _Colorpoder; }
            set { SetValue(ref _Colorpoder, value); }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
        public string NroOrden
        {
            get { return _NroOrden; }
            set { SetValue(ref _NroOrden, value); }
        }
        public string Poder
        {
            get { return _Poder; }
            set { SetValue(ref _Poder, value); }
        }
        public string Icono
        {
            get { return _Icono; }
            set { SetValue(ref _Icono, value); }
        }

        
        public Mpokemon PokemonSeleccionado
        {
            get { return _Seleccionapokemon; }
            set { SetValue(ref _Seleccionapokemon, value); }
        }
        #endregion

        public async Task ModificarPokemon()
        {
            var funcion = new Dpokemon();
            PokemonSeleccionado.Nombre = Nombre;
            PokemonSeleccionado.Poder = Poder;
            PokemonSeleccionado.NroOrden = NroOrden;
            PokemonSeleccionado.Icono = Icono;
            PokemonSeleccionado.Colorfondo = Colorfondo;
           PokemonSeleccionado.Colorpoder = Colorpoder;
            await funcion.Editarpokemon(PokemonSeleccionado);
            await Volver();
        }
        public async Task EliminarPokemon()
        {
            var funcion = new Dpokemon();
            await funcion.Borrarpokemon(PokemonSeleccionado.IdPokemon);
            await DisplayAlert("Eliminado", $"El Pókemon {PokemonSeleccionado.Nombre} eliminado", "OK");
            await Volver();
        }

        #region PROCESOSO
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
       
        
        #endregion
        #region COMANDOS
       
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ModificarPokemoncomand => new Command(async () => await ModificarPokemon());
        public ICommand EliminarPokemoncomand => new Command(async () => await EliminarPokemon());
    
     
        #endregion


    }
}
