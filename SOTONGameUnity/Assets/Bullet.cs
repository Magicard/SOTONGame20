using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody m_Rigidbody;
	float m_Speed;
    // Start is called before the first frame update
    void Start()
    {
		m_Speed = 10.0f;
		m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



		m_Rigidbody.velocity = transform.forward * m_Speed;



    }
}
