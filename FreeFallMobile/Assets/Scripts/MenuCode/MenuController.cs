using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    GameObject cameraMain;
	void Start ()
    {
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
	}
	void Update ()
    {
        cameraMain.transform.Rotate(new Vector3(1,1,0), 10 * Time.deltaTime);
    }
    public void LoadGame(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
