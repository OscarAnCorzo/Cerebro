using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //Añadir el namespace para poder implementar sus interfaces

public class Gestures3DCollider : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public Text textBox;

    private float zAxis = 0;
    private float xAxis = 0;
    private float yAxis = 0;
    private float boton = 0;
    private Vector3 clickOffset = Vector3.zero;

    private void Start()
    {
        zAxis = transform.position.z;
        xAxis = transform.position.x;
        yAxis = transform.position.y;
    }

    //Se ejecuta cuando ha empezado a arrastrarse, antes del OnDrag
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(2))
        {
            Debug.Log("centro");
            clickOffset = transform.position - CalculoMoverZ(eventData.position, xAxis, yAxis);
            boton = 2;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("izquierdo");
                clickOffset = transform.position - CalculateScreenPointToWoldOnPlane(eventData.position, zAxis);
                boton = 0;
            }
            
        }
        
        Debug.Log(eventData.button);
        //textBox.text = "Va a ser arrastrado";
    }

    //Se ejecuta repetidamente mientras se esté arrastrando
    public void OnDrag(PointerEventData eventData)
    {
        if (boton == 2)
        {
            //clickOffset = transform.position - CalculoMoverZ(eventData.position, xAxis, yAxis);
            transform.position = CalculoMoverZ(eventData.position, xAxis, yAxis) + clickOffset;
        }
        else
        {
            if (boton == 0)
            {
                transform.position = CalculateScreenPointToWoldOnPlane(eventData.position, zAxis) + clickOffset;
            }

        }
        
        //textBox.text = "Está siendo arrastrado";
    }

    //Se ejecuta cuando se ha soltado, antes del OnDrop
    public void OnEndDrag(PointerEventData eventData)
    {
        //textBox.text = "Va a ser soltado";
    }
    

    //Se ejecuta al finalizar la pulsación completa (levantar el dedo o ratón)
    public void OnPointerClick(PointerEventData eventData)
    {
        //textBox.text = "Ha sido pulsado";
    }

    //Se ejecuta cuando el punto del ratón pasa por encima
    public void OnPointerEnter(PointerEventData eventData)
    {
        //textBox.text = "El ratón está encima";
    }

    //Se ejecuta cuando el puntero, después de haber pasado por encima, sale de su collider
    public void OnPointerExit(PointerEventData eventData)
    {
        //textBox.text = "El ratón ya NO está encima";
    }

    public Vector3 CalculateScreenPointToWoldOnPlane(Vector3 screenPosition, float zPos)
    {
        float enterDist;
        Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, zPos));
        Ray rayCast = Camera.main.ScreenPointToRay(screenPosition);
        plane.Raycast(rayCast, out enterDist);
        return rayCast.GetPoint(enterDist);
    }

    public Vector3 CalculoMoverZ(Vector3 screenPosition, float xPos, float yPos)
    {
        float enterDist;
        Plane plane = new Plane(new Vector3(1,1,0), new Vector3(xPos, yPos, 0));
        Ray rayCast = Camera.main.ScreenPointToRay(screenPosition);
        plane.Raycast(rayCast, out enterDist);
        return rayCast.GetPoint(enterDist);
    }
}
