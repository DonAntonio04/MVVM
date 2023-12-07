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
                    IdPokemon = Guid.NewGuid(),
                    Colorfondo = parametros.Colorfondo,
                    Colorpoder = parametros.Colorpoder,
                    Icono = parametros.Icono,
                    Nombre = parametros.Nombre,
                    NroOrden = parametros.NroOrden,
                    Poder = parametros.Poder,

                }
                );
        }
        public async Task Editarpokemon(Mpokemon nuevosDatos)
        {
            var actualizar = (await Cconexion
                .firebase.Child("Pokemon")
                .OnceAsync<Mpokemon>())
                .Where(a => a.Object.IdPokemon == nuevosDatos.IdPokemon).FirstOrDefault();

            await Cconexion.firebase
                .Child("Pokemon")
                .Child(actualizar.Key)
                .PutAsync(new Mpokemon()
                {
                    IdPokemon = nuevosDatos.IdPokemon,
                    Colorfondo = nuevosDatos.Colorfondo,
                    Colorpoder = nuevosDatos.Colorpoder,
                    NroOrden = nuevosDatos.NroOrden,
                    Icono = nuevosDatos.Icono,
                    Nombre = nuevosDatos.Nombre,
                    Poder = nuevosDatos.Poder
                });
        }
        public async Task Borrarpokemon(Guid idPokemon)
        {
            var pokemonABorrar = (await Cconexion.firebase
                .Child("Pokemon")
                .OnceAsync<Mpokemon>()).Where(a => a.Object.IdPokemon == idPokemon).FirstOrDefault();

            await Cconexion.firebase.Child("Pokemon").Child(pokemonABorrar.Key).DeleteAsync();
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

