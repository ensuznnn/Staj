using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public GameObject arrowMagic;
    public GameObject arrowRight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            StartCoroutine(AutoAttack(other.gameObject.transform.parent.gameObject.GetComponent<Obstacles>().health));
            PlayerManager.instance.player.GetComponent<SwipeMovement>().enabled = false;
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", false);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Finish", true);
        }
    }
    IEnumerator RunAgain()
    {
        yield return new WaitForSeconds(0.1f);
        arrowRight.SetActive(true);
        PlayerManager.instance.player.GetComponent<SwipeMovement>().enabled = true;
        PlayerManager.instance.player.GetComponent<Animator>().SetBool("Finish", false);
        PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", true);
    }
    IEnumerator AutoAttack(float times)
    {
        Debug.Log("Obstacle Health: " + times);
        for (float i = 0; i < times; i++)
        {
            if (PlayerManager.instance.player.GetComponent<Inventory>().arrows > 0)
            {
                GameObject magic1 = Instantiate(arrowMagic, arrowRight.transform.position, Quaternion.identity);
                magic1.GetComponent<ArrowProjectile>().Fire();
                yield return new WaitForSeconds(0.5f);
                PlayerManager.instance.player.GetComponent<Inventory>().arrows -= 1;
                PlayerManager.instance.player.GetComponent<Inventory>().arrowCounts.text = ("Arrows : " + (PlayerManager.instance.player.GetComponent<Inventory>().arrows)).ToString(); ;
                arrowRight.SetActive(false);
            }          
        }
        StartCoroutine(RunAgain());
    }
}

