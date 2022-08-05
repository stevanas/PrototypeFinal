using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject zombiePrefab;
    public Transform[] playerSpawnPoints;
    public Transform[] enemySpawnPoints;
    public float spawnCooldown; //how many seconds between zombie spawns
    public float lastSpawn; //how many seconds between zombie spawns

    Vector3 randomSpawnPoint;

    private void Start()
    {
        randomSpawnPoint = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Length)].position;
        PhotonNetwork.Instantiate(playerPrefab.name, randomSpawnPoint, Quaternion.identity);    
        randomSpawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position;
        PhotonNetwork.Instantiate(zombiePrefab.name, randomSpawnPoint, Quaternion.identity);
    }

    private void Update()
    {
        if(Time.time - lastSpawn > spawnCooldown)
        {
            lastSpawn = Time.time;
            randomSpawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position;
            PhotonNetwork.Instantiate(zombiePrefab.name, randomSpawnPoint, Quaternion.identity);
        }
    }
}
