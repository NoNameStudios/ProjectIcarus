using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
    public GameObject[] spawnPoints;
    public GameObject enemy;
    int spawnNumber;
	// Use this for initialization
	void Start ()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
        spawnNumber = 0;
        InvokeRepeating("Spawn", 1, 1);
	}
    void Spawn()
    {
        if (spawnNumber >= spawnPoints.Length)
            spawnNumber = 0;
        Debug.Log(spawnNumber);
        Instantiate(enemy, spawnPoints[spawnNumber].transform.position, Quaternion.identity);
            spawnNumber++;
    }
}
