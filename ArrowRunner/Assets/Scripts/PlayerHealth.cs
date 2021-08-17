using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
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
        if (collision.gameObject.tag == "Projectile")
        {
            health -= 20;
            Debug.Log(health);              
        }
    }

    public void Update()
    {
        if(health<=0)
        {
        }
    }

}
