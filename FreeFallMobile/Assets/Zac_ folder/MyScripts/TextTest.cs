using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextTest : MonoBehaviour
{
    public string message;
    private Text textInstance; // references text component 

	// Use this for initialization
	void Start ()
    {
        textInstance = GetComponent<Text>(); // gets reference on gameobject of text dynamically instead of manually 
	}
	
	// Update is called once per frame
	void Update ()
    {
        textInstance.text = message; 
	}
}
