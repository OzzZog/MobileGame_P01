using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void FindAudio()
    {
        instance = FindObjectOfType<AudioSingleton>();
    }
}
