using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserManager : MonoBehaviour
{
    public TMP_InputField usernameInput, passwordInput, emailInput, phoneInput;
    public GameObject popUp;
    public DataBaseScript dataBase;
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
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
