using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railFadeScript : MonoBehaviour
{
    public GameObject rail;
    public Material transparent;
    public AudioSource soundEffect;
    public float myValue;
    public bool shot;

    // Start is called before the first frame update
    void Start()
    {
        rail = GameObject.Find("rail");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("bye");
            if (!soundEffect.isPlaying)
            {
                Debug.Log("itshot");
                shot = true;
                Invoke("itShot", 2f);
            }
        }

        if (shot == true)
        {
            if (rail.activeInHierarchy)
            {
                Debug.Log("it exists");
                transparent = rail.GetComponent<Material>();
                myValue = 0.5f;
                transparent.SetFloat("fadeOut", myValue);
            }
        }
        else
        {
            myValue = 0f;
        }
                
    }

    void itShot()
    {
        shot = false;
    }
}
