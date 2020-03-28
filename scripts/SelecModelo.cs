
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class SelecModelo : MonoBehaviour
{
    public float animationTime = 0.5f;
    public float threshold = 0.5f;

    private SelecModeloControlador controller;
    private Material material;
    private Color normalColor;
    private Color selectedColor;


    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        controller = FindObjectOfType<SelecModeloControlador>();
        normalColor = material.color;
        selectedColor = new Color(
            Mathf.Clamp01(normalColor.r * threshold),
            Mathf.Clamp01(normalColor.g * threshold),
            Mathf.Clamp01(normalColor.b * threshold)
        );
    }

    private void Start()
    {
        //rotation = GetComponent<MeshRenderer>().transform;
    }

    public void ComenzarResaltar()
    {
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", selectedColor,
            "time", animationTime,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.pingPong
        ));
    }

    public void DetenerResaltar()
    {
        iTween.Stop(gameObject);
        material.color = normalColor;
    }

    public void OnMouseDown()
    {
        controller.SelectObject(this);
    }

    
}
