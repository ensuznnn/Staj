using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowProjectile : MonoBehaviour
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
        rigidbody.velocity = transform.forward * 50f*force;
    }
    public void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.tag == "Enemy")
            {
                rigidbody.isKinematic = true;
                Destroy(collision.gameObject);
                StartCoroutine(Countdown());
            }
            if (collision.gameObject.tag == "Boss")
            {
                rigidbody.isKinematic = true;
                StartCoroutine(Countdown());
            }
            if (collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
        IEnumerator Countdown()
        {
            Destroy(gameObject);
            yield return new WaitForSeconds(0.1f);
        }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}

