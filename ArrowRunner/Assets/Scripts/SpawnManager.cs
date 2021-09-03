using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject trash;
    public GameObject roadwork;
    public GameObject bin;
    public GameObject wall;
    public GameObject arrowCollectible;
    public GameObject level;
    public GameObject endEra;
    Scene scene;
    public bool spawnControl;
    public int whatToSpawn;
    public int spawnPosition;
    public int i = 20;
    Quaternion rotation = Quaternion.Euler(0, 90, 0);
    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (!spawnControl)
        {
            for (int i = 0; i < 14; i++)
            {
                StartCoroutine(Spawner());
            }
            if (scene.name == "BaseLevel")
            {
                Instantiate(level, transform.position = new Vector3(0, 0, 305), Quaternion.identity);
                Instantiate(endEra, transform.position = new Vector3(-12.78931f, -18.31417f, 355f), Quaternion.identity);
                //Instantiate(level, transform.position = new Vector3(-0.1f, 0, 485), Quaternion.identity);
            }
        }
    }
    IEnumerator Spawner()
    {
        spawnControl = true;
        whatToSpawn = UnityEngine.Random.Range(1, 5);
        spawnPosition = UnityEngine.Random.Range(1, 3);
        switch (spawnPosition)
        {
            case 1:
                    switch (whatToSpawn)
                    {
                        case 1:
                            Instantiate(trash, transform.position = new Vector3(2.5f, 0, i), Quaternion.identity);
                            Instantiate(trash, transform.position = new Vector3(2.5f, 0, i+1), Quaternion.identity);
                            Instantiate(trash, transform.position = new Vector3(2.5f, 0, i + 2), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i+1), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i+2), Quaternion.identity);
                        break;
                        case 2:
                            Instantiate(trash, transform.position = new Vector3(3, 0, i), Quaternion.identity);
                            Instantiate(trash, transform.position = new Vector3(2, 0, i), Quaternion.identity);
                            Instantiate(trash, transform.position = new Vector3(1, 0, i), Quaternion.identity);
                            Instantiate(trash, transform.position = new Vector3(0, 0, i), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i+1), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i+2), Quaternion.identity);
                        break;
                        case 3:
                            Instantiate(wall, transform.position = new Vector3(0, 0, i), rotation);
                            break;
                        case 4:
                            Instantiate(roadwork, transform.position = new Vector3(0, 0, i), Quaternion.identity);
                            Instantiate(roadwork, transform.position = new Vector3(0.7f, 0, i), Quaternion.identity);
                            Instantiate(roadwork, transform.position = new Vector3(1.4f, 0, i), Quaternion.identity);
                            Instantiate(roadwork, transform.position = new Vector3(2.1f, 0, i), Quaternion.identity);
                            Instantiate(roadwork, transform.position = new Vector3(2.8f, 0, i), Quaternion.identity);
                            Instantiate(roadwork, transform.position = new Vector3(3.5f, 0, i), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i+1), Quaternion.identity);
                            Instantiate(arrowCollectible, transform.position = new Vector3(-2f, 1, i+2), Quaternion.identity);
                        break;
                    }
                break;

            case 2:
                switch (whatToSpawn)
                {
                    case 1:
                        Instantiate(trash, transform.position = new Vector3(-2.5f, 0, i), Quaternion.identity);
                        Instantiate(trash, transform.position = new Vector3(-2.5f, 0, i+1), Quaternion.identity);
                        Instantiate(trash, transform.position = new Vector3(-2.5f, 0, i + 2), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i+1), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i+2), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(trash, transform.position = new Vector3(-3, 0, i), Quaternion.identity);
                        Instantiate(trash, transform.position = new Vector3(-2, 0, i), Quaternion.identity);
                        Instantiate(trash, transform.position = new Vector3(-1, 0, i), Quaternion.identity);
                        Instantiate(trash, transform.position = new Vector3(0, 0, i), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i+1), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i+2), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(wall, transform.position = new Vector3(0, 0, i), rotation);
                        wall.transform.rotation = transform.rotation;
                        break;
                    case 4:
                        Instantiate(roadwork, transform.position = new Vector3(0, 0, i), Quaternion.identity);
                        Instantiate(roadwork, transform.position = new Vector3(-0.7f, 0, i), Quaternion.identity);
                        Instantiate(roadwork, transform.position = new Vector3(-1.4f, 0, i), Quaternion.identity);
                        Instantiate(roadwork, transform.position = new Vector3(-2.1f, 0, i), Quaternion.identity);
                        Instantiate(roadwork, transform.position = new Vector3(-2.8f, 0, i), Quaternion.identity);
                        Instantiate(roadwork, transform.position = new Vector3(-3.5f, 0, i), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i+1), Quaternion.identity);
                        Instantiate(arrowCollectible, transform.position = new Vector3(2f, 1, i+2), Quaternion.identity);
                        break;
                }
                break;
        }
        i += 10;
        yield return new WaitForSeconds(5f);
        spawnControl = false;
    }

}
