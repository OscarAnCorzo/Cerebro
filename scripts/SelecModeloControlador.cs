using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecModeloControlador : MonoBehaviour
{
    public float minDistancia = 5f;
    public float velocidad = 5f;
    private SelecModelo highlightObject;
    private Camera camara;
    public float valorInicialFOV;

    private void Awake()
    {
        camara = FindObjectOfType<Camera>();
        valorInicialFOV = camara.fieldOfView;
    }

    public void SelectObject(SelecModelo highlightObject)
    {
        if(this.highlightObject != null && this.highlightObject != highlightObject)
        {
            this.highlightObject.DetenerResaltar();
        }

        this.highlightObject = highlightObject;
        this.highlightObject.ComenzarResaltar();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.highlightObject.transform.Rotate(1f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {

            this.highlightObject.transform.Rotate(-1f, 0f, 0f);
        }


        if (Input.GetKey(KeyCode.A))
        {
            this.highlightObject.transform.Rotate(0f, 0f, 1f);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            this.highlightObject.transform.Rotate(0f, 0f, -1f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.highlightObject.transform.Rotate(0f, 1f, 0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            this.highlightObject.transform.Rotate(0f, -1f, 0f);
        }


        if (Input.GetKeyDown("up"))
        {
            Debug.Log(this.valorInicialFOV);
            camara.fieldOfView -= velocidad;
        }
        if (Input.GetKeyDown("down"))
        {
            Debug.Log(this.valorInicialFOV);
            camara.fieldOfView += velocidad;
        }
    }


   
}
