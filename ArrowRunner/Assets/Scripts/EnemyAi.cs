using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    public float lookRadius = 10f;
    public GameObject projectile;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    Transform agent;
    NavMeshAgent target;
    public void Start()
    {
        agent = PlayerManager.instance.player.transform;
        target = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(agent.position, transform.position);
        if (distance <= lookRadius)
        {
            AtackPlayer();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (agent.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void AtackPlayer()
    {
        target.SetDestination(transform.position);
        FaceTarget();
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
