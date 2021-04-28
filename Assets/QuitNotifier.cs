using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitNotifier : MonoBehaviour
{
    public GameObject quitNotifier;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) quitNotifier.SetActive(true);
    }
}
