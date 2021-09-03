using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwipeMovement : MonoBehaviour
{
    public SwipeManager swipeManager;
    public Attack attack;
    public Transform player;
    private Vector3 desiredPosition;
    private Vector3 cameraPosition;
    Camera camera;
    public void Update()
    {
        if (PlayerManager.instance.player.GetComponent<Animator>().GetBool("Run") == true)
        {
            desiredPosition += Vector3.forward * 0.01f;
            if (swipeManager.SwipeLeft)
            {
                if (player.transform.position.x > -2)
                    desiredPosition += Vector3.left*0.8f ;
            }
            if (swipeManager.SwipeRight)
            {
                if (player.transform.position.x < 2)
                    desiredPosition += Vector3.right * 0.8f;
            }
            if (swipeManager.Tap)
            {
                attack.FireArrow();
            }
            player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition*2.5f, 7f * Time.fixedDeltaTime);
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, cameraPosition + player.transform.position, 50 * 3f * Time.fixedDeltaTime);
        }
        else
        {
            if (swipeManager.Tap)
            {
                attack.FireArrow();
            }
        }
    }
   public void Start()
    {
        PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", true);
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPosition = Vector3.up * 2 + Vector3.forward * -2.5f;
        Time.timeScale = 2;
    }
}

