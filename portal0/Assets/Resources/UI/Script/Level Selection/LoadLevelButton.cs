using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    public void LoadLevel(int aIndex)
    {
        FindObjectOfType<PortalGameManager>().LoadSceneByIndex(aIndex);
        FindObjectOfType<PortalGameManager>().CleanUI();  
        FindObjectOfType<PortalGameManager>().UnLockControls();
    }
}
