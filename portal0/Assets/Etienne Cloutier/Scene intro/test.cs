using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Material materialPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Material material = Instantiate(materialPrefab);
        gameObject.GetComponent<Renderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
