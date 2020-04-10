using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class minigunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public AudioSource soundEffect;
    public GameObject muzzle;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            
            Shoot();
        }
        else
        {
            soundEffect.Stop();
        }
    }

    void Shoot()
    {
        if (!soundEffect.isPlaying)
        {
            soundEffect.Play(0);
        }
        Instantiate(muzzle, gameObject.transform.position, gameObject.transform.rotation);
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            getHitScript target = hit.transform.GetComponent<getHitScript>();
            if (target != null)
            {
                Debug.Log(target);
                target.TakeDamage(damage);
            }
        }
    }

}
