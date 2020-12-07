using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSelectButton : MonoBehaviour
{
    public void LevelSelectClick()
    {
        FindObjectOfType<PortalGameManager>().LevelSelection();
    }
}
