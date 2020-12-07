using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButton : MonoBehaviour
{
    public void AboutClick()
    {
        FindObjectOfType<ManagerToDelete>().AboutUs();
    }
}
