using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemy;

    bool canSpawn = true;
    //int preSpawnNumber;
	// Use this for initialization
	void Start ()
    {
       // InvokeRepeating("Spawn", 1, 1);
	}
    public void Spawn(int spawnNumber)
    {
        if (canSpawn)
        {
            //if (spawnPoints[spawnNumber].GetComponent<ParticleSystem>())
               // spawnPoints[spawnNumber].GetComponent<ParticleSystem>().Play();
            Instantiate(enemy, spawnPoints[spawnNumber].transform.position, Quaternion.identity);
            //preSpawnNumber = spawnNumber;
            StartCoroutine("SpawnTimer");
        }
    }
    IEnumerator SpawnTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(.1f);
        canSpawn = true;
        yield return null;
    }

}
