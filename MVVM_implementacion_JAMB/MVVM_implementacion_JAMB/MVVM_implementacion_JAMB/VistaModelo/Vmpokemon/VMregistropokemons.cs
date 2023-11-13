using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM_implementacion_JAMB.VistaModelo.Vmpokemon
{
      public class VMregistropokemons : BaseViewModel
    {
        
            #region VARIABLES
             string _Txtcolorfondo;
             string _Txtcolorpoder;
             string _Txtnombre;
             string _Txtnro;
             string _Txtpoder;
             string _Txticono;
        #endregion
        #region CONSTRUCTOR
        public VMregistropokemons(INavigation navigation)
            {
             Navigation = navigation;
            }
        #endregion
        #region OBJETOS
        public string Txtcolorfondo
            {
               get { return _Txtcolorfondo; }
                set { SetValue(ref _Txtcolorfondo, value); }
            }
        public string Txtcolorpoder
        {
            get { return _Txtcolorpoder; }
            set { SetValue(ref _Txtcolorpoder, value); }
        }
        public string Txtnombre
        {
            get { return _Txtnombre; }
            set { SetValue(ref _Txtnombre, value); }
        }
        public string Txtnro
        {
            get { return _Txtnro; }
            set { SetValue(ref _Txtnro, value); }
        }
        public string Txtpoder
        {
            get { return _Txtpoder; }
            set { SetValue(ref _Txtpoder, value); }
        }
        public string Txticono
        {
            get { return _Txticono; }
            set { SetValue(ref _Txticono, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
            {

            }
            public void ProcesoSimple()
            {

            }
            #endregion
            #region COMANDOS
            public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
            public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
            #endregion
        
    }
}
