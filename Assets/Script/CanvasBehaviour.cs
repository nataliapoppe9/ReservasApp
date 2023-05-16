using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{

    [SerializeField] GameObject StartCanvas;
    public GameObject NewUserCanvas,SignInCanvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCanvas = this.gameObject;

    }

    public void DesactivarObjeto(GameObject canva)
    {
        canva.SetActive(false);
    }
    public void ActivarObjeto(GameObject canva)
    {
        canva.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
