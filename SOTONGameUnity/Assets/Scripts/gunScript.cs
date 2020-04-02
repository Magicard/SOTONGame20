using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public ParticleSystem particle;

    public float damage = 10f;
    public float range = 10500f;

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
        drawLine(fpsCamera.transform.position, fpsCamera.transform.forward * 2000f, Color.green, 0.2f);
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            
            getHitScript target= hit.transform.GetComponent<getHitScript>();
            if (target!=null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void drawLine( Vector3 start, Vector3 end, Color color, float duration= 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
