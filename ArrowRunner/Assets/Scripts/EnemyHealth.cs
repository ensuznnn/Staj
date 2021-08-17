using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    // public Image healthBar;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            health -= 20;
            Debug.Log(health);
        }
    }

    public void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

}
