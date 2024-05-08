using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] obstaclePrefabs;
    
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;

    private float spawnRangeX = 28;
	private float spawnRangeZ = 7;

    private PlayerController playerConrollerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerConrollerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnObstacle() {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(12,0, 0);
       Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
    
}
