using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeerSimple()
    {
        StartCoroutine(CO_Leer());
    }

    private IEnumerator CO_Leer()
    {
        UnityWebRequest web = UnityWebRequest.Get("https://personaldosis.xyz/Reservas/BaseDatos.txt");
        yield return web.SendWebRequest();
        //esperamos a que vuelva y cuando llega debug
        Debug.Log(web.downloadHandler.text);

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
