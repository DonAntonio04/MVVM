
using MVVM_implementacion_JAMB.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Menuprincipal = MVVM_implementacion_JAMB.Modelo.Menuprincipal;

namespace MVVM_implementacion_JAMB.VistaModelo
{
    public class VMmenuprincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Menuprincipal> listapaginas { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarpaginas();
        }
        #endregion
        #region OBJETOS
        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();

        }
        public void Mostrarpaginas()
        {
            listapaginas = new List<Menuprincipal>
            {
                new Menuprincipal
                {
                     Pagina="Entry,datepicker, picker,label, navegacion",
                    Icono= "https://i.ibb.co/168krRf/188987.png"
                },

                new Menuprincipal
                {
                        Pagina="CollectionView sin enlace a base de datos",
                        Icono="https://i.ibb.co/wMMwSMh/188990.png"
                },

                new Menuprincipal
                {
                    Pagina="Crud pokemon",
                    Icono="https://i.ibb.co/ynrTTsw/189001.png"
                }
            };
        }
        public async Task Navegar(Menuprincipal parametros)
        {
            string pagina;
            pagina = parametros.Pagina;
            if (pagina.Contains("Entry, DataPicker"))
            {
                await Navigation.PushAsync(new Pagina1());
            }
            if (pagina.Contains("CollectionView sin enlace"))
            {
                await Navigation.PushAsync(new Page2());
            }
            if (pagina.Contains("Crud Pokémon"))
            {
                await Navigation.PushAsync(new Crudpokemon());
            }
        }
        #endregion
        #region COMANDOS
        //public ICommand Volvercommand => new Command(async () => await Volver());
        // public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);

        public ICommand Navegarcommand => new Command<Menuprincipal>(async (p) => await Navegar(p));

        #endregion

    }
}

