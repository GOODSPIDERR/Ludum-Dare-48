using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;
    public Quaternion offset;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.LookAt(player);
        transform.rotation = new Quaternion(0f + offset.x, transform.rotation.y + offset.y, 0f + offset.z, transform.rotation.w + offset.w);
    }
}
