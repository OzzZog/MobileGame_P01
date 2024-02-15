using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource PlayClip(AudioClip clip, float volume)
    {
        GameObject audioObject = new GameObject("Audio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.volume = volume;

        audioSource.Play();

        Object.Destroy(audioObject, clip.length);

        return audioSource;
    }
}
