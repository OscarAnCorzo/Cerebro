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
    public GameObject panel;
    public GameObject titulo;
    public GameObject descripcion;

    private void Awake()
    {
        camara = FindObjectOfType<Camera>();
        valorInicialFOV = camara.fieldOfView;
        panel = GameObject.Find("Panel");
        titulo = GameObject.Find("titulo");
        descripcion = GameObject.Find("descripcion");
    }

    public void ResetFOV()
    {
        this.camara.fieldOfView = valorInicialFOV;
    }

    public void SelectObject(SelecModelo modelo, string desde)
    {
        if(this.modelo != null && this.modelo != modelo)
        {
            this.modelo.DetenerResaltar();
            ResetFOV();
            this.panel.transform.localScale = new Vector3(0f,0f,0f);
            this.camara.transform.LookAt(null);
        }

        this.modelo = modelo;
        this.target = this.modelo.Transformar();
        if (desde == "derecho")
        {
            this.camara.transform.LookAt(this.target);
            this.titulo.GetComponent<UnityEngine.UI.Text>().text = this.modelo.GetTitulo();
            this.descripcion.GetComponent<UnityEngine.UI.Text>().text = this.modelo.GetDescripcion();
            this.panel.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            
            //Debug.Log(this.titulo.GetComponent<UnityEngine.UI.Text>().text);
        }
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
        if (Input.GetKey(KeyCode.R))
        {
            Transform corteza = GameObject.Find("corteza").transform.GetChild(0);
            Transform medula = GameObject.Find("medula espinal").transform.GetChild(0);
            Transform cuerpo = GameObject.Find("cuerpo calloso").transform.GetChild(0);
            Transform cerebelo = GameObject.Find("cerebelo").transform.GetChild(0);
            Transform ventriculo = GameObject.Find("ventriculo vertical").transform.GetChild(0);
            Transform camara = GameObject.Find("Main Camera").transform;
            Transform salon = GameObject.Find("Low Poly ClassRoom").transform;
            Transform sol = GameObject.Find("Directional Light").transform;

            corteza.transform.position = new Vector3(-4.2f, 6.16f, -0.86f);
            medula.transform.position = new Vector3(-4.2f, 6.16f, -0.86f);
            cuerpo.transform.position = new Vector3(-4.2f, 6.16f, -0.86f);
            cerebelo.transform.position = new Vector3(-4.2f, 6.16f, -0.86f);
            ventriculo.transform.position = new Vector3(-4.2f, 6.16f, -0.86f);

            corteza.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
            medula.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
            cuerpo.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
            cerebelo.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
            ventriculo.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
            camara.transform.rotation = Quaternion.Euler(4.5f, -1.08f, -0.36f);
            FindObjectOfType<Camera>().fieldOfView = 50f;
            salon.transform.rotation = Quaternion.Euler(0f, 35.02f, 0f);
            sol.transform.rotation = Quaternion.Euler(10.07f, 4.09f, 2.1f);
            panel = GameObject.Find("Panel");
            panel.transform.localScale = new Vector3(0f, 0f, 0f);
        }
        // ------------------------------------------------------------------
    }


   
}
