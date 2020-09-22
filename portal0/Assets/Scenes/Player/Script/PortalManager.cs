using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject PortalPrefab;

    private GameObject portalBlue;
    private GameObject portalOrange;
    private Camera camBlue;
    // Start is called before the first frame update
    void Start()
    {
        portalBlue = Instantiate(PortalPrefab,transform.position,transform.rotation);
        camBlue= portalBlue.GetComponent<Camera>();
        /*for(int i=0;i<portalBlue.transform.childCount;i++)
        {
            Transform currentItem = portalBlue.transform.GetChild(i);
            if(currentItem.name.Equals("Centre"))
            {
                currentItem.gameObject.GetComponent<Renderer>().material=camBlue.GetComponent<>
            }
        }*/
        //portalBlue.GetComponent<PortalCenter>().GetComponent<Renderer>().material=
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
