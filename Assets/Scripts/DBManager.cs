using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{

    public static int cont = 0;

    //Variables para guardar en la BD
    DatabaseReference reference;
    private string DATA_URL = "https://puzzlepieces-f1307.firebaseio.com/";
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATA_URL);
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        InicializarFirebase();

    }

    public void InicializarFirebase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

    }



    public void LoadDataUser(string name, string password, string realName, string cedula, string genero, int edad)
    {
        cont = 0;

        FirebaseDatabase.DefaultInstance
       .GetReference("users")
       .GetValueAsync().ContinueWith(task =>
       {
           if (task.IsFaulted)
           {
              // Handle the error...
          }
           else if (task.IsCompleted)
           {

               Debug.Log("task Completed");
               DataSnapshot snapshotData = task.Result;
               string playerData = snapshotData.GetRawJsonValue();


               foreach (var child in snapshotData.Children)
               {
                   string t = child.GetRawJsonValue();
                   User extractedData = JsonUtility.FromJson<User>(t);
                   cont++;
               }

               writeNewUser("user_" + cont.ToString(), name, password, realName, cedula, genero, edad);
           }
       });

    }

    public void LoadDataPartidas(string id_user, string puzzle, string dificultad, int aciertos, int errores, int intruciones, int tiempo)
    {
        cont = 0;

        FirebaseDatabase.DefaultInstance
       .GetReference("partidas")
       .GetValueAsync().ContinueWith(task =>
       {
           if (task.IsFaulted)
           {
               // Handle the error...
           }
           else if (task.IsCompleted)
           {

               Debug.Log("task Completed");
               DataSnapshot snapshotData = task.Result;
               string playerData = snapshotData.GetRawJsonValue();


               foreach (var child in snapshotData.Children)
               {
                   string t = child.GetRawJsonValue();
                   User extractedData = JsonUtility.FromJson<User>(t);
                   cont++;
               }

               print("Cont = " + cont);
               writeNewPartida("partida_" + cont.ToString(), id_user, puzzle, dificultad, aciertos, errores, intruciones, tiempo);
           }
       });

    }



    public void BtnGuardarUsuarioNuevo(string name, string password, string realName, string cedula, string genero, int edad)
    {
        LoadDataUser(name, password, realName, cedula, genero,edad);
    }



    private void writeNewUser(string userId, string name, string password, string realName, string cedula, string genero, int edad)
    {
        User user = new User(name, password, realName, cedula, genero, edad);
        string json = JsonUtility.ToJson(user);

        //Va a asignar primary el userId
        reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }




    public void BtnGuardarPartidaNueva(string id_user, string puzzle, string dificultad, int aciertos, int errores, int intruciones, int tiempo)
    {
        LoadDataPartidas(id_user, puzzle, dificultad, aciertos, errores, intruciones, tiempo);
    }




    public void writeNewPartida(string id_partida, string id_user, string puzzle, string dificultad, int aciertos, int errores, int intruciones, int tiempo)
    {

        Partida partida = new Partida(id_user, puzzle, dificultad, aciertos, errores, intruciones, tiempo);
        string json = JsonUtility.ToJson(partida);

        //Va a asignar el userId
        reference.Child("partidas").Child(id_partida).SetRawJsonValueAsync(json);
    }





    //BUSQUEDA POR PRIMARY KEY
    public void LoadSpecificData(string userID)
    {
        //FirebaseDatabase.DefaultInstance
        //.GetReference("users")
        //.ValueChanged += HandleValueChanged;

        FirebaseDatabase.DefaultInstance
       .GetReference("users").Child(userID)
       .GetValueAsync().ContinueWith(task =>
       {
           if (task.IsFaulted)
           {
            // Handle the error...
        }
           else if (task.IsCompleted)
           {

               Debug.Log("task Completed");
               DataSnapshot snapshotData = task.Result;
               string playerData = snapshotData.GetRawJsonValue();



               User extractedData = JsonUtility.FromJson<User>(playerData);
               print("The player name is: " + extractedData.username);
               print("The player cedula is: " + extractedData.cedula);

           }
       });

        // BUSQUEDA ESPECIFICA
        //  FirebaseDatabase.DefaultInstance
        //.GetReference("users").OrderByChild("cedula").EqualTo("1720015773")
        //.GetValueAsync().ContinueWith(task =>
        //{
        //    if (task.IsFaulted)
        //    {
        //        // Handle the error...
        //    }
        //    else if (task.IsCompleted)
        //    {

        //        Debug.Log("task Completed");
        //        DataSnapshot snapshotData = task.Result;
        //        string playerData = snapshotData.GetRawJsonValue();


        //        foreach (var child in snapshotData.Children)
        //        {
        //            string t = child.GetRawJsonValue();
        //            User extractedData = JsonUtility.FromJson<User>(t);
        //            print("The player name is: " + extractedData.username);
        //            print("The player email is: " + extractedData.email);
        //            print("The player cedula is: " + extractedData.cedula);
        //        }
        //    }
        //});

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        var livingRoomItems = args.Snapshot.Value as Dictionary<string, object>;
        foreach (var item in livingRoomItems)
        {
            Debug.Log(item.Key); // Kdq6...
            var values = item.Value as Dictionary<string, object>;
            foreach (var v in values)
            {
                Debug.Log(v.Key + ":" + v.Value); // category:livingroom, code:126 ...
            }
        }
    }

    public void BtnCargar()
    {
        //LoadData();
    }

    public void BtnCargarSpecific()
    {
        LoadSpecificData("user_1720015773");
        //HandleValueChanged();
    }

}