using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject flasher;
	// Use this for initialization
	void Start ()
    {
        flasher.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine("Flash");
        }
	}

    //Testing for shooting
    
        
    

    public IEnumerator Flash()
    {
        flasher.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flasher.SetActive(false);

    }
}
