using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_implementacion_JAMB.Conexion
{
     public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mvvmjamb-default-rtdb.firebaseio.com/");
    }
}
