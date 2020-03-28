using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecModeloControlador : MonoBehaviour
{
    public float minDistancia = 5f;
    public float maxDistancia = 80f;
    public float velocidad = 5f;
    private SelecModelo modelo;
    private Camera camara;
    public float valorInicialFOV;
    public Transform target;

    private void Awake()
    {
        camara = FindObjectOfType<Camera>();
        valorInicialFOV = camara.fieldOfView;
    }

    public void ResetFOV()
    {
        this.camara.fieldOfView = valorInicialFOV;
    }

    public void SelectObject(SelecModelo modelo)
    {
        if(this.modelo != null && this.modelo != modelo)
        {
            this.modelo.DetenerResaltar();
            ResetFOV();
        }

        this.modelo = modelo;
        this.target = this.modelo.Transformar();
        //this.camara.transform.LookAt(this.target);
        this.modelo.ComenzarResaltar();
    }



    void Update()
    {
        // ------------------------- Rotaciones ------------------------------
        if (Input.GetKey(KeyCode.W))
        {
            this.modelo.transform.Rotate(1.5f, 0f, 0f, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {

            this.modelo.transform.Rotate(-1.5f, 0f, 0f, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.modelo.transform.Rotate(0f, 0f, 1.5f);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            this.modelo.transform.Rotate(0f, 0f, -1.5f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.modelo.transform.Rotate(0f, 1.5f, 0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            this.modelo.transform.Rotate(0f, -1.5f, 0f);
        }
        // ----------------------------------------------------------------

        // ---------------------------- Zoom ---------------------------------
        if(Input.GetKeyDown("up"))
        {
            if(this.modelo != null)
            {
                this.camara.transform.LookAt(this.target);
                if(this.camara.fieldOfView - 5 >= minDistancia)
                {
                    this.camara.fieldOfView -= velocidad;
                }
            }else
            {
                ResetFOV();
            }
        }
        if (Input.GetKeyDown("down"))
        {
            
            if (this.modelo != null)
            {
                this.camara.transform.LookAt(this.target);
                if (this.camara.fieldOfView + 5 <= maxDistancia)
                {
                    this.camara.fieldOfView += velocidad;
                }
            }else
            {
                ResetFOV();
            }
        }
        // ------------------------------------------------------------------
    }


   
}
