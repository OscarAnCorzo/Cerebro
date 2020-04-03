using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBotones : MonoBehaviour
{
    public GameObject panel;
    public float x;
    public float y;
    public float z;

    public void cerrarPanel()
    {
        panel = GameObject.Find("Panel");
        this.panel.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void restablecer()
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
        medula.transform.position = new Vector3(-4.2f,6.16f,-0.86f);
        cuerpo.transform.position = new Vector3(-4.2f,6.16f,-0.86f);
        cerebelo.transform.position = new Vector3(-4.2f,6.16f,-0.86f);
        ventriculo.transform.position = new Vector3(-4.2f,6.16f,-0.86f);

        corteza.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
        medula.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
        cuerpo.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
        cerebelo.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
        ventriculo.transform.rotation = Quaternion.Euler(-95.01f, -2f, 0f);
        camara.transform.rotation = Quaternion.Euler(4.5f, -1.08f, -0.36f);
        FindObjectOfType<Camera>().fieldOfView = 50f;
        salon.transform.rotation = Quaternion.Euler(0f, 35.02f, 0f);
        sol.transform.rotation = Quaternion.Euler(10.07f, 4.09f, 2.1f);
        cerrarPanel();
    }

    public void rotar(string desde)
    {
        restablecer();
        Transform corteza = GameObject.Find("corteza").transform.GetChild(0);
        Transform medula = GameObject.Find("medula espinal").transform.GetChild(0);
        Transform cuerpo = GameObject.Find("cuerpo calloso").transform.GetChild(0);
        Transform cerebelo = GameObject.Find("cerebelo").transform.GetChild(0);
        Transform ventriculo = GameObject.Find("ventriculo vertical").transform.GetChild(0);
        Transform salon = GameObject.Find("Low Poly ClassRoom").transform;
        Transform sol = GameObject.Find("Directional Light").transform;
        Debug.Log(desde);
        switch(desde)
        {
            case "lateralIzq":
                this.x = 0f;
                this.y = 0f;
                this.z = 90f;
                break;
            case "lateralDer":
                this.x = 0f;
                this.y = 0f;
                this.z = -90f;
                break;
            case "superior":
                this.x = -90f;
                this.y = 0f;
                this.z = 0f;
                break;
            case "inferior":
                this.x = 90f;
                this.y = 0f;
                this.z = 0f;
                break;
            case "frontal":
                this.x = 0f;
                this.y = 0f;
                this.z = 0f;
                break;
            case "posterior":
                this.x = 0f;
                this.y = 0f;
                this.z = 180f;
                break;
        }
        corteza.transform.Rotate(this.x, this.y, this.z);
        medula.transform.Rotate(this.x, this.y, this.z);
        cuerpo.transform.Rotate(this.x, this.y, this.z);
        cerebelo.transform.Rotate(this.x, this.y, this.z);
        ventriculo.transform.Rotate(this.x, this.y, this.z);
        if(desde != "superior" && desde != "inferior")
        {
            salon.transform.Rotate(0f, this.z, 0f);
            sol.transform.rotation = Quaternion.Euler(10.07f, 4.09f + this.z, 2.1f);
        } 
    }

    public void cerrarInst()
    {
        panel = GameObject.Find("PanelInicial");
        this.panel.transform.localScale = new Vector3(0f, 0f, 0f);
    }
}
