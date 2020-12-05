using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerToDelete : MonoBehaviour
{
    private KeyCode keyPause = KeyCode.G;

    private void Update()
    {
        if (Input.GetKeyDown(keyPause))
        {
            Pause();
        }
    }

    public void Pause()
    {
        bool isPaused = !GameObject.FindGameObjectWithTag("UIPause").GetComponent<Canvas>().enabled;

        GameObject.FindGameObjectWithTag("UIPause").GetComponent<Canvas>().enabled = isPaused;
        FindObjectOfType<PlayerMovement>().CanMove = !isPaused;
        FindObjectOfType<PlayerCamera>().CanLook = !isPaused;
        FindObjectOfType<Shoot>().CanShoot = !isPaused;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
