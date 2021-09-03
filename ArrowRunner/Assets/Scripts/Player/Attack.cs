using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject arrow;
    public Transform fireTransform;
    private Vector3 target;
    Camera camera;
    public void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    public void FireArrow()
    {
        Vector3 mouse = Input.mousePosition;
        RaycastHit enemy;

        if (Physics.Raycast(camera.ScreenPointToRay(mouse), out enemy))   //Mouse ile Tikladigim objenin tagina göre saldiri yaptiriyorum.
        {
            if (enemy.collider.CompareTag ("Enemy"))
            {
                PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", false);
                PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", true);
                StartCoroutine(Wait());
            }
            if (enemy.collider.CompareTag("Boss"))
            {
                PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", false);
                PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", true);
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()  //Mouse pozisyonu ve düsmanin pozisyonuna göre saldiri hesaplamari ve animasyonlari devreye sokuyorum.
    {     
        Vector3 mouse = Input.mousePosition;
        RaycastHit enemy;
        target = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - PlayerManager.instance.player.transform.position;
        float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        PlayerManager.instance.player.transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
        float distance = difference.magnitude;
        Vector3 direction = difference / distance;
        direction.Normalize();
        //Wait for the position to update
        yield return new WaitForSeconds(1f);
        if (Physics.Raycast(camera.ScreenPointToRay(mouse), out enemy))
        {
            if (enemy.collider.gameObject.tag == "Enemy"|| enemy.collider.gameObject.tag == "Boss")
            {            
                GameObject projectile = Instantiate(arrowPrefab);
                projectile.transform.position = fireTransform.transform.position;
                projectile.transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
                projectile.GetComponent<ArrowProjectile>().Fire();             
                PlayerManager.instance.player.GetComponent<Inventory>().arrows -= 1;
                PlayerManager.instance.player.GetComponent<Inventory>().arrowCounts.text = ("Arrows : " + (PlayerManager.instance.player.GetComponent<Inventory>().arrows)).ToString();
                PlayerManager.instance.player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                if (PlayerManager.instance.player.GetComponent<Animator>().GetBool("Finish")!= true)
                {
                    PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", true);
                }
            }
        }
    }
}
