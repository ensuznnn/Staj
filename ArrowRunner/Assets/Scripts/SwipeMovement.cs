using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public SwipeManager swipeManager;
    public Attack attack;
    public Transform player;
    private Vector3 desiredPosition;
    private Vector3 forwardMove;

    public void Update()
    {
        forwardMove += Vector3.forward * 1;
        desiredPosition.Set(desiredPosition.x, desiredPosition.y,forwardMove.z);

        if(swipeManager.SwipeLeft)
        {
            if (player.transform.position.x > -1.75)
                desiredPosition += Vector3.left * 1.75f;
        }

        if (swipeManager.SwipeRight)
        {
            if(player.transform.position.x < 1.75)
                desiredPosition += Vector3.right * 1.75f;
        }

        if (swipeManager.Tap)
        {
            attack.FireArrow();
        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.fixedDeltaTime);
    }

    public void Start()
    {
        PlayerManager.instance.player.GetComponent<Animator>().SetBool("Run", true);
    }

}
