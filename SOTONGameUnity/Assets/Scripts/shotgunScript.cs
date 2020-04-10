using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunScript : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public float pelletFireVel= 1f;
    public bool slowMo;
    public AudioSource soundEffect;
    public AudioSource soundEffect2;
    public AudioSource soundEffect3;
    public Animator anim;
    public GameObject pellet;
    public GameObject gun;
    public Transform BarrelExit;
    List<Quaternion> pellets;

    // Start is called before the first frame update
    void Start()
    {
        anim = gun.GetComponent<Animator>();

        pellets = new List<Quaternion>(pelletCount);
        for (int i=0; i< pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
        
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
        if (Input.GetButtonDown("Fire1"))
        {
            
            if (!soundEffect.isPlaying)
            {
                
                soundEffect.Play(0);
                anim.Play("Take");
                fire();
            }
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

    void fire()
    {
        for(int i=0; i< pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletFireVel);
        }
    }
}
