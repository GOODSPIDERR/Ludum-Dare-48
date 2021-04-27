using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsRapTimer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource ambientMusic;
    public float countDown = 30f;
    private bool rapTrigger = false;
    public GameObject secretRap;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    private void Update() 
    {
        countDown -= 1f * Time.deltaTime;

        if (countDown <= 0f && !rapTrigger)
        {
            rapTrigger = true;
            secretRap.SetActive(true);
            audioSource.Play();
            ambientMusic.Stop();
        }
    }
}
