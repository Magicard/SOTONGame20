using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCon : MonoBehaviour
{
	public float grace = 100f;
	public bool graceperiod = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }


	void OnCollisionEnter (Collision other)
	{
		if (graceperiod == false){
			Destroy(gameObject);
		    graceperiod = true;
		}
	}


    // Update is called once per frame
    void Update()
    {
		if (graceperiod == true)
		{
			grace -= 1f;
		}

		if (grace <= 0f)
		{
			graceperiod  = false;
			grace = 40f;
		}
    }
	}
