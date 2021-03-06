﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AutoType : MonoBehaviour
{

    string message;

    // Use this for initialization
    void Start()
    {
        message = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            GetComponent<Text>().text += letter;
            yield return 0;
            yield return new WaitForSeconds(Random.Range(0.1f,0.4f));
        }
    }
}
