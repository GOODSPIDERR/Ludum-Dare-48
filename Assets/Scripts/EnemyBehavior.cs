using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    private NavMeshAgent enemy;
    private GameObject player, upperLevel;
    public GameObject deathVFX;
    public bool playerGrabbed = false, lastScene = false;
    private FirstPersonController playerController;
    private HUDScript playerHUD;
    private PunchingScript punchingScript;
    public AudioSource comeBack, hitSound, staticNoise;
    public int hp = 4;
    public Renderer enemyRenderer;
    public float chaseDistance = 30f;
    private int selfID;
    public Material defaultMaterial, hitMaterial;
    private bool canGetHit = true, gameCanEnd = false;
    public AudioSource heartBeat;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        selfID = GetInstanceID();
        player = GameObject.FindGameObjectWithTag("Player");
        upperLevel = GameObject.FindGameObjectWithTag("UpperLevel");
        playerController = player.GetComponent<FirstPersonController>();
        playerHUD = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HUDScript>();
        punchingScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PunchingScript>();
        enemyRenderer.material = defaultMaterial;

    }
    void Update()
    {
        //Idle & seeking management
        if (!playerGrabbed && player.transform.parent == null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position); //Finding the distance
            if (distance < chaseDistance && distance > 4.2f && player.transform.parent == null) enemy.SetDestination(player.transform.position); //If within distance, start chasing
            else if (distance <= 4.2f && player.transform.parent == null) Grab(); //If grab range, grab
            else enemy.SetDestination(transform.position); //If out of distance, stand still
        }

        else if (!playerGrabbed && player.transform.parent != null) enemy.destination = transform.position; //Stop if someone else grabs the player

        //Return management
        else if (playerGrabbed && player.transform.parent != null)
        {
            float distance = Vector3.Distance(transform.position, enemy.destination); //Finding the distance
            float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
            enemy.SetDestination(upperLevel.transform.position);
            if (distance <= 3f && gameCanEnd)
            {
                playerHUD.SceneTransitionStart(2);
            }
            if (distanceFromPlayer > 6f)
            {
                player.transform.parent = null;
                playerGrabbed = false;
                playerController.playerCanMove = true;
                gameCanEnd = false;
            }
        }

        if (hp <= 0)
        {
            Death();
        }
    }


    void Grab()
    {
        playerGrabbed = true;
        player.transform.parent = gameObject.transform;
        playerController.playerCanMove = false;
        comeBack.Play();
        Invoke("CanGetGrabbedCheck", 2f);
    }

    void CanGetGrabbedCheck()
    {
        gameCanEnd = true;
    }

    void Death()
    {
        if (lastScene) 
        {
            Time.timeScale = 0.25f;
            heartBeat.Play();
            staticNoise.Stop();
        }
        playerGrabbed = false;
        player.transform.parent = null;
        playerController.playerCanMove = true;
        Instantiate(deathVFX, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
        Object.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "MainCamera" && canGetHit)
        {
            StartCoroutine("GotHit");
        }
    }

    IEnumerator GotHit()
    {
        canGetHit = false;
        hitSound.pitch = Random.Range(0.8f, 1f);
        hitSound.Play();
        hp--;
        enemyRenderer.material = hitMaterial;
        yield return new WaitForSeconds(0.5f);
        canGetHit = true;
        enemyRenderer.material = defaultMaterial;
    }
}
