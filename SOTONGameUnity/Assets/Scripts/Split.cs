using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
	public float hp = 50f;
	public GameObject particles;
	public Rigidbody rb;

	public Transform OriginA;
	public Transform OriginB;
	public Transform OriginC;

	public GameObject small;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void TakeDamage(float amount)
	{
		hp -= amount;
		if (hp <=0f)
		{
			Instantiate(small, OriginA.position, Quaternion.identity);
			Instantiate(small, OriginB.position, Quaternion.identity);
			Instantiate(small, OriginC.position, Quaternion.identity);
			Die();
		}
	}

	void Die()
	{
		Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
	}
}
