using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Transform player;
    Vector3 move;
    public float moveSpeed;

    public RectTransform pad;
    bool running;
    public void OnDrag(PointerEventData eventData)
    {
        if (PlayerManager.instance.player.GetComponent<Animator>().GetBool("Aim") == false)
        {
            transform.position = eventData.position;
            transform.localPosition =
                Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width *0.5f );

            move = new Vector3(transform.localPosition.x, 0, transform.localPosition.y);
            if (!running)
            {
                running = true;
                player.GetComponent<Animator>().SetBool("Run", true);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("PlayerMove");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        StopCoroutine("PlayerMove");
        running = false;
        player.GetComponent<Animator>().SetBool("Run", false);
    }

    IEnumerator PlayerMove()
    {
        while (true)
        {

            player.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            yield return null;
        }
    }
}
