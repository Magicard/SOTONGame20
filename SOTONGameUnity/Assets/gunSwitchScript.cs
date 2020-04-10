using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwitchScript : MonoBehaviour
{
    public GameObject rail;
    public GameObject shotgun;
    public GameObject minigun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            rail.SetActive(false);
            shotgun.SetActive(false);
            minigun.SetActive(false);
            shotgun.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            rail.SetActive(false);
            shotgun.SetActive(false);
            minigun.SetActive(false);
            minigun.SetActive(true);
        }
        if (Input.GetKeyDown("3"))
        {
            rail.SetActive(false);
            shotgun.SetActive(false);
            minigun.SetActive(false);
            rail.SetActive(true);
        }
    }
}
