using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Aim : MonoBehaviour
{
    public Button aimButton;
    public Button attackButton;
    public bool inAim;
    public bool inWait;
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject crosshair;
    public GameObject aimController;
    public GameObject charecterController;

    public void Start()
    {
        Button aim = aimButton.GetComponent<Button>();
        Button attack = attackButton.GetComponent<Button>();
        aim.onClick.AddListener(AimAnimation);
        attack.onClick.AddListener(AttackAnimation);
    }
    public void AimAnimation()
    {

        if (inAim == false)
        {
            if (!aimCamera.activeInHierarchy)
            {
               
                mainCamera.SetActive(false);
                aimController.SetActive(true);
                charecterController.SetActive(false);
                aimCamera.SetActive(true);
                crosshair.SetActive(true);


            }

            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", false);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Aim", true);
            inAim = true;


        }
        else
        {
            if (!mainCamera.activeInHierarchy)
            {
          
                mainCamera.SetActive(true);
                aimCamera.SetActive(false);
                crosshair.SetActive(false);
                aimController.SetActive(false);
                charecterController.SetActive(true);

            }
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", false);
            PlayerManager.instance.player.GetComponent<Animator>().SetBool("Aim", false);
            inAim = false;
        }
    }
          
    public void AttackAnimation()
    {
        
        PlayerManager.instance.player.GetComponent<Animator>().SetBool("Fire", true);
        PlayerManager.instance.player.GetComponent<Animator>().SetBool("Aim", false);
        inAim = false;       
        mainCamera.SetActive(true);
        aimCamera.SetActive(false);
        crosshair.SetActive(false);
        aimController.SetActive(false);
        charecterController.SetActive(true);

    }

    IEnumerator Wait()
    {
        Debug.Log("Wait");
        yield return new WaitForSeconds(5.0f);   
    }
}