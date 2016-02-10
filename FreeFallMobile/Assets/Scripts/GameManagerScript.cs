using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject scoreCounter;
    int score = 0;

    // reference to destroy off screen script
    DestroyOffScreen subtractScore; 

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

        // subtract score if enemy is not destroyed by player
        subtractScore = gameObject.GetComponent<DestroyOffScreen>();
        if(enemies != null)
        {
            this.score--;
        }
    }
}
