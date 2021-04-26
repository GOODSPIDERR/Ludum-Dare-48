using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingScript : MonoBehaviour
{
    private Animator animator;
    public float cooldown;
    private AudioSource swingSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        swingSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown <= 0)
        {
            animator.SetTrigger("Paunch");
            swingSound.pitch = Random.Range(0.8f, 1f);
            swingSound.Play();
            cooldown = 0.8f;
        }
        cooldown -= 1 * Time.deltaTime;
    }
    
    
}
