using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSelectButton : MonoBehaviour
{
    public void LevelSelectClick()
    {
        print("LevelSelect");
        FindObjectOfType<ManagerToDelete>().LevelSelection();
    }
}
