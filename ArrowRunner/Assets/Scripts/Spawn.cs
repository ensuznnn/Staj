using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public bool enemySpawn;
    public int whereSpawn;
    public void EnemySpawn()
    {
        if (!enemySpawn)
        {
            for (int i = 0; i < PlayerManager.instance.player.GetComponent<Inventory>().arrows/2; i++)
            {
                StartCoroutine(EnemySpawned());
            }
        }
    }
    IEnumerator EnemySpawned()
    {
        enemySpawn = true;
        whereSpawn = UnityEngine.Random.Range(1, 4);
        switch (whereSpawn)
        {
            case 1:
                Instantiate(enemy, transform.position = new Vector3(0, 0, 225), Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy, transform.position = new Vector3(2.5f, 0, 225), Quaternion.identity);
                break;
            case 3:
                Instantiate(enemy, transform.position = new Vector3(-2.5f, 0, 225), Quaternion.identity);
                break;

        }
        yield return new WaitForSeconds(3f);
        enemySpawn = false;
    }
}
