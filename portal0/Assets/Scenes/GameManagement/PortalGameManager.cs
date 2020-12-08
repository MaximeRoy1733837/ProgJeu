using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PortalGameManager : MonoBehaviour
{
    public static PortalGameManager portalGameManager;
    public GameObject UI;

    AudioSource audioSource;

    public AudioClip nextSceneSound;
    public GameObject soundTransition;

    private KeyCode keyPause = KeyCode.G;
    void Start()
    {
        if (portalGameManager == null)
        {
            portalGameManager = this;
            UI = Instantiate(UI);
            DontDestroyOnLoad(UI);
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            AudioClip audioClipBackGround = Resources.Load<AudioClip>("Sound/Background");
            audioSource.clip=audioClipBackGround;
            audioSource.Play();
            audioSource.volume = 0.5f;
            print("start");
            LoadSceneByIndex(0);
            BackToMenu();
        }
        else
        {
            Destroy(gameObject);
        }
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

        CleanUI();

        if (isPaused)
        {
            LockControls();
            GameObject.FindGameObjectWithTag("UIPause").GetComponent<Canvas>().enabled = true; GameObject.FindObjectOfType<EventSystem>().enabled = true;
        }
        else
        {
            UnLockControls();
        }
    }

    public void StartGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            print("startGame");
            LoadSceneByIndex(1);
        }
        CleanUI();
        UnLockControls();
    }

    public void QuitGame()
    {
        CleanUI();
        LockControls();
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = true; GameObject.FindObjectOfType<EventSystem>().enabled = true;
    }

    public void AboutUs()
    {
        CleanUI();
        GameObject.FindGameObjectWithTag("UIAboutUs").GetComponent<Canvas>().enabled = true; GameObject.FindObjectOfType<EventSystem>().enabled = true;
    }
    public void Settings()
    {
        CleanUI();
        GameObject.FindGameObjectWithTag("UISettings").GetComponent<Canvas>().enabled = true; GameObject.FindObjectOfType<EventSystem>().enabled = true;
    }
    public void LevelSelection()
    {
        CleanUI();
        GameObject.FindGameObjectWithTag("UILevelSelection").GetComponent<Canvas>().enabled = true; GameObject.FindObjectOfType<EventSystem>().enabled = true;
    }

    public void BackToMenu()
    {
        CleanUI();
        LockControls();
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = true; GameObject.FindObjectOfType<EventSystem>().enabled = true;
    }

    public void LockControls()
    {
        if (FindObjectOfType<PlayerCamera>() != null)
        {
            FindObjectOfType<PlayerMovement>().CanMove = false;
            FindObjectOfType<PlayerCamera>().CanLook = false;
            FindObjectOfType<Shoot>().CanShoot = false;
        }
        Cursor.lockState = CursorLockMode.None;
    } 
    public void UnLockControls()
    {
        if (FindObjectOfType<PlayerCamera>() != null)
        {
            FindObjectOfType<PlayerMovement>().CanMove = true;
            FindObjectOfType<PlayerCamera>().CanLook = true;
            FindObjectOfType<Shoot>().CanShoot = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CleanUI()
    {
        GameObject.FindGameObjectWithTag("UIMainMenu").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UIAboutUs").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UISettings").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UILevelSelection").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("UIPause").GetComponent<Canvas>().enabled = false;
        GameObject.FindObjectOfType<EventSystem>().enabled = false;
    }


    public void LoadSceneByIndex(int aIndex)
    {
        try
        {
            
            print("loadScene");
            print(aIndex);
            SceneManager.LoadScene(aIndex);

        }
        catch (System.Exception)
        {
            throw;
        }
        /*if(aIndex>=0 && aIndex<2)
        {*/
       // }
    }

}
