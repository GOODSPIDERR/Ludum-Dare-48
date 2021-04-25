using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMigration : MonoBehaviour
{

    private AudioSource[] allAudioSources;
    private AudioSource swound;
    public bool loadMainMenu;
    void Start()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource audioS in allAudioSources) 
        {
            audioS.Stop();
        }
        swound = GetComponent<AudioSource>();
        swound.Play();
        Invoke("SceneChange", 8f);
    }

    void SceneChange()
        {
            if (!loadMainMenu) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else SceneManager.LoadScene("MainMenu");
        }
}
