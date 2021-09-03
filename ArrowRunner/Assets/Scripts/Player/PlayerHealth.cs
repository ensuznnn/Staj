using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 20;
    public float maxHealth = 20;
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
        }
    }

    public void Update()
    {
        if(health<=0)
        {
            GameObject.Find("GameManager").GetComponent<GameController>().Fail();
            gameObject.GetComponent<PlayerHealth>().enabled = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Walls")
        {
            GameObject.Find("GameManager").GetComponent<GameController>().Fail();
            Debug.Log("Dead");
        }
    }
}
