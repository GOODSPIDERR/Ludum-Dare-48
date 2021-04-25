using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HUDScript : MonoBehaviour
{

    private LayerMask layerMask;
    public GameObject uiGoDown, uiGoUp;
    private Collider hitbox;
    //private int cooldown;
    public FirstPersonController playerController;

    public GameObject transition, exitTransition, escortTransition;
 
    private void Start() 
    {
        hitbox = GetComponent<Collider>();
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 8f))
        {
            var selection = hit.transform;
            if (selection.tag == "LowerLevel")
            {
                uiGoDown.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneTransitionStart(0);
                }
            }
            else if (selection.tag == "UpperLevel")
            {
                uiGoUp.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneTransitionStart(1);
                }
            }

            else
            {
                uiGoDown.SetActive(false);
                uiGoUp.SetActive(false);
            }
        }
        else
        {
            uiGoDown.SetActive(false);
            uiGoUp.SetActive(false);
        }
        //if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        //{
        //    StartCoroutine("Paunch");
        //    cooldown = 60;
        //}
        //cooldown--;
        //Debug.Log(cooldown);
    }

    public void SceneTransitionStart(int transitionType)
    {
        switch (transitionType)
        {
            default: 
                transition.SetActive(true);
                break;
            case 1:
                exitTransition.SetActive(true);
                break;
            case 2:
                escortTransition.SetActive(true);
                break;


        }
        playerController.playerCanMove = false;
        playerController.cameraCanMove = false;
        playerController.targetVelocity = new Vector3(0,0,0);
        playerController.velocity = new Vector3(0,0,0);
        playerController.isWalking = false;
    }

    IEnumerator Paunch()
    {
        yield return new WaitForSeconds(0.05f);
        hitbox.enabled = true;
        yield return new WaitForSeconds(0.3f);
        hitbox.enabled = false;
    }
}
