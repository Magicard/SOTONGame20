using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{

	public Transform playerObject;
	public Transform playerDistance;
	public GameObject Projectile;
	public Transform originP;
	public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
		cooldown = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

		if (playerDistance)
		{
			float dist = Vector3.Distance(playerDistance.position, transform.position);
			//print("Distance to other: " + dist);

			if (dist <=10)
			{
				transform.LookAt(playerObject);

				cooldown -=1;

				if (cooldown <=  0 )
				{
					
				Instantiate (Projectile, transform.position, Quaternion.identity);
					cooldown = 100;
				}
			}


		}






    }
}
