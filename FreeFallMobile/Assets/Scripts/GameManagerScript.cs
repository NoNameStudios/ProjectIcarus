using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject scoreCounter;
    int score = 0;

	void Awake ()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    public void EnemyDeath(int score, GameObject enemy)
    {
        this.score += score;
        enemies.Remove(enemy);
        scoreCounter.GetComponent<Text>().text = "" + this.score;
        Destroy(enemy);
    }
}
