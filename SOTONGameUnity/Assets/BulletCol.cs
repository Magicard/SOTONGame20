using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCol : MonoBehaviour
{
	public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 

void OnCollisionEnter (Collision other) {
		Debug.Log("FUCK");

		getHitScript target = other.transform.GetComponent<getHitScript>();

		if (target != null)
		{
			Debug.Log("PENIS");
			Debug.Log(target);
			target.TakeDamage(damage);
            Destroy(gameObject);
		}
	
		}
	}	
