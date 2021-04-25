using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundScript : MonoBehaviour
{
    private AudioSource sound;
    private int stepCooldown = 30;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.localPosition.y <= 0.66 && stepCooldown <= 0) 
        {
            stepCooldown = 10;
            sound.pitch = (Random.Range(0.8f, 1f));
            sound.Play();
        }
    }

    private void FixedUpdate() 
    {
        stepCooldown--;
    }
}
