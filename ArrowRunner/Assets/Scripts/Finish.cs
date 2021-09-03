using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Finish : MonoBehaviour
{
    public Image background;
    public GameObject levelSuccess;
    public Button restart;  
    public Image arrowCounts;
    public GameObject boss;
    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            boss.SetActive(true);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", false);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Finish", true);
            gameObject.GetComponent<Spawn>().EnemySpawn();
        }
    }
}
