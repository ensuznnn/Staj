using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject levelFail;
    public GameObject levelSuccess;
    public GameObject background;
    private Scene scene;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(scene.name);
    }
    public void Fail()
    {
        StartCoroutine(Dead());
    }
    public void Success()
    {
        levelSuccess.SetActive(true);
        background.SetActive(true);
    }
    public void NextLevel()
    {
        Application.LoadLevel("BaseLevel");
    }
    IEnumerator Dead()
    {
        PlayerManager.instance.player.GetComponent<SwipeMovement>().enabled = false;
        PlayerManager.instance.player.GetComponent<TapToStart>().enabled = false;
        PlayerManager.instance.player.GetComponent<Animator>().SetBool("IsDead", true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        levelFail.SetActive(true);
        background.SetActive(true);
    }
}
