using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    public Transform arrowBone;
    public GameObject arrowPrefab;
    public Button aimButton;
    public Button attackButton;
    public bool inAim;
    public bool inWait;
    public GameObject crosshair;
    public GameObject aimController;
    public GameObject charecterController;
    public GameObject look;
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject arrow;
    private AimController aimUnLock;
    private void Start()
    {
        Button aim = aimButton.GetComponent<Button>();
        Button attack = attackButton.GetComponent<Button>();
        aimUnLock = PlayerManager.instance.player.GetComponent<AimController>();

    }


    public void AimAnimation()
    {

        if (inAim == false)

        {
            aimUnLock.enabled = true;
            arrow.SetActive(true);
            aimController.SetActive(true);
            charecterController.SetActive(false);
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
            crosshair.SetActive(true);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", false);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Aim", true);
            inAim = true;
        }
        else
        {
            aimUnLock.enabled = false;
            arrow.SetActive(false);
            crosshair.SetActive(false);
            aimController.SetActive(false);
            charecterController.SetActive(true);
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", false);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Aim", false);
            inAim = false;
        }
    }

    public void AttackAnimation()
    {
        if (inAim == true)
        {
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", true);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Aim", false);
            inAim = false;
            crosshair.SetActive(false);
            aimController.SetActive(false);
            charecterController.SetActive(true);
            arrow.SetActive(false);
            aimUnLock.enabled = false;
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
            StartCoroutine(FireArrow());
        }
    }


    [SerializeField]
    private Transform fireTransform;
    IEnumerator FireArrow()
    {
        GameObject projectile = Instantiate(arrowPrefab);
        projectile.transform.forward = look.transform.forward;
        projectile.transform.position = fireTransform.position + fireTransform.forward;
        //Wait for the position to update
        yield return new WaitForSeconds(0.1f);

        projectile.GetComponent<ArrowProjectile>().Fire();

    }



}
