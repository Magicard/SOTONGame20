using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class shotgunScript : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public float pelletFireVel= 1f;
    public AudioSource soundEffect;
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
        if (Input.GetButtonDown("Fire1"))
        {
            if (!soundEffect.isPlaying)
            {
                soundEffect.Play(0);
                anim.Play("Take");
                fire();
            }
        }
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
