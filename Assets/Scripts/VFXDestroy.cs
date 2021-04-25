using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class VFXDestroy : MonoBehaviour
{
    private VisualEffect vfx;
    private bool itStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(vfx.aliveParticleCount);
        if(vfx.aliveParticleCount != 0) itStarted = true;
        if(vfx.aliveParticleCount == 0 && itStarted) Object.Destroy(gameObject);
    }
}
