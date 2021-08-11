using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    
    public Rigidbody rBody;
    public GameObject arrow;
    public GameObject spawnPoint;


    public void Update()
    {
        transform.position = spawnPoint.transform.position;
    }

    public void Fire()
    {
        
        rBody = Instantiate(arrow,spawnPoint.transform.position, Quaternion.identity).gameObject.GetComponent<Rigidbody>();
        rBody.AddForce(transform.forward * (50 * Random.Range(1.3f, 1.7f)), ForceMode.Impulse);
        rBody.AddForce(transform.up * 2f, ForceMode.Impulse);

    }
    /*
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {
            rBody.isKinematic = true;
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    */
}
