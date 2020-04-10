using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwitchScript : MonoBehaviour
{
    public GameObject rail;
    public GameObject shotgun;
    public GameObject minigun;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(anim1.GetCurrentAnimatorStateInfo(0).IsTag("1") || anim2.GetCurrentAnimatorStateInfo(0).IsTag("1") || anim3.GetCurrentAnimatorStateInfo(0).IsTag("1")))
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
}
