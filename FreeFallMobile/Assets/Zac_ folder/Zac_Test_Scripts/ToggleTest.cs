using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class ToggleTest : MonoBehaviour
{
    ToggleGroup toggleGroupInstance; // private field instance

    public Toggle currentSelection // getter
    {
        get { return toggleGroupInstance.ActiveToggles().FirstOrDefault(); }
    }

	// Use this for initialization
	void Start ()
    {
        toggleGroupInstance = GetComponent<ToggleGroup>();
        Debug.Log("First Selected" + currentSelection.name);

        SelectToggle(2); // pass in new id // activates third item in toggle group 
	}
	
	public void SelectToggle(int id)
    {
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle>();
        toggles [id].isOn = true; // pass id 
    }
}
