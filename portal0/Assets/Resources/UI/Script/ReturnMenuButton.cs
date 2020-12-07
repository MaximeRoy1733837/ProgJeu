using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMenuButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        FindObjectOfType<PortalGameManager>().BackToMenu();
    }
}
