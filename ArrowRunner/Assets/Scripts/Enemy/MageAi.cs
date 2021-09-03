using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MageAi : MonoBehaviour
{
    public float lookRadius = 10f;
    public GameObject projectile;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    Transform agent;
    NavMeshAgent target;
    public Transform firePoint;
    public void Start()
    {
        agent = PlayerManager.instance.player.transform;
        target = GetComponent<NavMeshAgent>();
        gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector3.Distance(agent.position, transform.position);
        if (distance <= lookRadius)
        {
            StartCoroutine(Delay());
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (agent.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        firePoint.rotation = Quaternion.Slerp(firePoint.rotation, lookRotation, Time.deltaTime * 50f);
    }
    private void AtackPlayer()
    {
        target.SetDestination(transform.position);
        FaceTarget();
        if (!alreadyAttacked)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<Animator>().SetBool("IsAiming", true);
            gameObject.GetComponent<Animator>().SetBool("Fire", true);
            GameObject projectileX = Instantiate(projectile);
            projectileX.transform.position = firePoint.transform.position;
            projectileX.transform.rotation = firePoint.transform.rotation;
            projectileX.GetComponent<FireProjectile>().Fire();
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
        gameObject.GetComponent<Collider>().isTrigger = false;
    }

    IEnumerator Delay() //FirePoint rotasyonunu güncellemek için
    {
        FaceTarget();
        yield return new WaitForSeconds(0.5f);
        AtackPlayer();
    }
}
