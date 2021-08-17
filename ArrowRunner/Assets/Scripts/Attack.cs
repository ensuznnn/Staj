using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{


    public GameObject arrowPrefab;
    public GameObject arrow;
    [SerializeField]
    private Transform fireTransform;
    Camera camera;

    public void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    public void FireArrow()
    {

        Vector3 mouse = Input.mousePosition;
        RaycastHit enemy;

        if (Physics.Raycast(camera.ScreenPointToRay(mouse), out enemy))
        {
            if (enemy.collider.gameObject.tag == "Enemy")
            {
                //Wait for the position to update            
                PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", false);
                PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", true);
                StartCoroutine(Wait());
                GameObject projectile = Instantiate(arrowPrefab);
                projectile.transform.forward = enemy.point;
                projectile.transform.position = fireTransform.position + fireTransform.forward;
                projectile.GetComponent<ArrowProjectile>().Fire();
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
      
    }
}
