using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private GameObject player;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int spawnNum;
    // Start is called before the first frame update
    void Start()
    {
      SpawnEnemyWave(spawnNum);
      player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (player.transform.position.y > -10)
        {
        if (enemyCount == 0) 
        {
            spawnNum++;
            SpawnEnemyWave(spawnNum);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            Debug.Log("Score = " + spawnNum);
        }
        } else {
            GameObject[] powerups = GameObject.FindGameObjectsWithTag("Powerup");
            foreach(GameObject powerupPrefab in powerups)
            GameObject.Destroy(powerupPrefab);
        }
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) 
        {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

}
