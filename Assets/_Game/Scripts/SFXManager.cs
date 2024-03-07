using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip = null;
    AudioSingleton audioSingleton = null;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSingleton = FindObjectOfType<AudioSingleton>();

    }

    public void PlayRandomClip()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(clip);
    }

    public void PlaySingletonClip()
    {
        audioSingleton.GetComponent<AudioSource>().Play();
    }
}
