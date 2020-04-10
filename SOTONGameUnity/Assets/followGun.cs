using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followGun : MonoBehaviour
{
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("MiniGun Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gun.transform.position;
    }
}
