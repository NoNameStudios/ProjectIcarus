using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public int speed = 5;
    public GameObject sprite;
   
    bool active = true;
	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
       if(player != null)
            transform.LookAt(player.transform.position);
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
          
        }

        gameManager.GetComponent<GameManagerScript>().enemies.Add(gameObject); 

        StartCoroutine("EnemyBehaviour");
	}
    void Update()
    {
        if(active)
        {
            transform.LookAt(player.transform.position);
        }
        else
        transform.localPosition += transform.forward * speed * Time.deltaTime;

        //sprite.transform.Rotate(Vector3.up * 500 * Time.deltaTime);
        sprite.transform.RotateAround(transform.position, transform.forward, Time.deltaTime * 500f);
    }
    public virtual IEnumerator EnemyBehaviour()
    {
            yield return new WaitForSeconds(1f);
        //transform.LookAt(player.transform.position);
             active = false;
            yield return new WaitForSeconds(5);
        gameManager.GetComponent<GameManagerScript>().EnemyDeath(5, gameObject);
            //Destroy(gameObject);
            yield return null;
    }

}
