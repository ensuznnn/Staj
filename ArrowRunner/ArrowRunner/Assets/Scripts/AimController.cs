using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public GameObject followTransform;
    public bool left;
    public bool right;
    public bool up;
    public bool down;

    public void FixedUpdate()
    {
        if(left==true)
        {
            followTransform.transform.rotation *= Quaternion.AngleAxis(1, Vector3.down);
            PlayerManager.instance.player.transform.rotation *= Quaternion.AngleAxis(1, Vector3.down);
        }

        if(right==true)
        {
            followTransform.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
            PlayerManager.instance.player.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
        }
        if(up==true)
        {
            followTransform.transform.rotation *= Quaternion.AngleAxis(1, Vector3.left);
        }
        if (down == true)
        {
            followTransform.transform.rotation *= Quaternion.AngleAxis(1, Vector3.right);
        }
    }


    public void leftRotate(bool _left)
    {
        left = _left;    
    }
    public void rightRotate(bool _right)
    {
        right = _right;    
    }

    public void upRotate(bool _up)
    {
        up = _up;
          
    }
    public void downRotate(bool _down)
    {
        down = _down;     
    }

}
