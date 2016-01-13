using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
