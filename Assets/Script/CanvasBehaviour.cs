using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject StartCanvas,NewUserCanvas, SignInCanvas;
    

    void Start()
    {

    }

    private void Update()
    {
        
    }

    public void DesactivarObjeto(GameObject canva)
    {
        canva.SetActive(false);
    }
    public void ActivarObjeto(GameObject canva)
    {
        canva.SetActive(true);
    }

 
}
