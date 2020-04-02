using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public ParticleSystem particle;

    public float damage = 10f;
    public float range = 10500f;
    public Material transparent;
    public GameObject gun;
    public AudioSource soundEffect;
    public AudioSource soundEffect2;
    public bool slowMo;
    public Camera fpsCamera;
    public GameObject player;
    public bool isGround;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!soundEffect.isPlaying)
            {
                particle.Play();
                Debug.Log("leftclick");
                Shoot();
            }
        }

 

        if (Input.GetButton("Fire2")&& !player.GetComponent<movementScript>().isGrounded)
        {
            soundEffect.Play(1);
            Time.timeScale = 0.1f;
            slowMo = true;
        }
        else
        {
            soundEffect2.Stop();
            slowMo = false;
            Time.timeScale = 1f;
        }
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
        drawLine(fpsCamera.transform.position, fpsCamera.transform.forward * 2000f, Color.green, 0.5f);
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            getHitScript target= hit.transform.GetComponent<getHitScript>();
            if (target!=null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void drawLine( Vector3 start, Vector3 end, Color color, float duration= 0.5f)
    {
      
        

        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        lr.material = transparent;
        GameObject.Destroy(myLine, duration);
    }
}
