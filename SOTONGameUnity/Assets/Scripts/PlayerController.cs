using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float Health = 100f;
	public float graceperiod = 0f;
	public bool grace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (grace == true)
		{
			graceperiod += 1.0f;
		}

		if (graceperiod > 100f)
		{
			grace = false;
			graceperiod = 0.0f;
		}
			
    }

			void OnCollisionEnter (Collision hit)
			{
		
		if(hit.transform.gameObject.name == "Splitter" & (grace == false))
				{
			grace = true;
					Health -= 25.0f;
				}


		if(hit.transform.gameObject.name == "ProjectileE" & (grace == false))
		{
			grace = true;
			Health -= 25.0f;
			}

		if(hit.transform.gameObject.name == "Pinky" & (grace == false))
		{
			grace = true;
			Health -= 25.0f;
			}

			}

			}