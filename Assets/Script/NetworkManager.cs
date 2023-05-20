using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    
    [SerializeField] string inputUser;
    [SerializeField] string inputPassword;
    [SerializeField] string nombre, pass;
    [System.Serializable]
    public struct ProfileStruct
    {
        public string nombreJSON, pass;
    }

    public ProfileStruct datosProfile;

    public void ReadStringInputUser(string s)
    {
        datosProfile.nombreJSON = s;
        Debug.Log(datosProfile.nombreJSON);
    }
    public void ReadStringInputPass(string s)
    {
        datosProfile.pass = s;
        Debug.Log(datosProfile.pass);
    }

    [ContextMenu("EscribirJSON")]
    public void EscribirJSON()
    {
        StartCoroutine(CO_EscribirJSON());
    }


    private IEnumerator CO_EscribirJSON()
    {
        WWWForm form = new WWWForm();
        form.AddField("archivo", "pruebaJSON.txt");
        form.AddField("texto", JsonUtility.ToJson(datosProfile));

        UnityWebRequest web = UnityWebRequest.Post("https://personaldosis.xyz/Reservas/escribir.php", form);
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

    [ContextMenu("LeerJSON")]
    public void LeerJSON()
    {
        StartCoroutine(CO_LeerJSON());
    }

    private IEnumerator CO_LeerJSON()
    {
        UnityWebRequest web = UnityWebRequest.Get("https://personaldosis.xyz/Reservas/pruebaJSON.txt");
        yield return web.SendWebRequest();
        //esperamos a que vuelva y cuando llega debug
        // si llega

        if (web.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(web.error);
        }
        else
        {
            datosProfile = JsonUtility.FromJson<ProfileStruct>(web.downloadHandler.text);
            
        }

    }


    [ContextMenu("LeerSimple")]
    public void LeerSimple()
    {
        StartCoroutine(CO_Leer());
    }

    private IEnumerator CO_Leer()
    {
        UnityWebRequest web = UnityWebRequest.Get("https://personaldosis.xyz/Reservas/pruebaSinJSON.txt");
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

    [ContextMenu("EscribirSinJSON")]
    public void EscribirSinJSON()
    {
        StartCoroutine(CO_EscribirSinJSON());
    }


    private IEnumerator CO_EscribirSinJSON()
    {
        WWWForm form = new WWWForm();
        form.AddField("archivo", "pruebaSinJSON.txt");
        form.AddField("texto", inputUser+"☺"+inputPassword);

        UnityWebRequest web = UnityWebRequest.Post("https://personaldosis.xyz/Reservas/escribir.php", form);
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

    public void LeerSinJSON()
    {
        StartCoroutine(CO_LeerSINJSON());
    }

    private IEnumerator CO_LeerSINJSON()
    {
        UnityWebRequest web = UnityWebRequest.Get("https://personaldosis.xyz/Reservas/pruebaSinJSON.txt");
        yield return web.SendWebRequest();
        //esperamos a que vuelva y cuando llega debug
        // si llega

        if (web.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(web.error);
        }
        else
        {
           string textoOriginal = web.downloadHandler.text;
           string[] partes = textoOriginal.Split('☺');
           nombre = partes[0];
           pass = partes[1];
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
