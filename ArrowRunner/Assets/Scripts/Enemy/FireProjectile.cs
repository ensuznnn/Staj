using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float force;
    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = transform.position;
    }
    public void Fire()
    {
        rigidbody.velocity = transform.forward * 10;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("A");
            rigidbody.isKinematic = true;
            StartCoroutine(Countdown());
            
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
