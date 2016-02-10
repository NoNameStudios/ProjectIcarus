using UnityEngine;
using System.Collections;

public class ButtonTest : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("On Click"); // is On Click
    }

    public void OnOver()
    {
        Debug.Log("On Over"); // is On Over
    }

    public void OnExit()
    {
        Debug.Log("On Exit"); // is On Exit
    }
}
