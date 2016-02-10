using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
