using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneTimescaleManager : MonoBehaviour
{
    private AudioSource[] allAudioSources;
    private LastSceneTimescaleManager timescaleManager;
    private bool deathTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        timescaleManager = GetComponent<LastSceneTimescaleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 1f)
        {   
            deathTriggered = true;
            Time.timeScale += 0.25f * Time.deltaTime;
        }
        else if (deathTriggered && Time.timeScale >= 1f)
        {  
            timescaleManager.enabled = false;
        }

        foreach(AudioSource audioS in allAudioSources) 
        {
            if (audioS != null)
            audioS.pitch = Time.timeScale;
        }

        Debug.Log(Time.timeScale);
    }
}
