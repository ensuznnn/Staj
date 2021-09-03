using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStart : MonoBehaviour
{
    public SwipeManager swipeManager;
    public GameObject taptostart;
    public void Update()
    {
        if(swipeManager.Tap)
        {
            PlayerManager.instance.player.GetComponent<SwipeMovement>().enabled = true;
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", true);
            taptostart.SetActive(false);
        }
    }
}
