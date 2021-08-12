using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimController : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    //public Transform player;
    Vector3 move;
    public float moveSpeed;
   // public Transform hips;
    public RectTransform aimPad;
    private Animator animator;

    void Start()
    {
        animator = PlayerManager.instance.player.GetComponent<Animator>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition =
            Vector2.ClampMagnitude(eventData.position - (Vector2)aimPad.position, aimPad.rect.width * 0.5f);

        move = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
       // StopCoroutine("AimRotation");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      //  StartCoroutine("AimRotation");
    }

    // IEnumerator AimRotation()
    // {

    // }

    private void OnAnimatorIK(int layerIndex)
    {
       
        animator.SetBoneLocalRotation(HumanBodyBones.Chest, UnityEngine.Quaternion.Euler(transform.position.z,transform.position.x,transform.position.y));
        
    }

}
