using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class NetworkManager : MonoBehaviour
{
    
   [System.Serializable]
    public struct profileStruct
    {
        public string nombreJSON, pass;
    }

    public profileStruct datosProfile;

    [System.Serializable]
    public struct listStruct
    {
        public List<profileStruct> data;
    }
    public listStruct allProfile;


    [SerializeField] bool usuarioLibre;
    public TMP_Text hint;


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
   

    [ContextMenu("CREAR USUARIO")]
    public void EscribirArrayJSON()
    {
        usuarioLibre = true;
        StartCoroutine(CO_LeerArrayJSON());
        Debug.Log("LeoArray");

        if (allProfile.data.Count != 0)
        {
            for (int i = 0; i < allProfile.data.Count; i++)
            {
                if (allProfile.data[i].nombreJSON == datosProfile.nombreJSON)
                {
                    usuarioLibre = false;
                    hint.text = "Selecciona otro Nombre de Usuario. " + datosProfile.nombreJSON + "no está disponible";
                    Debug.Log("Usuario Ya Existe en " + i);
                }
            }

            if (usuarioLibre)
            {
                allProfile.data.Add(datosProfile);
                Debug.Log("Añado mi perfil a la lista existente");
                StartCoroutine(CO_EscribirArrayJSON());
                Debug.Log("Escribo la lista en el servidor");
                hint.text = "Usuario CREADO correctamente" + datosProfile.nombreJSON;
            }
        }
        else { Debug.Log("Haz click de nuevo"); hint.text = "Prueba de Nuevo. Siempre falla a la primera"; }

    }


    private IEnumerator CO_EscribirArrayJSON()
    {
        WWWForm form = new WWWForm();
        form.AddField("archivo", "pruebaJSON.txt");
        form.AddField("texto", JsonUtility.ToJson(allProfile));

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
    [ContextMenu("LeerArrayJSON")]
    public void LeerArrayJSON()
    {
        StartCoroutine(CO_LeerArrayJSON());
    }



    private IEnumerator CO_LeerArrayJSON()
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
            allProfile = JsonUtility.FromJson<listStruct>(web.downloadHandler.text);
            Debug.Log(allProfile.data.Count);
        }

    }

    [ContextMenu("IniciarSesión")]
    public void IniciarSesion()
    {
        StartCoroutine(CO_IniciarSesion());
    }



    private IEnumerator CO_IniciarSesion()
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
            allProfile = JsonUtility.FromJson<listStruct>(web.downloadHandler.text);
            Debug.Log(allProfile.data.Count);
        }

    }


}
