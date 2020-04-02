using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public ParticleSystem particle;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            particle.Play();
            Debug.Log("leftclick");
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward* 10000f, Color.cyan, Time.deltaTime, false);
            getHitScript target= hit.transform.GetComponent<getHitScript>();
            if (target!=null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
