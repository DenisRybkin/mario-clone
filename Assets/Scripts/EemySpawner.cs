using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Vector3[] TileMapRange;
    //private Enemy[] enemies;
    // Start is called before the first frame update
    public GameObject prefabEnemy;
    public int countSpawns;


    private void Awake()
    {
        //enemies = GetComponentsInChildren<Enemy>();
    }

    private float RandomGenarateInRange(float min, float max) {
        return Random.Range(min, max);
        
    }

    private void Start()
    {
        // RandomSpawnEnemies();
        Spawn();
    }

    public void Spawn()
    {
        if (countSpawns == null | countSpawns == 0) return;

        Vector3 leftSpawnPoint = TileMapRange[0];
        Vector3 rightSpawnPoint = TileMapRange[1];

        for (int i = 0; i < countSpawns; i++)
        {
            Vector3 enemyPosition = new Vector3(RandomGenarateInRange(leftSpawnPoint.x, rightSpawnPoint.x), leftSpawnPoint.y, 0);
            Instantiate(prefabEnemy, enemyPosition, Quaternion.identity);
        }
    }

    public void RandomSpawnEnemies()
    {
        Vector3 leftSpawnPoint = TileMapRange[0];
        Vector3 rightSpawnPoint = TileMapRange[1];

       /* for(int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];
            Vector3 enemyPosition = new Vector3(RandomGenarateInRange(leftSpawnPoint.x, rightSpawnPoint.x), leftSpawnPoint.y, 0);
            enemy.transform.position = enemyPosition;
            
        }*/
    }
}
