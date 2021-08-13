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
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;
        var angleX = followTransform.transform.localEulerAngles.x;
        var angleY = followTransform.transform.localEulerAngles.y;
        //Clamp the Up/Down rotation
        if (angleX > 180 && angleX < 340 )
        {
            angles.x = 340;

            if (angleX < 180 && angleX > 40)
            {
                angles.y = 340;
            }
            else if(angleY < 180 && angleY > 40)
            {
                angles.y = 40;
            }
           
        }
        else if (angleX < 180 && angleX > 40 )
        {
            angles.x = 40;
            if (angleX < 180 && angleX > 40)
            {
                angles.y = 340;
            }
            else if (angleY < 180 && angleY > 40)
            {
                angles.y = 40;
            }
        }
   

            followTransform.transform.localEulerAngles = angles;
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
