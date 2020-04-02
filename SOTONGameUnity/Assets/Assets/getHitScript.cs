using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHitScript : MonoBehaviour
{
    public float hp = 50f;

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
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
