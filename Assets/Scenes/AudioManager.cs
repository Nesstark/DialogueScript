using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] clips;
    private AudioSource audioSource;

    void Awake()
    { // singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }


        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        { 
            audioSource = gameObject.AddComponent<AudioSource>();
        }



    }

    public void PlaySound(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < clips.Length)
        {
            audioSource.clip = clips[clipIndex];
            audioSource.Play();


        }
        else
        {

            Debug.LogError("Clip index out of range");
        }


    }



}


