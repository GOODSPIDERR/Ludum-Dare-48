using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    private NavMeshAgent enemy;
    private Transform player, upperLevel;
    public GameObject deathVFX;
    public bool playerGrabbed = false;
    private FirstPersonController playerController;
    public HUDScript playerHUD;
    public PunchingScript punchingScript;
    private AudioSource comeBack;
    public int hp = 4;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        upperLevel = GameObject.FindGameObjectWithTag("UpperLevel").transform;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        comeBack = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        if (!playerGrabbed)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < 20f && distance > 4.4f) enemy.SetDestination(player.position);
            else if (distance <= 4.4f) Grab();
            else enemy.SetDestination(transform.position);
            //Debug.Log(distance);
        }
        else
        {
            float distance = Vector3.Distance(transform.position, enemy.destination);
            enemy.SetDestination(upperLevel.position);
            if (distance <= 3f)
            {
                punchingScript.cooldown = 9999f;
                playerHUD.SceneTransitionStart(2);
            }
        }

        if (hp <= 0)
        {
            Death();
        }

        ///if (Input.GetKeyDown(KeyCode.Q))
        ///{
        ///    hp--;
        ///}

        
        //Debug.Log("The destination is: " + enemy.destination);
    }


    void Grab()
    {
        playerGrabbed = true;
        //enemy.SetDestination(upperLevel.position);
        player.parent = gameObject.transform;
        //playerController.targetVelocity = new Vector3(0,0,0);
        playerController.playerCanMove = false;
        comeBack.Play();
        //Invoke("Death", 5f);
    }

    void Death()
    {
        playerGrabbed = false;
        player.parent = null;
        playerController.playerCanMove = true;
        Instantiate(deathVFX, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
        Object.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "MainCamera")
        {
            hp--;
        }
    }
}
