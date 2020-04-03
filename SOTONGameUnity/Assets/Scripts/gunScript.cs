using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public ParticleSystem particle;

    public float damage = 10f;
    public float range = 100500f;
    public Material transparent;
    public GameObject gun;
    public AudioSource soundEffect;
    public AudioSource soundEffect2;
    public bool slowMo;
    public Camera fpsCamera;
    public GameObject player;
    public bool isGround;
    public bool itHit;
    public Vector3 shot;

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
        soundEffect2.Play();
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
        shot = gun.transform.forward * 2000f;
        
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            
            getHitScript target= hit.transform.GetComponent<getHitScript>();
            if (target!=null)
            {
                shot = target.transform.position;
                
                target.TakeDamage(damage);
            }

        }
        drawLine(gun.transform.position,shot, Color.green, 0.5f);

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
