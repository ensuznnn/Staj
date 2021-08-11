using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Aim : MonoBehaviour
{
    public Button aimButton;
    public Button attackButton;
    public bool inAim;
    public GameObject mainCamera;
    public GameObject aimCamera;


    void Start()
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
                aimCamera.SetActive(true);

                //Allow time for the camera to blend before enabling the UI
                StartCoroutine(ShowReticle());
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
    }

    IEnumerator ShowReticle()
    {
        yield return new WaitForSeconds(100);
      //  aimReticle.SetActive(enabled);
    }
}