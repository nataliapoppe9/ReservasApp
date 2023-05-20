using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
   
    [ContextMenu("LeerSimple")]
    public void LeerSimple()
    {
        StartCoroutine(CO_Leer());
    }

    private IEnumerator CO_Leer()
    {
        UnityWebRequest web = UnityWebRequest.Get("https://personaldosis.xyz/Reservas/pruebaTutorial.txt");
        yield return web.SendWebRequest();
        //esperamos a que vuelva y cuando llega debug
        // si llega

        if (web.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(web.error);
        }
        else
        {
            Debug.Log(web.downloadHandler.text);
        }       

    }

    [ContextMenu("EscribirSimple")]
    public void EscribirSimple()
    {
        StartCoroutine(CO_EscribirSimple());
    }


    private IEnumerator CO_EscribirSimple()
    {
        WWWForm form = new WWWForm();
        form.AddField("archivo", "pruebaTutorial.txt");
        form.AddField("texto", "Hola! Escribo en BaseDatos desde Unity!");

        UnityWebRequest web = UnityWebRequest.Post("https://personaldosis.xyz/Reservas/escribir.php",form);
        yield return web.SendWebRequest();
        //esperamos a que vuelva y cuando llega debug
        // si llega

        if (web.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(web.error);
        }
        else
        {
            Debug.Log(web.downloadHandler.text);
        }

    }


    public void CreateUser(string username, string pass, Action<string> response)
    {

    }

    /*en corrutina para esperar a que el servidor responda
    private IEnumerator CO_CreateUser(string userName, string pass,Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("pass", pass);

        WWW W = new WWW("http://localhost/Reservas/createUser.php", form);

        yield return W;

    }
    */
  
}

public class Response
{
    public bool done = false;
    public string message = "";
}
