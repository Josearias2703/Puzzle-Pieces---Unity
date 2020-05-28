using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    //Definicion variables para authentication

    private string displayName;
    public InputField inputFieldEmail;
    public InputField inputFieldPassword;

    public GameObject panelMenuPrincipal;
    public GameObject panelMenuLogIn;
    public GameObject panelRegistro;
    public GameObject txtMensageError;
    public GameObject txtMensageError2;
    public Dropdown dropDownGenero;
    public GameObject txtErrorEspacios;
    public GameObject txtErrorContrasena;
    public GameObject txtErrorEdad;
    public GameObject txtErrorCedula;

    private bool signedIn = false;
    private bool mensajeError = false;
    private bool registeredIn = false;
    private bool changeSesion = false;


    public InputField inputFieldNombreReal;
    public InputField inputFieldCedula;
    public InputField inputFieldEdad;
    public InputField inputFieldUsername;
    public InputField inputFieldContrasena;
    public InputField inputFieldContrasena2;

    List<string> genero = new List<string>() { "Seleccione Genero", "Hombre", "Mujer", "Otro"};
    public string obtenerGenero = "Seleccione Genero";

    // Update is called once per frame
    void Update()
    {
        if (signedIn)
        {
            panelMenuPrincipal.SetActive(true);
            panelMenuLogIn.SetActive(false);
            inputFieldEmail.text = "";
            inputFieldPassword.text = "";
            signedIn = false;

        }

        if(mensajeError)
        {
            inputFieldEmail.text = "";
            inputFieldPassword.text = "";
            txtMensageError2.SetActive(true);
            StartCoroutine(borrarMensajeError(5));
            mensajeError = false;
        }

        if(registeredIn)
        {
            inputFieldNombreReal.text = "";
            inputFieldCedula.text = "";
            inputFieldEdad.text = "";
            inputFieldUsername.text = "";
            inputFieldContrasena.text = "";
            inputFieldContrasena2.text = "";
            
            panelRegistro.SetActive(false);
            panelMenuLogIn.SetActive(true);
            registeredIn = false;
        }

        if (changeSesion)
        {
            
            panelMenuPrincipal.SetActive(false);
            panelMenuLogIn.SetActive(true);
            changeSesion = false;
        }


    }

    public void LoginUser()
    {
        if (inputFieldEmail.text != "" && inputFieldPassword.text != "")
        {
            string email = inputFieldEmail.text;    //email es el nombre de usuario
            string password = inputFieldPassword.text;

            FirebaseDatabase.DefaultInstance
           .GetReference("users").OrderByChild("username").EqualTo(email)
           .GetValueAsync().ContinueWith(task =>
           {
               if (task.IsFaulted)
               {
                   Debug.Log("No ID registered on DB");
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
                       print("The player name is: " + extractedData.username);
                       print("The player cedula is: " + extractedData.cedula);

                       if ((extractedData.cedula.Equals(email)||extractedData.username.Equals(email)) && extractedData.password.Equals(password))
                       {
                           signedIn = true;
                           Debug.Log("Login Successful");
                          // dontDestroy.cedulaUsuario = extractedData.cedula;
                           dontDestroy.userName = extractedData.username;
                           dontDestroy.cedulaUsuario = child.Key.ToString();

                           print(" Prueba de Usuario: " + dontDestroy.cedulaUsuario);

                       }
                       else
                       {
                           mensajeError = true;
                           Debug.Log("Wrong password or email");
                       }
                   }

               }
           });

            if(!mensajeError)
            {
                mensajeError = true;
            }

        }
        else
        {
            txtMensageError.SetActive(true);
            StartCoroutine(borrarMensajeError(5));                                             //Reparte Bajara

        }

    }

    IEnumerator borrarMensajeError(float time)
    {
        yield return new WaitForSeconds(time);
        txtMensageError2.SetActive(false);
        txtMensageError.SetActive(false);
        txtErrorEspacios.SetActive(false);
        txtErrorEdad.SetActive(false);
        txtErrorCedula.SetActive(false);
        txtErrorContrasena.SetActive(false);

    }

    public void obtenerDropDownText(int index)
    {
        obtenerGenero = genero[index];
    }

    public void btnRegistrar()
    {
        txtErrorEspacios.SetActive(false);
        txtErrorEdad.SetActive(false);
        txtErrorCedula.SetActive(false);
        txtErrorContrasena.SetActive(false);

        if (inputFieldNombreReal.text != "" && inputFieldCedula.text != "" && inputFieldEdad.text != "" &&
            inputFieldUsername.text != "" && inputFieldContrasena.text != "" && inputFieldContrasena2.text != "" && (obtenerGenero != "Seleccione Genero" && obtenerGenero != ""))
        {
            int i = 0;
            if(inputFieldContrasena.text == inputFieldContrasena2.text)
            {
                i++;   
            }
            else
            {
                txtErrorContrasena.SetActive(true);
                StartCoroutine(borrarMensajeError(5));
            }
            if (inputFieldCedula.text.Length == 10)
            {
                i++;
            }
            else
            {
                txtErrorCedula.SetActive(true);
                StartCoroutine(borrarMensajeError(5));
            }
            if(int.Parse(inputFieldEdad.text)>0)
            {
                i++;
            }
            else
            {
                txtErrorEdad.SetActive(true);
                StartCoroutine(borrarMensajeError(5));
            }

            if(i == 3)
            {
                
                    print("Registro Exitoso");
                    FindObjectOfType<DBManager>().BtnGuardarUsuarioNuevo(inputFieldUsername.text, inputFieldContrasena.text, inputFieldNombreReal.text
                        , inputFieldCedula.text, obtenerGenero, int.Parse(inputFieldEdad.text));
                    registeredIn = true;
               
            }
        }
        else
        {
            txtErrorEspacios.SetActive(true);
            StartCoroutine(borrarMensajeError(5));
        }
    }

    public void btnAtrasRegistro()
    {
        registeredIn = true;
    }

    public void btnCambiarSesion()
    {
        txtMensageError2.SetActive(false);
        changeSesion = true;
        dontDestroy.cedulaUsuario = "";
        dontDestroy.userName = "";
    }

}

