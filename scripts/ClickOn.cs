using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;
    private MeshRenderer myRend;
    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        
    }

    public void ClickMe()
    {
        Debug.Log(myRend);
        myRend.material = green;
    }
}
