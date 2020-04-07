using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

	public Transform target;
	public Rigidbody BulletRigidbody;
	public GameObject player;
	public float turn;
	public float bulletVelocity;

	// Start is called before the first frame update
	void Start()
	{
		player= GameObject.FindWithTag("Player");
		turn= 10f;
		bulletVelocity= 10f;

	}

	// Update is called once per frame
	void Update()
	{
		BulletRigidbody.velocity = transform.forward * bulletVelocity;
		var bulletTargetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
		BulletRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, bulletTargetRotation, turn));
	}
}