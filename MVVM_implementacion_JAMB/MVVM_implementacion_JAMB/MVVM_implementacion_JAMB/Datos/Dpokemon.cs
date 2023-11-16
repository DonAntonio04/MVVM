using Firebase.Database;
using Firebase.Database.Query;
using MVVM_implementacion_JAMB.Conexion;
using MVVM_implementacion_JAMB.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM_implementacion_JAMB.Datos
{
     public class Dpokemon
    {
        public async Task Insertarpokemon(Mpokemon parametros)
        {
            await Cconexion.firebase
                .Child("Pokemon")
                .PostAsync(new Mpokemon()
                {
                    Colorfondo = parametros.Colorfondo,
                    Colorpoder = parametros.Colorpoder,
                    Icono = parametros.Icono,
                    Nombre = parametros.Nombre,
                    NroOrden = parametros.NroOrden,
                    Poder = parametros.Poder,
                
                }
                );
        }
        public async Task<ObservableCollection<Mpokemon>> MostrarPokemon()
        {
            //return (await Cconexion.firebase
            //    .Child("Pokemon")
            //    .OnceAsync<Mpokemon>())
            //    .Select(item => new Mpokemon
            //    {
            //        Idpokemon = item.Key,
            //        Nombre = item.Object.Nombre,
            //        Colorfondo = item.Object.Colorfondo,
            //        Colorpoder = item.Object.Colorpoder,
            //        Icono = item.Object.Icono,
            //        NroOrden = item.Object.NroOrden,
            //        Poder = item.Object.Poder
            //    }).ToList();
            var data = await Task.Run(() => Cconexion.firebase
            .Child("Pokemon")
            .AsObservable<Mpokemon>()
            .AsObservableCollection());
            return data;
        }
    }
}
