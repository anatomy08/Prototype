using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // singleton for BGM
    void Awake()
    {
        int numberOfMusic = FindObjectsOfType<BGM>().Length;

        if(numberOfMusic > 1) 
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}