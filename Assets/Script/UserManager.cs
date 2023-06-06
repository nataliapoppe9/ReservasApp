using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserManager : MonoBehaviour
{
    public static UserManager instanceUserManager;
    [Header("DATABASE")]
    public DataBaseScript dataBase;
    public User currentUser;
    public int id;

    [Header("REGISTER")]
    public TMP_InputField usernameInput; 
    public TMP_InputField passwordInput, emailInput, phoneInput;
    public GameObject popUp;
    public GameObject registerPannel;
   
    [Header("SIGNIN")]
    public TMP_InputField userSignIn;
    public TMP_InputField passwordSignIn;
    public GameObject panelMain;

    private void Start()
    {
        instanceUserManager = this;
        if (PlayerPrefs.GetString("user") != null)
        {
            userSignIn.text = PlayerPrefs.GetString("user");
            passwordSignIn.text = PlayerPrefs.GetString("password");
            SignIn();
        }
    }
    public void SignIn()
    {
        for(int i=0;i< dataBase.users.Count ; i++)
        {
            if(dataBase.users[i].user == userSignIn.text)
            {
                if(dataBase.users[i].password == passwordSignIn.text)
                {
                    //Ususario encontrado
                    panelMain.SetActive(true);
                    currentUser = dataBase.users[i];
                    PlayerPrefs.SetString("user", dataBase.users[i].user);
                    PlayerPrefs.SetString("password", dataBase.users[i].password);
                    id = i;
                    return;
                }
                else
                {
                    ShowError("Error", "La contraseña es incorrecta");
                    return;
                }
            }
                
        }
        ShowError("Error", "Usuario No encontrado");
    }

    public void CrearUsuario()
    {
        if (usernameInput.text == "")
        {
            ShowError("Usuario incorrecto.", " Introduce un nombre");
            return;
        }
        if(passwordInput.text.Length < 9)
        {
            ShowError("Contraseña erronea", " La contraseña debe tener mínimo 9 caracteres");
            return;
        }
        if (!emailInput.text.Contains("@") || !emailInput.text.Contains("."))
        {
            ShowError("Email erroneo.","Introduce un email correcto");
            return;
        }
        if (phoneInput.text.Length < 6)
        {
            ShowError("Telefono erreoneo", "Introduce un número con al menos 6 dígitos");
            return;
        }
        ShowError("Usuario Creado", "Felicidades");
        dataBase.users.Add(
            new User(usernameInput.text, passwordInput.text, phoneInput.text, emailInput.text));
       

    }

    public void ShowError(string title, string error)
    {
        popUp.SetActive(true);
        popUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = title;
        popUp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = error;
    }
   
}
