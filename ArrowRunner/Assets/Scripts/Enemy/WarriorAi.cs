using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarriorAi : MonoBehaviour
{
    public float lookRadius = 10f;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    Transform target;
    NavMeshAgent agent;
    public void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                gameObject.GetComponent<Animator>().SetBool("IsMoving", false);
                AtackPlayer();
            }
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void AtackPlayer()
    {
        agent.SetDestination(transform.position);
        FaceTarget();
        if (!alreadyAttacked)
        {
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            Invoke(nameof(ResetAim), 1);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void ResetAim()
    {
        gameObject.GetComponent<Animator>().SetBool("IsAiming", false);
    }
}
