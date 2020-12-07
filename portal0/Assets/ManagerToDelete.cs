using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerToDelete : MonoBehaviour
{
    private KeyCode keyPause = KeyCode.G;

    private void Start()
    {      
        BackToMenu();
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = false;
        QuitGame();
    }

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

    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("UIPause").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = false;
        FindObjectOfType<PlayerMovement>().CanMove = true;
        FindObjectOfType<PlayerCamera>().CanLook = true;
        FindObjectOfType<Shoot>().CanShoot = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        GameObject.FindGameObjectWithTag("UIPause").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = true;
        FindObjectOfType<PlayerMovement>().CanMove = false;
        FindObjectOfType<PlayerCamera>().CanLook = false;
        FindObjectOfType<Shoot>().CanShoot = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void AboutUs()
    {
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UIAboutUs").GetComponent<Canvas>().enabled = true;
    } 
    public void Settings()
    {
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UISettings").GetComponent<Canvas>().enabled = true;
    } 
    public void LevelSelection()
    {
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UILevelSelection").GetComponent<Canvas>().enabled = true;
    }

    public void BackToMenu()
    {
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("UIAboutUs").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UISettings").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UILevelSelection").GetComponent<Canvas>().enabled = false;
    }

}
