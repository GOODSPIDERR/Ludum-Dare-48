using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingScript : MonoBehaviour
{
    private Animator animator;
    private int cooldown;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            animator.SetTrigger("Paunch");
            cooldown = 80;
        }
        cooldown--;
    }
    
}
