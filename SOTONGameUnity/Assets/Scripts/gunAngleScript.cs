using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAngleScript : MonoBehaviour
{

    public Transform leftAngle;
    public Transform centreAngle;
    public Transform rightAngle;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.D))
        {
            gun.transform.rotation = Quaternion.Lerp(gun.transform.rotation, rightAngle.transform.rotation, (1f * Time.deltaTime) * 4);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gun.transform.rotation = Quaternion.Lerp(gun.transform.rotation, leftAngle.transform.rotation, (1f*Time.deltaTime)*4);
        }
        else
        {
            gun.transform.rotation = Quaternion.Lerp(gun.transform.rotation, centreAngle.transform.rotation, (1f * Time.deltaTime) * 4);
        }

    }
}
