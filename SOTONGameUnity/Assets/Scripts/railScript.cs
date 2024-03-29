﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railScript : MonoBehaviour
{
    public ParticleSystem particle;

    public float damage = 10f;
    public float range = 100500f;
    public Material transparent;
    public GameObject gun;
    public AudioSource soundEffect;
    public AudioSource soundEffect2;
    public AudioSource soundEffect3;
    public bool slowMo;
    public Camera fpsCamera;
    public GameObject player;
    public bool isGround;
    public bool itHit;
    public bool itShot;
    public Vector3 shot;
    public float myValue = 0f;
    public GameObject shootAnimObj;
    public Animator anim;
    public GameObject rail;


    // Start is called before the first frame update
    void Start()
    {
        anim = shootAnimObj.GetComponent<Animator>();
        anim.Play(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!soundEffect.isPlaying)
            { 
                anim.Play(0);
                var receiver = fpsCamera.GetComponent<StressReceiver>();
                float stress = (1 - Mathf.Pow(1, 2)) * 0.6f;
                receiver.InduceStress(stress);
                particle.Play();
                Shoot();
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

    void Shoot()
    {

        RaycastHit hit;
        if (slowMo)

        {
            soundEffect.pitch = 0.75f;
        }
        else
        {
            soundEffect.pitch = 1f;
        }
        soundEffect.Play(0);
        
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            
            getHitScript target= hit.transform.GetComponent<getHitScript>();
            if (target!=null)
            {              
                target.TakeDamage(damage);
            }

        }
        drawLine(gun.transform.position, fpsCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 1000f)), Color.green, 0.5f);

    }

    void drawLine(Vector3 start, Vector3 end, Color color, float duration = 100f)
    {
        GameObject myLine = new GameObject();
        myLine.name = "rail";
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = transparent;
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, 0.5f);
    }

}
