using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Profile : MonoBehaviour
{
    public TMP_InputField userProfile, passwordProfile, emailProfile, phoneProfile;
    User currentUser;
    public void ShowProfileInfo()
    {
        currentUser = UserManager.instanceUserManager.currentUser;
        userProfile.text = currentUser.user;
        emailProfile.text = currentUser.email;
        phoneProfile.text = currentUser.tlf;
    }

    public void SignOut()
    {
        PlayerPrefs.SetString("user", null);
        PlayerPrefs.SetString("password", null);
        //desactivo el panel con info
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);

    }

    public void EditUser()
    {
        if (userProfile.text == "")
        {
           UserManager.instanceUserManager.ShowError("Usuario incorrecto.", " Introduce un nombre");
            return;
        }
        if (passwordProfile.text.Length < 9)
        {
            UserManager.instanceUserManager.ShowError("Contrase�a erronea", " La contrase�a debe tener m�nimo 9 caracteres");
            return;
        }
        if (!emailProfile.text.Contains("@") || !emailProfile.text.Contains("."))
        {
            UserManager.instanceUserManager.ShowError("Email erroneo.", "Introduce un email correcto");
            return;
        }
        if (phoneProfile.text.Length < 6)
        {
            UserManager.instanceUserManager.ShowError("Telefono erreoneo", "Introduce un n�mero con al menos 6 d�gitos");
            return;
        }

        currentUser.user = userProfile.text;
        currentUser.password = passwordProfile.text;
        currentUser.email = emailProfile.text;
        currentUser.tlf = phoneProfile.text;

        //Hay que guardarlo en User de UserManager y en el user[id] de dataBase de UserManager
        UserManager.instanceUserManager.currentUser = currentUser;
        UserManager.instanceUserManager.dataBase.users[UserManager.instanceUserManager.id] = currentUser;

    }
}
