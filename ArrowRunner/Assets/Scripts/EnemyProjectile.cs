using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyProjectile : MonoBehaviour
{

    public float speed;
    public float damage;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position.x == target.position.x && transform.position.y == target.position.y)
        {

            DestroyProjectile();

        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
