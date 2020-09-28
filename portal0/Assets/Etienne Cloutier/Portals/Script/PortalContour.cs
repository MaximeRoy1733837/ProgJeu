using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalContour : MonoBehaviour
{
    private Color myColor = new Color(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PortalContour>().GetComponent<Renderer>().material.color=myColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetColor(Color aColor)
    {
        myColor = aColor;
    }
}
