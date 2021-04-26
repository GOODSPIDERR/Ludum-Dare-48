using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject transition;
    public Animator cameraAnimator;
    private void Start() 
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        cameraAnimator.SetTrigger("GameStarted");
        transition.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
