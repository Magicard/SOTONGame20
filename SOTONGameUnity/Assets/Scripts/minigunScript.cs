using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigunScript : MonoBehaviour
{
    public float damage = 0.5f;
    public float range = 100f;
    public bool slowMo;
    public Camera fpsCam;
    public AudioSource soundEffect;
    public AudioSource soundEffect2;
    public AudioSource soundEffect3;
    public GameObject muzzle;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (slowMo)
        {
            soundEffect.pitch = 0.5f;
        }
        else
        {
            soundEffect.pitch = 1f;
        }
        if (Input.GetButton("Fire1"))
        {
            
            Shoot();
        }
        else
        {
            soundEffect.Stop();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            playSlowMo();
        }
        if (Input.GetButton("Fire2"))
        {
            Time.timeScale = 0.1f;
            soundEffect2.pitch = 1.75f;
            soundEffect2.Play();
            slowMo = true;
        }
        else
        {
            slowMo = false;
            Time.timeScale = 1f;
        }



    }

    void playSlowMo()
    {
        soundEffect3.Play();
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
