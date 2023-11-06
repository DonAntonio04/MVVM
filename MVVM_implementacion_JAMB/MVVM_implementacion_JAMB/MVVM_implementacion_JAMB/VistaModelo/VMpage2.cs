using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MVVM_implementacion_JAMB.Modelo;


namespace MVVM_implementacion_JAMB.VistaModelo
{
    public class VMpage2 : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Musuarios> listausuario { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMpage2(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarusuarios();
        }
        #endregion
        #region OBJETOS
        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
            
        }
        public void Mostrarusuarios()
        {
            listausuario = new List<Musuarios>
            {
                new Musuarios
                {
                    Nombre="Perro",
                    Imagen= "https://i.ibb.co/3mz5rcj/perro.png"
                },

                new Musuarios
                {
                    Nombre="Hombre Araña",
                    Imagen="https://i.ibb.co/tmfr5NN/hombre-arana.png"
                },

                new Musuarios
                {
                    Nombre="DeadPool",
                    Imagen="https://i.ibb.co/cvYTD2F/superheroe.png"
                }
            };
        }
        public async Task Alerta(Musuarios parametros)
        {
            await DisplayAlert("Titulo", parametros.Nombre, "OK");
        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        // public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand Alertacommand => new Command<Musuarios>(async (p) => await Alerta(p));
        #endregion

    }
}
