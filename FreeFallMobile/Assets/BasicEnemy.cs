using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
    public GameObject player;
    public int speed = 5;
    bool active = true;
	// Use this for initialization
	void Start ()
    {
       if(player != null)
            transform.LookAt(player.transform.position);
        else
        {
            player = GameObject.Find("Player");
          
        }
        StartCoroutine("EnemyBehaviour");
	}
    void Update()
    {
        if(active)
        {
            //Quaternion temp = transform.rotation;
            //transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.LookAt(player.transform.position);
            //Quaternion target = 
           // transform.position 
         
        }
        else
        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }
    public virtual IEnumerator EnemyBehaviour()
    {
            yield return new WaitForSeconds(0.5f);
        //transform.LookAt(player.transform.position);
             active = false;
            yield return new WaitForSeconds(5);
            Debug.Log("Destroy");
            Destroy(gameObject);
            yield return null;
    }

}
